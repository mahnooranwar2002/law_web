using System;
using System.Collections.Generic;

namespace laywer_web.Models;

public partial class TblCity
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public int? CountryId { get; set; }

    public virtual TblCountry? Country { get; set; }
}
