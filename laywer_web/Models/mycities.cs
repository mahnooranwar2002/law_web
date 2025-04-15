using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace laywer_web.Models
{
    public class mycities
    {
        [Key]
        public int city_id { get; set; }
       public string city_name { get; set; }
        public int coun_id { get; set; }
        public mycountries mycountries { get;set; }
     

    }
}
