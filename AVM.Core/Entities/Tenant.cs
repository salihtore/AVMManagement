using System;
using System.Collections.Generic;

namespace AVM.Core.Entities
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public int? StoreId { get; set; }
        public int? UserId { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }

        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }
    }

}
