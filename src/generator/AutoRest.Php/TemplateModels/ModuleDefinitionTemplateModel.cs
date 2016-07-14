// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;


namespace AutoRest.Php.TemplateModels
{
    /// <summary>
    /// The model for the service client template.
    /// </summary>
    public class ModuleDefinitionTemplateModel
    {
        /// <summary>
        /// the api version for the generated code.
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// Initializes a new instance of ModuleDefinitionTemplateModel class.
        /// </summary>
        /// <param name="version">Api version</param>
        public ModuleDefinitionTemplateModel(string version)
        {
            this.Version = version;
        }
    }
}