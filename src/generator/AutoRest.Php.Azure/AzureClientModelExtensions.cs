// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AutoRest.Core.ClientModel;
using AutoRest.Core.Utilities;
using System;
using System.Globalization;
using System.Linq;

namespace AutoRest.Php.Azure
{
    using System.Collections.Generic;

    /// <summary>
    /// Keeps a few aux method used across all templates/models.
    /// </summary>
    public static class AzureClientModelExtensions
    {

        /// <summary>
        /// Generates Php code in form of string for deserializing object of given type.
        /// </summary>
        /// <param name="type">Type of object needs to be deserialized.</param>
        /// <param name="scope">Current scope.</param>
        /// <param name="valueReference">Reference to object which needs to be deserialized.</param>
        /// <returns>Generated Php code in form of string.</returns>
        public static string AzureDeserializeType(
            this IType type,
            IScopeProvider scope,
            string valueReference)
        {
            var composite = type as CompositeType;
            var sequence = type as SequenceType;
            var dictionary = type as DictionaryType;
            var primary = type as PrimaryType;
            var enumType = type as EnumType;

            var builder = new IndentedStringBuilder("  ");

            return builder.ToString();
        }

        /// <summary>
        /// Generates Php code in form of string for serializing object of given type.
        /// </summary>
        /// <param name="type">Type of object needs to be serialized.</param>
        /// <param name="scope">Current scope.</param>
        /// <param name="valueReference">Reference to object which needs to serialized.</param>
        /// <returns>Generated Php code in form of string.</returns>
        public static string AzureSerializeType(
            this IType type,
            IScopeProvider scope,
            string valueReference)
        {
            var composite = type as CompositeType;
            var sequence = type as SequenceType;
            var dictionary = type as DictionaryType;
            var primary = type as PrimaryType;

            var builder = new IndentedStringBuilder("  ");

            return builder.ToString();
        }
    }
}
