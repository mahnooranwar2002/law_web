using System;
using System.Collections.Generic;

namespace laywer_web.Models;

public partial class TbLLawyersdetail
{
    public int LawyerId { get; set; }

    public string LawyerName { get; set; } = null!;

    public string LawyerEmail { get; set; } = null!;

    public int LawyerNumber { get; set; }

    public string LawyerDealed { get; set; } = null!;

    public string LawyerImage { get; set; } = null!;

    public string LawyerPassword { get; set; } = null!;
}
