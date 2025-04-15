using System;
using System.Collections.Generic;

namespace laywer_web.Models;

public partial class TblContact
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserSub { get; set; } = null!;

    public string UserMsg { get; set; } = null!;
}
