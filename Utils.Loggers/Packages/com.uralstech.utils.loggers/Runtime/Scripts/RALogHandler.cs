// Copyright 2025 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using UnityEngine;

#nullable enable
namespace Uralstech.Utils.Loggers
{
    /// <summary>
    /// A log handler that only logs in release builds.
    /// </summary>
    public sealed class RALogHandler : ILogHandler
    {
        /// <inheritdoc/>
        public void LogException(Exception exception, UnityEngine.Object context)
        {
#if DEBUG || ULOGGERS_ALWAYS_LOG
            Debug.unityLogger.LogException(exception, context);
#endif
        }

        /// <inheritdoc/>
        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
#if DEBUG || ULOGGERS_ALWAYS_LOG
            Debug.unityLogger.LogFormat(logType, context, format, args);
#endif
        }
    }
}
