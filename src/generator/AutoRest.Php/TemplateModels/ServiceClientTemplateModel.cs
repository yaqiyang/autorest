﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using AutoRest.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.Php.TemplateModels
{
    /// <summary>
    /// The model for the service client template.
    /// </summary>
    public class ServiceClientTemplateModel : ServiceClient
    {
        /// <summary>
        /// Initializes a new instance of ServiceClientTemplateModel class.
        /// </summary>
        /// <param name="serviceClient"></param>
        public ServiceClientTemplateModel(ServiceClient serviceClient)
        {
            this.LoadFrom(serviceClient);
            HasModelTypes = serviceClient.HasModelTypes();
            MethodTemplateModels = new List<MethodTemplateModel>();
            Methods.Where(m => m.Group == null)
                .ForEach(m => MethodTemplateModels.Add(new MethodTemplateModel(m, serviceClient)));
            this.IsCustomBaseUri = serviceClient.Extensions.ContainsKey(SwaggerExtensions.ParameterizedHostExtension);
            this.ModuleDefinitionTemplateModel = new ModuleDefinitionTemplateModel(serviceClient.ApiVersion);
        }

        /// <summary>
        /// Gets the flag indicating whether client include model types.
        /// </summary>
        public bool HasModelTypes { get; private set; }

        /// <summary>
        /// Gets and sets the model template models.
        /// </summary>
        public List<MethodTemplateModel> MethodTemplateModels { get; set; }

        /// <summary>
        /// Gets the flag indicating whether url is from x-ms-parameterized-host extension.
        /// </summary>
        public bool IsCustomBaseUri { get; private set; }

        /// <summary>
        /// Gets the list of modules/classes which need to be included.
        /// </summary>
        public virtual List<string> Includes
        {
            get { return new List<string>(); }
        }

        /// <summary>
        /// Gets the base type of the client.
        /// </summary>
        public virtual string BaseType
        {
            get
            {
                return "RestServiceClient";
            }
        }

        /// <summary>
        /// Module definition template model.
        /// </summary>
        public ModuleDefinitionTemplateModel ModuleDefinitionTemplateModel { get; set; }
    }
}