using Microsoft.EntityFrameworkCore;

namespace laywer_web.Models
{
    public class mycontext : DbContext
    {
        /*we create the contruction function*/
        public mycontext(DbContextOptions<mycontext> options) : base(options)
        {

        }
        /* to create the table using the property */
        /* tbl lawyer*/
        public DbSet<laywer> tbl_lawyers { get; set; }

        /*tbl contact*/
        public DbSet<contact> tbl_contact { get; set; }

        /*user table*/
        public DbSet<user> tbl_user { get; set; }

        public DbSet<adminlogin> tbl_admin { get; set; }
        public DbSet<lawyersdetail> tbL_lawyersdetail { get; set; }
        public DbSet<admindetail> tbl_admindetails { get; set; }
        public DbSet<mycities> tbl_mycitiyes { get; set; }
        public DbSet<mycountries> tbl_mycountrry { get; set; }
        public DbSet<bookeduser> tbl_bokedappointment { get; set; }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mycities>().
                HasOne(p => p.mycountries).
                WithMany(c => c.cites).
                HasForeignKey(p => p.coun_id);
             
            /*for foreign key for  userbooked country*/
         

            /*for foreign key for  userbooked city*/
          /*  modelBuilder.Entity<bookeduser>().HasOne(o => o.cities_foreign).WithMany(m => m.bookeduserlist_cities).
               HasForeignKey(e => e.cities_idfk);*/

        }



    }
}
