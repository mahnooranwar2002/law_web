using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class admindetail
    {
        [Key]
        public int admin_id { get; set; }


        public string admin_name { get; set; }
        public string admin_email { get; set; }
        public string admin_password { get; set; }
        
    }
}
