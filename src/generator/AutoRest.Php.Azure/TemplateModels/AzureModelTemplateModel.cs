// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using AutoRest.Php.TemplateModels;
using System.Collections.Generic;

namespace AutoRest.Php.Azure.TemplateModels
{
    /// <summary>
    /// The model for Azure model template.
    /// </summary>
    public class AzureModelTemplateModel : ModelTemplateModel
    {
        /// <summary>
        /// Initializes a new instance of the AzureModelTemplateModel class.
        /// </summary>
        /// <param name="source">The object to create model from.</param>
        /// <param name="allTypes">The list of all model types; Used to implement polymorphism.</param>
        public AzureModelTemplateModel(CompositeType source, ISet<CompositeType> allTypes)
            : base(source, allTypes)
        {
        }

        /// <summary>
        /// Returns code for declaring inheritance.
        /// </summary>
        /// <returns>Code for declaring inheritance.</returns>
        public override string GetBaseTypeName()
        {
            if (this.BaseModelType != null)
            {
                string typeName = this.BaseModelType.Name;

                return " extends " + typeName;
            }

            return string.Empty;
        }
        
        /// <summary>
        /// Generates code for model serialization.
        /// </summary>
        /// <param name="variableName">Variable serialize model from.</param>
        /// <param name="type">The type of the model.</param>
        /// <returns>The code for serialization in string format.</returns>
        public override string SerializeProperty(string variableName, IType type)
        {
            var builder = new IndentedStringBuilder("  ");

            string serializationLogic = type.AzureSerializeType(this.Scope, variableName);
            builder.AppendLine(serializationLogic);

            return builder.ToString();
        }

        /// <summary>
        /// Generates code for model deserialization.
        /// </summary>
        /// <param name="variableName">Variable deserialize model from.</param>
        /// <param name="type">The type of the model.</param>
        /// <returns>The code for вуserialization in string format.</returns>
        public override string DeserializeProperty(string variableName, IType type)
        {
            var builder = new IndentedStringBuilder("  ");

            string serializationLogic = type.AzureDeserializeType(this.Scope, variableName);
            return builder.AppendLine(serializationLogic).ToString();
        }

        /// <summary>
        /// Gets the list of modules/classes which need to be included.
        /// </summary>
        public override List<string> Includes
        {
            get
            {
                return new List<string>
                {
                    @"use MicrosoftAzure\Common\Internal\Authentication\OAuthScheme",
                    @"use MicrosoftAzure\Common\Internal\Filters\OAuthFilter",
                    @"use MicrosoftAzure\Common\Internal\Http\HttpClient",
                    @"use MicrosoftAzure\Common\Internal\OAuthRestProxy",
                    @"use MicrosoftAzure\Common\Internal\Resources",
                    @"use MicrosoftAzure\Common\Internal\Serialization\JsonSerializer",
                    @"use MicrosoftAzure\Common\Internal\ServiceRestProxy",
                    @"use MicrosoftAzure\Common\Internal\Utilities",
                    @"use MicrosoftAzure\Common\Internal\Validate"
                };
            }
        }

        /// <summary>
        /// The namespaces used by the Php template model
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
                    @"MicrosoftAzure\Common\Internal\OAuthRestProxy",
                    @"MicrosoftAzure\Common\Internal\Resources",
                    @"MicrosoftAzure\Common\Internal\Serialization\JsonSerializer",
                    @"MicrosoftAzure\Common\Internal\ServiceRestProxy",
                    @"MicrosoftAzure\Common\Internal\Utilities",
                    @"MicrosoftAzure\Common\Internal\Validate"
            };
            }
        }
    }
}