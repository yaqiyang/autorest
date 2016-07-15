// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using AutoRest.Extensions.Azure;
using AutoRest.Php.Azure.Properties;
using AutoRest.Php.TemplateModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace AutoRest.Php.Azure.TemplateModels
{
    /// <summary>
    /// The model object for Azure methods.
    /// </summary>
    public class AzureMethodTemplateModel : MethodTemplateModel
    {
        /// <summary>
        /// Initializes a new instance of the AzureMethodTemplateModel class.
        /// </summary>
        /// <param name="source">The method current model is built for.</param>
        /// <param name="serviceClient">The service client - main point of access to the SDK.</param>
        public AzureMethodTemplateModel(Method source, ServiceClient serviceClient)
            : base(source, serviceClient)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            ParameterTemplateModels.Clear();
            source.Parameters.ForEach(p => ParameterTemplateModels.Add(new AzureParameterTemplateModel(p)));

            this.ClientRequestIdString = AzureExtensions.GetClientRequestIdString(source);
            this.RequestIdString = AzureExtensions.GetRequestIdString(source);
        }

        public string ClientRequestIdString { get; private set; }

        public string RequestIdString { get; private set; }

        /// <summary>
        /// Returns true if method has x-ms-long-running-operation extension.
        /// </summary>
        public bool IsLongRunningOperation
        {
            get { return Extensions.ContainsKey(AzureExtensions.LongRunningExtension); }
        }

        /// <summary>
        /// Gets the Get method model.
        /// </summary>
        public AzureMethodTemplateModel GetMethod
        {
            get
            {
                var getMethod = ServiceClient.Methods.FirstOrDefault(m => m.Url == Url
                                                                          && m.HttpMethod == HttpMethod.Get &&
                                                                          m.Group == Group);
                if (getMethod == null)
                {
                    throw new InvalidOperationException(
                        string.Format(CultureInfo.InvariantCulture, Resources.InvalidLongRunningOperationForCreateOrUpdate,
                            Name, Group));
                }

                return new AzureMethodTemplateModel(getMethod, ServiceClient);
            }
        }

        /// <summary>
        /// Generates Php code in form of string for deserializing polling response.
        /// </summary>
        /// <param name="variableName">Variable name which keeps the response.</param>
        /// <param name="type">Type of response.</param>
        /// <returns>Php code in form of string for deserializing polling response.</returns>
        public string DeserializePollingResponse(string variableName, IType type)
        {
            var builder = new IndentedStringBuilder("  ");

            string serializationLogic = type.DeserializeType(this.Scope, variableName);
            return builder.AppendLine(serializationLogic).ToString();
        }

        /// <summary>
        /// Gets the logic required to preprocess response body when required.
        /// </summary>
        public override string InitializeResponseBody
        {
            get
            {
                var sb = new IndentedStringBuilder();

                sb.AppendLine(base.InitializeResponseBody);

                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the list of namespaces where we look for classes that need to
        /// be instantiated dynamically due to polymorphism.
        /// </summary>
        public override List<string> ClassNamespaces
        {
            get
            {
                return new List<string>
				{
                    @"MicrosoftAzure\Common\Internal\Authentication\OAuthScheme",
                    @"MicrosoftAzure\Common\Internal\Filters\OAuthFilter",
                    @"MicrosoftAzure\Common\Internal\Http\HttpClient",
                    @"MicrosoftAzure\Common\Internal\Resources",
                    @"MicrosoftAzure\Common\Internal\Serialization\JsonSerializer",
                    @"MicrosoftAzure\Common\Internal\Utilities",
                    @"MicrosoftAzure\Common\OAuthServiceClient",
                    @"MicrosoftAzure\Common\RestServiceClient"
                };
            }
        }

        /// <summary>
        /// Gets the expression for default header setting.
        /// </summary>
        public override string SetDefaultHeaders
        {
            get
            {
                IndentedStringBuilder sb = new IndentedStringBuilder();
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets AzureOperationResponse generic type declaration.
        /// </summary>
        public override string OperationResponseReturnTypeString
        {
            get
            {
                return "Response";
            }
        }

        /// <summary>
        /// Gets the list of middelwares required for HTTP requests.
        /// </summary>
        public override IList<string> FaradayMiddlewares
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
        /// Gets the type for operation exception.
        /// </summary>
        public override string OperationExceptionTypeString
        {
            get
            {
                if (DefaultResponse.Body == null || DefaultResponse.Body.Name == "CloudError")
                {
                    return "ServiceException";
                }

                return base.OperationExceptionTypeString;
            }
        }
    }
}