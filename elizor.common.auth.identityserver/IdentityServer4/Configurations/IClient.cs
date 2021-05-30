// <copyright file="IClient.cs" company="Elizor (Pvt) Ltd">
// Copyright (c) Elizor (Pvt) Ltd, 2021 
//		All Rights Reserved.
//		This unpublished material is proprietary to Elizor. The methods and techniques described herein are considered trade secrets (copyright) and/or confidential.
//		Reproduction or distribution, in whole or in part, is strictly forbidden except by prior express written permission from Elizor.
// </copyright>
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elizor.common.auth.identityserver.IdentityServer4.Configurations
{
    public class IClient : Client
    {
        public bool ResetEnabled { get; set; }
        public string CssUri { get; set; }
        public string LoginProvider { get; set; }
        public string ClientAuthenticationType { get; set; }
        public ADFSConfigs ADFSConfigurations { get; set; }
        public ADSettings ADSettings { get; set; }
    }

    public static class IDServerClientUtils
    {
        public enum ClientAuthenticationMethods { LocalDB, ADFS, ExternalLogin, AzureAD };
    }

    public class ADFSConfigs
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string GrantType { get; set; }
        public string ApiUril { get; set; }

        public ADFSConfigs(string _clientID, string _clientSecret, string _scope, string _grantType, string _apiUrl)
        {
            this.ClientID = _clientID;
            this.ClientSecret = _clientSecret;
            this.Scope = _scope;
            this.GrantType = _grantType;
            this.ApiUril = _apiUrl;
        }
    }

    public class ADSettings
    {
        public String ClientID { get; set; }

        public string ClientSecret { get; set; }

        public String URL { get; set; }

        public String Tenant { get; set; }

        public String Authority { get; set; }

        public ADSettings(string _clientID, string _clientSecret, string _url, string _tenant, string _authority)
        {
            ClientID = _clientID;
            ClientSecret = _clientSecret;
            URL = _url;
            Tenant = _tenant;
            Authority = _authority;
        }
    }
}
