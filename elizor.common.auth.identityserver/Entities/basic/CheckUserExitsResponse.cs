﻿// <copyright file="CheckUserExitsResponse.cs" company="Elizor (Pvt) Ltd">
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

namespace elizor.common.auth.identityserver.Models.basic
{
    public class CheckUserExitsResponse
    {
        public bool IsSuccess { get; set; }
        public string PhoneNumber { get; set; }
        public CheckUserExitsResult Result { get; set; }
    }
}
