using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class user
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
        public int status { get; set; } = 1;
        public string updatedstatus { get; set; } = "active";
    }
}
