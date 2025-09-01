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

using System.Diagnostics;
using UnityEngine;

#nullable enable
namespace Uralstech.Utils.Loggers
{
    /// <summary>
    /// A release aware logger which supports tags.
    /// </summary>
    public sealed class TaggedRALogger
    {
        /// <summary>The tag that will be used in all logs.</summary>
        private readonly string? _tag;

        /// <summary>The actual underlying logger which will be used to log all messages.</summary>
        private readonly Logger? _logger;

        /// <param name="tag">The logger tag.</param>
        public TaggedRALogger(string tag)
        {
#if DEBUG || ULOGGERS_ALWAYS_LOG
            _tag = tag;
            _logger = new(UnityEngine.Debug.unityLogger.logHandler);
#endif
        }

        /// <param name="tag">The logger tag.</param>
        /// <param name="logHandler">The log handler to use.</param>
        public TaggedRALogger(string tag, ILogHandler logHandler)
        {
#if DEBUG || ULOGGERS_ALWAYS_LOG
            _tag = tag;
            _logger = new(logHandler);
#endif
        }

        /// <summary>
        /// Logs a message in development builds.
        /// </summary>
        /// <param name="message">The message.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void Log(string message)
        {
            _logger!.Log(LogType.Log, _tag, message);
        }

        /// <summary>
        /// Logs an error message in development builds.
        /// </summary>
        /// <param name="message">The message.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void LogError(string message)
        {
            _logger!.Log(LogType.Error, _tag, message);
        }

        /// <summary>
        /// Logs a warning message in development builds.
        /// </summary>
        /// <param name="message">The message.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void LogWarning(string message)
        {
            _logger!.Log(LogType.Warning, _tag, message);
        }

        /// <summary>
        /// Logs a message in development builds.
        /// </summary>
        /// <param name="message">The message object.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void Log(object message)
        {
            _logger!.Log(LogType.Log, _tag, message);
        }

        /// <summary>
        /// Logs an error message in development builds.
        /// </summary>
        /// <param name="message">The message object.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void LogError(object message)
        {
            _logger!.Log(LogType.Error, _tag, message);
        }

        /// <summary>
        /// Logs a warning message in development builds.
        /// </summary>
        /// <param name="message">The message object.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void LogWarning(object message)
        {
            _logger!.Log(LogType.Warning, _tag, message);
        }

        /// <summary>
        /// Logs a formatted message in development builds.
        /// </summary>
        /// <param name="logType">The type of the log.</param>
        /// <param name="format">The format string.</param>
        /// <param name="args">The format arguments.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void Log(LogType logType, string format, params object[] args)
        {
            _logger!.LogFormat(logType, $"{_tag}: {format}", args);
        }

        /// <summary>
        /// Logs a formatted message in development builds.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="args">The format arguments.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void Log(string format, params object[] args)
        {
            _logger!.LogFormat(LogType.Log, $"{_tag}: {format}", args);
        }

        /// <summary>
        /// Logs a formatted error message in development builds.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="args">The format arguments.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void LogError(string format, params object[] args)
        {
            _logger!.LogFormat(LogType.Error, $"{_tag}: {format}", args);
        }

        /// <summary>
        /// Logs a formatted warning message in development builds.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="args">The format arguments.</param>
        [Conditional("DEBUG"), Conditional("ULOGGERS_ALWAYS_LOG")]
        public void LogWarning(string format, params object[] args)
        {
            _logger!.LogFormat(LogType.Warning, $"{_tag}: {format}", args);
        }
    }
}
