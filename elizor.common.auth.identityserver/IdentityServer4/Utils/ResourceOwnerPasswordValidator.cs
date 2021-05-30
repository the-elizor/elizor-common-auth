// <copyright file="ResourceOwnerPasswordValidator.cs" company="Elizor (Pvt) Ltd">
// Copyright (c) Elizor (Pvt) Ltd, 2021 
//		All Rights Reserved.
//		This unpublished material is proprietary to Elizor. The methods and techniques described herein are considered trade secrets (copyright) and/or confidential.
//		Reproduction or distribution, in whole or in part, is strictly forbidden except by prior express written permission from Elizor.
// </copyright>
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
using elizor.common.auth.identityserver.Contracts;
using elizor.common.auth.identityserver.IdentityServer4.Configurations;
using elizor.common.auth.identityserver.Models.basic;
using elizor.common.auth.services.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace elizor.common.auth.identityserver.IdentityServer4.Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IdentityServer4.Validation.IResourceOwnerPasswordValidator" />
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ICustomLogger _logger;

        public readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOwnerPasswordValidator"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public ResourceOwnerPasswordValidator(
            ICustomLogger logger,
            IConfiguration configuration
            )
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Validates the resource owner password credential
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                string clientId = context.Request.Client.ClientId;

                User usrObj = new User
                {
                    UserName = context.UserName,
                    Password = context.Password
                };

                var clientIdInfo = context.Request.Raw["client"];

                if (ClientIdentification.ResourceOwner_BasicAuthantication.Equals(clientId))
                {

                    //check user exist in db
                    var userValidateUrl = _configuration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["UserValidateUrl"].ToString();

                    var request = new CheckUserExitsRequest
                    {
                        Username = context.UserName,
                        ClientId = clientIdInfo
                    };

                    var tempClaims = new List<System.Security.Claims.Claim>();

                    using (var client = new HttpClient())
                    {
                        var serializedRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                        var httpResponse = client.PostAsync(userValidateUrl, serializedRequest).GetAwaiter().GetResult();

                        if (httpResponse == null)
                        {
                            return Task.FromResult(context.Result);
                        }

                        var result = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                        var oCheckOtpResponse = JsonConvert.DeserializeObject<CheckUserExitsResponse>(result);

                        if (oCheckOtpResponse != null && oCheckOtpResponse.IsSuccess && oCheckOtpResponse.Result != null)
                        {
                            var email = oCheckOtpResponse.Result.Email ?? "N/A";

                            tempClaims = new List<System.Security.Claims.Claim>()
                        {
                            new System.Security.Claims.Claim("ISOTPValidated", "true"),
                            new System.Security.Claims.Claim("Email", email),
                        };
                            context.Result = new GrantValidationResult("", "password", tempClaims, "local", null);
                            return Task.FromResult<GrantValidationResult>(context.Result);
                        }
                    }
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Client Id Not Found", null);
                return Task.FromResult(context.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError<User>(ex.StackTrace);
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, ex.InnerException.ToString(), null);
                return Task.FromResult(context.Result);
            }
        }
    }
}
