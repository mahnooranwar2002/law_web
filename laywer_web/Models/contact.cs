using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class contact
    {
        [Key]
        public int user_id { get; set; }

        public string user_name { get; set; }

        public string user_email { get; set; }
        public string user_sub { get; set; }
        public string user_msg { get; set; }
    }
}
