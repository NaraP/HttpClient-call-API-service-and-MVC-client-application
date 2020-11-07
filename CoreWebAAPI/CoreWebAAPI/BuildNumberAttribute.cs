﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAAPI
{
    /// <summary>
    /// A run-time-accessible property specified in .csproj file in order to store the build-number of the CI build-pipeline.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class BuildNumberAttribute : Attribute
    {
        public BuildNumberAttribute(string buildNumber)
        {
            BuildNumber = buildNumber;
        }

        public string BuildNumber { get; }
    }
}
