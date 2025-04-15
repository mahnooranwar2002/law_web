using System;
using System.Collections.Generic;

namespace laywer_web.Models;

public partial class TblAdmindetail
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string AdminEmail { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;
}
