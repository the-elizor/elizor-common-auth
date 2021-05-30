// <copyright file="CoreLogger.cs" company="Elizor (Pvt) Ltd">
// Copyright (c) Elizor (Pvt) Ltd, 2021 
//		All Rights Reserved.
//		This unpublished material is proprietary to Elizor. The methods and techniques described herein are considered trade secrets (copyright) and/or confidential.
//		Reproduction or distribution, in whole or in part, is strictly forbidden except by prior express written permission from Elizor.
// </copyright>
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
using elizor.common.auth.identityserver.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elizor.common.auth.identityserver.IdentityServer4.Utils
{
    /// <summary>
    /// asp.net core logger
    /// </summary>
    /// <seealso cref="ICustomLogger" />
    public class CoreLogger : ICustomLogger
    {
        /// <summary>
        /// The logger factory
        /// </summary>
        private static ILoggerFactory _factory;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private ILogger GetLogger<T>()
        {
            if (_logger == null)
            {
                _logger = _factory.CreateLogger<T>();
            }

            return _logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreLogger"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public CoreLogger(ILoggerFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void LogError<T>(string message)
        {
            var logger = GetLogger<T>();
            logger.LogError(message);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void LogWarning<T>(string message)
        {
            var logger = GetLogger<T>();
            logger.LogWarning(message);
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void LogMessage<T>(string message)
        {
            var logger = GetLogger<T>();
            logger.LogInformation(message);
        }
    }
}
