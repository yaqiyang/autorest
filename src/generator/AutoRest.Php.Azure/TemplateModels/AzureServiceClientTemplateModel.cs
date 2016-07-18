// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using AutoRest.Php.TemplateModels;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.Php.Azure.TemplateModels
{
    /// <summary>
    /// The model for the Azure service client.
    /// </summary>
    public class AzureServiceClientTemplateModel : ServiceClientTemplateModel
    {
        /// <summary>
        /// Initializes a new instance of the AzureServiceClientTemplateModel class.
        /// </summary>
        /// <param name="serviceClient">The service client instance.</param>
        public AzureServiceClientTemplateModel(ServiceClient serviceClient)
            : base(serviceClient)
        {
            MethodTemplateModels.Clear();
            Methods.Where(m => m.Group == null)
                .ForEach(m => MethodTemplateModels.Add(new AzureMethodTemplateModel(m, serviceClient)));
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
                    @"use MicrosoftAzure\Common\Internal\Resources",
                    @"use MicrosoftAzure\Common\Internal\Serialization\JsonSerializer",
                    @"use MicrosoftAzure\Common\OAuthServiceClient",
                    @"use MicrosoftAzure\Common\RestServiceClient",
                };
            }
        }

        /// <summary>
        /// Gets the base type of the service client.
        /// </summary>
        public override string BaseType
        {
            get
            {
                return "RestServiceClient";
            }
        }
    }
}