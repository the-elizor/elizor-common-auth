// <copyright file="ISConfig.cs" company="Elizor (Pvt) Ltd">
// Copyright (c) Elizor (Pvt) Ltd, 2021 
//		All Rights Reserved.
//		This unpublished material is proprietary to Elizor. The methods and techniques described herein are considered trade secrets (copyright) and/or confidential.
//		Reproduction or distribution, in whole or in part, is strictly forbidden except by prior express written permission from Elizor.
// </copyright>
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elizor.common.auth.identityserver.IdentityServer4.Configurations
{
    public class ISConfig
    {
        public IConfiguration _iconfiguration;

        public ISConfig(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources(IConfiguration iconfiguration)
        {
            return new List<ApiResource>
            {
                new ApiResource(ClientAPI.ResourceOwner_BasicAuthantication, "ResourceOwner_BasicAuthantication")
                {
                    ApiSecrets = new List<Secret>
                    {
                        new Secret(iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["APISecret"].ToString().Sha256())
                    },
                    Scopes=
                    {
                        new Scope(ClientResoureScope.ResourceOwner_BasicAuthantication)
                    }
                }
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<IClient> GetClients(IConfiguration iconfiguration)
        {
            // client credentials client
            return new List<IClient>
            {
                new IClient
                {
                    ClientId = ClientIdentification.ResourceOwner_BasicAuthantication,
                    ClientName = iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["ClientName"].ToString(),
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowAccessTokensViaBrowser = false,
                    AllowedCorsOrigins = iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["AllowedScopes"].ToString().Split(',').ToList(),
                    ClientSecrets =
                    {
                        new Secret(iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["ClientSecrets"].ToString().Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        ClientResoureScope.ResourceOwner_BasicAuthantication
                    },
                    AccessTokenLifetime = Convert.ToInt32(iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["AccessTokenLifetime"].ToString()),
                    AllowOfflineAccess = Convert.ToBoolean(iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["AllowOfflineAccess"].ToString()),
                    UpdateAccessTokenClaimsOnRefresh = Convert.ToBoolean(iconfiguration.GetSection(ClientConfigurationTypes.ResourceOwner_BasicAuthantication)["UpdateAccessTokenClaimsOnRefresh"].ToString())
                },
            };
        }
    }
}
