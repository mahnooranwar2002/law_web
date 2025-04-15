using System;
using System.Collections.Generic;

namespace laywer_web.Models;

public partial class TblLawyer
{
    public int LawyerId { get; set; }

    public string LawyerName { get; set; } = null!;

    public string LawyerEmail { get; set; } = null!;

    public string LawyerPassword { get; set; } = null!;
}
