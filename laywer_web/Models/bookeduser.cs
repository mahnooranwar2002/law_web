using System.ComponentModel.DataAnnotations;

namespace laywer_web.Models
{
    public class bookeduser
    {
        [Key]
        public int Booked_id { get; set; }
        public string lawyer_name { get; set; }
        public int lawyer_id { get; set; }
        public string Booked_username { get; set; }
        public string Booked_useremail { get; set; }
        public int Booked_usernumber { get; set; }
        public string slot_time { get; set; }

        public int status { get; set; } = 0;
        [Required]
        public string status_updates { get; set; } = "pending";
    }


}
