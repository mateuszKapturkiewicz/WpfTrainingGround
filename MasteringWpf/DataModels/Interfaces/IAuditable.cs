﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MasteringWpf.DataModels.Interfaces
{
    /// <summary>
    /// Provides the Auditable member that is required to audit changes made to data objects.
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets the Auditable object that provides members required to audit changes made to data objects.
        /// </summary>
        Auditable Auditable { get; set; }
    }
}
