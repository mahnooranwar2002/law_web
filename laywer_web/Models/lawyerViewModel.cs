namespace laywer_web.Models
{
    public class lawyerViewModel
    {
     public  List <admindetail> myadmin { get; set; }
        public  admindetail editedadmin { get; set; }
       public  List<lawyersdetail> lawyersdetails { get; set; }

        public lawyersdetail lawyersdetail { get; set; } // Ensure this is not a List<lawyersdetail>

        public List<contact> user_Contact { get; set; }
 
        public List<user> user_detail { get; set; }
        public user user_data { get; set; }
        public mycities mycities { get; set; }
        public List<bookeduser> get_appointments { get; set; }
        public List<mycities> showCities { get; set; }

        public List <mycountries> countriesName { get; set; }
        public mycountries editedcountries { get; set; }
        public List <bookeduser> get_appoiment { get; set; }
    
    }
}
