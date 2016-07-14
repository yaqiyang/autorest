// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using AutoRest.Extensions;

namespace AutoRest.Php.TemplateModels
{
    /// <summary>
    /// The model object for regular Php methods.
    /// </summary>
    public class MethodTemplateModel : Method
    {
        /// <summary>
        /// Initializes a new instance of the class MethodTemplateModel.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="serviceClient">The service client.</param>
        public MethodTemplateModel(Method source, ServiceClient serviceClient)
        {
            this.LoadFrom(source);
            ParameterTemplateModels = new List<ParameterTemplateModel>();
            source.Parameters.ForEach(p => ParameterTemplateModels.Add(new ParameterTemplateModel(p)));
            ServiceClient = serviceClient;
        }

        /// <summary>
        /// Gets the return type name for the underlying interface method
        /// </summary>
        public virtual string OperationResponseReturnTypeString
        {
            get
            {
                return "Response";
            }
        }

        /// <summary>
        /// Gets the type for operation exception
        /// </summary>
        public virtual string OperationExceptionTypeString
        {
            get
            {
                return "ServiceException";
            }
        }

        /// <summary>
        /// Gets the code required to initialize response body.
        /// </summary>
        public virtual string InitializeResponseBody
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets the list of namespaces where we look for classes that need to
        /// be instantiated dynamically due to polymorphism.
        /// </summary>
        public virtual List<string> ClassNamespaces
        {
            get
            {
                return new List<string> { };
            }
        }

        /// <summary>
        /// Gets the path parameters as a Php dictionary string
        /// </summary>
        public virtual string PathParamsPhpDict
        {
            get
            {
                return ParamsToPhpDict(EncodingPathParams, true);
            }
        }

        /// <summary>
        /// Gets the skip encoding path parameters as a Php dictionary string
        /// </summary>
        public virtual string SkipEncodingPathParamsRbDict
        {
            get
            {
                return ParamsToPhpDict(SkipEncodingPathParams);
            }
        }

        /// <summary>
        /// Gets the query parameters as a Php dictionary string
        /// </summary>
        public virtual string QueryParamsPhpDict
        {
            get
            {
                return ParamsToPhpDict(EncodingQueryParams);
            }
        }

        /// <summary>
        /// Gets the skip encoding query parameters as a Php dictionary string
        /// </summary>
        public virtual string SkipEncodingQueryParamsRbDict
        {
            get
            {
                return ParamsToPhpDict(SkipEncodingQueryParams);
            }
        }

        /// <summary>
        /// Gets the path parameters not including the params that skip encoding
        /// </summary>
        public virtual IEnumerable<ParameterTemplateModel> EncodingPathParams
        {
            get { return AllPathParams.Where(p => !(p.Extensions.ContainsKey(SwaggerExtensions.SkipUrlEncodingExtension) &&
                    String.Equals(p.Extensions[SwaggerExtensions.SkipUrlEncodingExtension].ToString(), "true", StringComparison.OrdinalIgnoreCase))); }
        }

        /// <summary>
        /// Gets the skip encoding path parameters
        /// </summary>
        public virtual IEnumerable<ParameterTemplateModel> SkipEncodingPathParams
        {
            get
            {
                return AllPathParams.Where(p => 
                    (p.Extensions.ContainsKey(SwaggerExtensions.SkipUrlEncodingExtension) &&
                    String.Equals(p.Extensions[SwaggerExtensions.SkipUrlEncodingExtension].ToString(), "true", StringComparison.OrdinalIgnoreCase) &&
                    !p.Extensions.ContainsKey("hostParameter")));
            }
        }

        /// <summary>
        /// Gets all path parameters
        /// </summary>
        public virtual IEnumerable<ParameterTemplateModel> AllPathParams
        {
            get { return ParameterTemplateModels.Where(p => p.Location == ParameterLocation.Path); }
        }

        /// <summary>
        /// Gets the skip encoding query parameters
        /// </summary>
        public virtual IEnumerable<ParameterTemplateModel> SkipEncodingQueryParams
        {
            get { return AllQueryParams.Where(p => p.Extensions.ContainsKey(SwaggerExtensions.SkipUrlEncodingExtension)); }
        }

        /// <summary>
        /// Gets the query parameters not including the params that skip encoding
        /// </summary>
        public virtual IEnumerable<ParameterTemplateModel> EncodingQueryParams
        {
            get { return AllQueryParams.Where(p => !p.Extensions.ContainsKey(SwaggerExtensions.SkipUrlEncodingExtension)); }
        }

        /// <summary>
        /// Gets all of the query parameters
        /// </summary>
        public virtual IEnumerable<ParameterTemplateModel> AllQueryParams
        {
            get { return ParameterTemplateModels.Where(p => p.Location == ParameterLocation.Query); }
        }

        /// <summary>
        /// Gets the list of middelwares required for HTTP requests.
        /// </summary>
        public virtual IList<string> FaradayMiddlewares
        {
            get
            {
                return new List<string>()
                {
                    "Guzzle",
                };
            }
        }

        /// <summary>
        /// Gets the expression for default header setting.
        /// </summary>
        public virtual string SetDefaultHeaders
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the reference to the service client object.
        /// </summary>
        public ServiceClient ServiceClient { get; set; }

        /// <summary>
        /// Gets the list of method paramater templates.
        /// </summary>
        public List<ParameterTemplateModel> ParameterTemplateModels { get; private set; }
        
        /// <summary>
        /// Gets the list of parameter which need to be included into HTTP header.
        /// </summary>
        public IEnumerable<Parameter> Headers
        {
            get
            {
                return Parameters.Where(p => p.Location == ParameterLocation.Header);
            }
        }

        /// <summary>
        /// Gets the URL without query parameters.
        /// </summary>
        public string UrlWithoutParameters
        {
            get
            {
                return this.Url.Split('?').First();
            }
        }

        /// <summary>
        /// Get the predicate to determine of the http operation status code indicates success
        /// </summary>
        public string SuccessStatusCodePredicate
        {
            get
            {
                if (Responses.Any())
                {
                    List<string> predicates = new List<string>();
                    foreach (var responseStatus in Responses.Keys)
                    {
                        predicates.Add(string.Format("$statusCode == {0}", GetStatusCodeReference(responseStatus)));
                    }

                    return string.Join(" || ", predicates);
                }

                return "$statusCode >= 200 && $statusCode < 300";
            }
        }

        /// <summary>
        /// Get the list of success status code
        /// </summary>
        public string SuccessStatusCodeList
        {
            get
            {
                if (Responses.Any())
                {
                    List<string> predicates = new List<string>();
                    foreach (var responseStatus in Responses.Keys)
                    {
                        predicates.Add(GetStatusCodeReference(responseStatus));
                    }

                    return string.Join(", ", predicates);
                }

                return "200";
            }
        }

        /// <summary>
        /// Gets the method parameter declaration parameters list.
        /// </summary>
        public string MethodParameterDeclaration
        {
            get
            {
                List<string> declarations = new List<string>();
                foreach (var parameter in LocalParameters.Where(p => !p.IsConstant))
                {
                    string format = "${0}";
                    if (!parameter.IsRequired)
                    {
                        format = "${0} = null";
                        if (parameter.DefaultValue != null && parameter.Type is PrimaryType)
                        {
                            PrimaryType type = parameter.Type as PrimaryType;
                            if (type != null)
                            {
                                if (type.Type == KnownPrimaryType.Boolean || type.Type == KnownPrimaryType.Double ||
                                    type.Type == KnownPrimaryType.Int || type.Type == KnownPrimaryType.Long || type.Type == KnownPrimaryType.String)
                                {
                                    format = "${0} = " + parameter.DefaultValue;
                                }
                            }
                        }
                    }

                    if (!(parameter.Type is PrimaryType))
                    {
                        format = "array ${0}";
                    }

                    declarations.Add(string.Format(format, parameter.Name));
                }

                declarations.Add("array $customHeaders = []");

                return string.Join(", ", declarations);
            }
        }

        /// <summary>
        /// Gets the method parameter invocation parameters list.
        /// </summary>
        public string MethodParameterInvocation
        {
            get
            {
                var invocationParams = LocalParameters.Where(p => !p.IsConstant).Select(p => "$" + p.Name).ToList();
                invocationParams.Add("$customHeaders");

                return string.Join(", ", invocationParams);
            }
        }

        /// <summary>
        /// Get the parameters that are actually method parameters in the order they appear in the method signature
        /// exclude global parameters
        /// </summary>
        public IEnumerable<ParameterTemplateModel> LocalParameters
        {
            get
            {
                //Omit parameter group parameters for now since AutoRest-Php doesn't support them
                return
                    ParameterTemplateModels.Where(
                        p => p != null && p.ClientProperty == null && !string.IsNullOrWhiteSpace(p.Name))
                        .OrderBy(item => !item.IsRequired);
            }
        }

        /// <summary>
        /// Get the method's request body (or null if there is no request body)
        /// </summary>
        public ParameterTemplateModel RequestBody
        {
            get { return ParameterTemplateModels.FirstOrDefault(p => p.Location == ParameterLocation.Body); }
        }

        /// <summary>
        /// Generate a reference to the ServiceClient
        /// </summary>
        public string UrlReference
        {
            get { return Group == null ? "null" : "$this->_client->getUrl('')"; }
        }

        /// <summary>
        /// Generate a reference to the ServiceClient
        /// </summary>
        public string ClientReference
        {
            get { return "$this->_client"; }
        }

        /// <summary>
        /// Gets the flag indicating whether URL contains path parameters.
        /// </summary>
        public bool UrlWithPath
        {
            get
            {
                return ParameterTemplateModels.Any(p => p.Location == ParameterLocation.Path);
            }
        }

        /// <summary>
        /// Creates a code in form of string which deserializes given input variable of given type.
        /// </summary>
        /// <param name="inputVariable">The input variable.</param>
        /// <param name="type">The type of input variable.</param>
        /// <param name="outputVariable">The output variable.</param>
        /// <returns>The deserialization string.</returns>
        public virtual string CreateDeserializationString(string inputVariable, IType type, string outputVariable)
        {
            var builder = new IndentedStringBuilder("  ");

           return builder.ToString();
        }

        /// <summary>
        /// Creates a code in form of string which serializes given input variable of given type.
        /// </summary>
        /// <param name="inputVariable">The input variable.</param>
        /// <param name="type">The type of input variable.</param>
        /// <param name="outputVariable">The output variable.</param>
        /// <returns>The serialization code.</returns>
        public virtual string CreateSerializationString(string inputVariable, IType type, string outputVariable)
        {
            var builder = new IndentedStringBuilder("  ");

            // Firstly recursively serialize each component of the object.
            string serializationLogic = type.SerializeType(this.Scope, inputVariable);

            builder.AppendLine(serializationLogic);

            // After that - generate JSON object after serializing each component.
            return builder.ToString();
        }

        /// <summary>
        /// Saves url items from the URL into collection.
        /// </summary>
        /// <param name="hashName">The name of the collection save url items to.</param>
        /// <param name="variableName">The URL variable.</param>
        /// <returns>Generated code of saving url items.</returns>
        public virtual string SaveExistingUrlItems(string hashName, string variableName)
        {
            var builder = new IndentedStringBuilder("  ");

            return builder.ToString();
        }

        /// <summary>
        /// Ensures that there is no duplicate forward slashes in the url.
        /// </summary>
        /// <param name="urlVariableName">The url variable.</param>
        /// <returns>Updated url.</returns>
        public virtual string RemoveDuplicateForwardSlashes(string urlVariableName)
        {
            var builder = new IndentedStringBuilder("  ");

            return builder.ToString();
        }

        /// <summary>
        /// Generate code to build the URL from a url expression and method parameters
        /// </summary>
        /// <param name="variableName">The variable to store the url in.</param>
        /// <returns></returns>
        public virtual string BuildUrl(string variableName)
        {
            var builder = new IndentedStringBuilder("  ");
            BuildPathParameters(variableName, builder);

            return builder.ToString();
        }

        /// <summary>
        /// Gets the formatted status code.
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <returns>Formatted status code.</returns>
        public string GetStatusCodeReference(HttpStatusCode code)
        {
            return string.Format("{0}", (int)code);
        }

        /// <summary>
        /// Generate code to replace path parameters in the url template with the appropriate values
        /// </summary>
        /// <param name="variableName">The variable name for the url to be constructed</param>
        /// <param name="builder">The string builder for url construction</param>
        protected virtual void BuildPathParameters(string variableName, IndentedStringBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            IEnumerable<Parameter> pathParameters = LogicalParameters.Where(p => p.Extensions.ContainsKey("hostParameter") && p.Location == ParameterLocation.Path);

            foreach (var pathParameter in pathParameters)
            {
                var pathReplaceFormat = "{0} = {0}.gsub('{{{1}}}', {2})";
                var urlPathName = UrlPathNameFromPathPattern(pathParameter.SerializedName);
                builder.AppendLine(pathReplaceFormat, variableName, urlPathName, pathParameter.GetFormattedReferenceValue());
            }
        }

        /// <summary>
        /// Builds the parameters as a Php dictionary string
        /// </summary>
        /// <param name="parameters">The enumerable of parameters to be turned into a Php dictionary.</param>
        /// <param name="addCurly">Adds {} if true</param>
        /// <returns>Php dictionary as a string</returns>
        protected string ParamsToPhpDict(IEnumerable<ParameterTemplateModel> parameters, bool addCurly = false)
        {
            var encodedParameters = new List<string>();
            foreach (var param in parameters)
            {
                string variableName = param.Name;
                string urlPathName = UrlPathNameFromPathPattern(param.SerializedName);
                string format = "'{0}' => ${1}";
                if (addCurly)
                {
                    format = "'{{{0}}}' => ${1}";
                }
                encodedParameters.Add(string.Format(format, urlPathName, param.GetFormattedReferenceValue()));
            }

            return string.Format(CultureInfo.InvariantCulture, "[{0}]", string.Join(", ", encodedParameters));
        }

        /// <summary>
        /// Builds the url path parameter from the pattern if exists
        /// </summary>
        /// <param name="urlPathParamName">Name of the path parameter to match.</param>
        /// <returns>url path parameter as a string</returns>
        private string UrlPathNameFromPathPattern(string urlPathParamName)
        {
            string pat = @".*\{" + urlPathParamName + @"(\:\w+)\}";
            Regex r = new Regex(pat);
            Match m = r.Match(Url);
            if (m.Success)
            {
                urlPathParamName += m.Groups[1].Value;
            }
            return urlPathParamName;
        }

        /// <summary>
        /// Inserts a wrapped comment with specified prefix.
        /// </summary>
        /// <param name="prefix">The prefix of the comment.</param>
        /// <param name="comment">The comment text.</param>
        /// <returns>The wrapped string.</returns>
        public string WrapComment(string prefix, string comment)
        {
            int maximumDesiredWidth = 100;

            if (string.IsNullOrWhiteSpace(comment))
            {
                return null;
            }

            int available =
                maximumDesiredWidth -
                prefix.Length - // - Prefix //'s length
                1; // - Extra space between prefix and text
            return string.Join(Environment.NewLine, WordWrap(comment, available)
                .Select(s => string.Format(CultureInfo.InvariantCulture, "{0}{1}", prefix, s)));
        }

        /// <summary>
        /// Wrap the words for the comments without trimming the spaces.
        /// </summary>
        /// <param name="text">The text to wrap.</param>
        /// <param name="width">The width of the line.</param>
        /// <returns>The wrapped lines.</returns>
        public static IEnumerable<string> WordWrap(string text, int width)
        {
            int start = 0; // Start of the current line
            int end = 0; // End of the current line
            char last = ' '; // Last character processed

            // Walk the entire string, processing line by line
            for (int i = 0; i < text.Length; i++)
            {
                // Support newlines inside the comment text.
                if (text[i] == '\n')
                {
                    yield return text.Substring(start, i - start + 1);

                    start = i + 1;
                    end = start;
                    last = ' ';

                    continue;
                }

                // If our current line is longer than the desired wrap width,
                // we'll stop the line here
                if (i - start >= width && start != end)
                {
                    // Yield the current line
                    yield return text.Substring(start, end - start + 1);

                    // Set things up for the next line
                    start = end + 1;
                    end = start;
                    last = ' ';
                }

                // If the last character was a space, mark that spot as a
                // candidate for a potential line break
                if (!char.IsWhiteSpace(last) && char.IsWhiteSpace(text[i]))
                {
                    end = i - 1;
                }

                last = text[i];
            }

            // Don't forget to include the last line of text
            if (start < text.Length)
            {
                yield return text.Substring(start, text.Length - start);
            }
        }

    }
}