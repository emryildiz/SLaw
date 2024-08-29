﻿using SLaw.Domain.Entities.Common;
using SLaw.Domain.Entities.Identity;

namespace SLaw.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public Endpoint()
        {
            this.Roles = new HashSet<AppRole>();
        }

        public string ActionType { get; set; }

        public string HttpType { get; set; }

        public string Definition { get; set; }

        public string Code { get; set; }

        public ICollection<AppRole> Roles { get; set; }
    }
}
