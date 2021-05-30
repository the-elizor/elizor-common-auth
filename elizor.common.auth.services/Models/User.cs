// ---------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Elizor (Pvt) Ltd">
// Copyright © John Keells IT (Pvt) Limited, 2021.
//      All Rights Reserved.
//      This unpublished material is proprietary to Elizor. The methods and techniques described herein are considered trade secrets (copyright) and/or confidential.
//      Reproduction or distribution, in whole or in part, is forbidden except by prior express written permission from Elizor.
// </copyright>
//----------------------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elizor.common.auth.services.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public bool IsFirstAttempt { get; set; }
        public bool IsTempararyPassword { get; set; }
        public bool ActiveStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondaryUsername { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool TermsAndConditionStatus { get; set; }
        public DateTime? TermsAndConditionAcceptDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
