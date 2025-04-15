using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class mycountries
    {
        [Key]
        public int country_id { get; set; }
        public string country_name { get; set; }
        public List<mycities> cites { get; set; }
         


    }
}
