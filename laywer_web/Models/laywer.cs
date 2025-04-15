using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class laywer

    {
        [Key]
        public int lawyer_id { get; set; }
        public string lawyer_name { get; set; }
        public string lawyer_email { get; set; }

        public string lawyer_password { get; set; }
    }
}
