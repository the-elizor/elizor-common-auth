// ---------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="Elizor (Pvt) Ltd">
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
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoleCode { get; set; }
        public bool Status { get; set; }
        public bool IsSystemRole { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
