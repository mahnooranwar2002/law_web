using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class lawyersdetail
    {
        [Key]
        public int lawyer_id { get; set; }
        public string lawyer_name { get; set; }
        public string lawyer_email { get; set; }
        public int lawyer_Number { get; set; }
        public string lawyer_dealed { get; set; }
         public string Lawyer_image { get; set; }
        public string lawyer_password { get; set; }
        public string lawyer_dis { get; set; }

        
    }
}
