using System;
using System.Collections.Generic;

namespace laywer_web.Models;

public partial class TblCountry
{
    public int CId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<TblCity> TblCities { get; set; } = new List<TblCity>();
}
