// <copyright file="ClientIdentification.cs" company="Elizor (Pvt) Ltd">
// Copyright (c) Elizor (Pvt) Ltd, 2021 
//		All Rights Reserved.
//		This unpublished material is proprietary to Elizor. The methods and techniques described herein are considered trade secrets (copyright) and/or confidential.
//		Reproduction or distribution, in whole or in part, is strictly forbidden except by prior express written permission from Elizor.
// </copyright>
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elizor.common.auth.identityserver.IdentityServer4.Configurations
{
    public class ClientIdentification
    {
        public static string ResourceOwner_LocalDB = "ResourceOwner_LocalDB";
        public static string ResourceOwner_LocalDB_OTP = "ResourceOwner_LocalDB_OTP";
        public static string ResourceOwner_ADFS = "ResourceOwner_ADFS";
        public static string ResourceOwner_AD = "ResourceOwner_AD";
        public static string ResourceOwner_Adal = "ResourceOwner_ADAL";
        public static string ResourceOwner_BasicAuthantication = "ResourceOwner_BasicAuthantication"; // ISConfig.GetClients
    }

    public class ClientConfigurationTypes
    {
        public static string ResourceOwner_LocalDB = "ResourceOwnerLocalDBConfigurations";
        public static string ResourceOwner_ADFS = "ResourceOwnerADFSConfigurations";
        public static string ResourceOwner_AD = "ResourceOwnerADConfigurations";
        public static string ResourceOwner_LocalDB_OTP = "ResourceOwnerLocalDBOTPConfigurations";
        public static string ResourceOwner_Adal = "ResourceOwnerADALConfigurations";
        public static string ResourceOwner_BasicAuthantication = "ResourceOwnerPasswordConfigurations"; // ISConfig.GetApiResources
    }

    public class ClientResoureScope
    {
        public static string ResourceOwner_LocalDB_OTP = "ResourceOwner_LocalDB_SCOPE_OTP";
        public static string ResourceOwner_Adal = "ResourceOwner_Adal_SCOPE_Adal";
        public static string ResourceOwner_BasicAuthantication = "ResourceOwner_BasicAuthantication_SCOPE"; // ISConfig.GetApiResources
        public static string ResourceOwner_AD = "ResourceOwner_SCOPE_AD";
    }

    public class ClientAPI
    {
        public static string ResourceOwner_LocalDB_OTP = "ResourceOwner_LocalDB_SCOPE_OTP";
        public static string ResourceOwner_Adal = "ResourceOwner_Adal_SCOPE_Adal";
        public static string ResourceOwner_BasicAuthantication = "ResourceOwner_BasicAuthantication";  // ISConfig.GetApiResources
        public static string ResourceOwner_AD = "ResourceOwner_SCOPE_AD";
    }
}
