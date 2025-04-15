using laywer_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace laywer_web.controllers
{
    public class LawyersController : Controller
    {
        private mycontext contexts;
        private IWebHostEnvironment env;
        public LawyersController(mycontext context,IWebHostEnvironment _env)
        {
            env = _env;
            contexts = context;
        }
        public IActionResult Index()
        {
            var notlogined = HttpContext.Session.GetString("lawyer_session");
            if(notlogined!= null)
            {
                var Lawyer_Records = contexts.tbL_lawyersdetail.Where(e => e.lawyer_id == int.
                Parse(notlogined)).ToList();
                var counted_appointment = contexts.tbl_bokedappointment.
               Where(law => law.lawyer_id == int.Parse(notlogined)).Count();
                ViewBag.countappointment = counted_appointment;
                lawyerViewModel lawyer_data = new lawyerViewModel()
                { lawyersdetails = Lawyer_Records };

                return View(lawyer_data);
            }
            else
            {
                return RedirectToAction("loginfrom_lawyer");
            }
           
        }
        /*lawyer_profile*/
        public IActionResult lawyerProfile(int id)
        {
            var notlogined = HttpContext.Session.GetString("lawyer_session");
            if (notlogined != null)
            {
                var lawyerdata =contexts.tbL_lawyersdetail.Find(id);
              
                var Lawyer_Records = contexts.tbL_lawyersdetail.Where(e => e.lawyer_id == int.
                Parse(notlogined)).ToList();
                lawyerViewModel lawyer_data = new lawyerViewModel()
                { lawyersdetails = Lawyer_Records,
                lawyersdetail=lawyerdata
                };

                return View(lawyer_data);


            }
            else
            {
                return RedirectToAction("loginfrom_lawyer");
            }
           
        }
        [HttpPost]
        public IActionResult lawyerProfile(lawyersdetail law)
        {
            contexts.tbL_lawyersdetail.Update(law);
            contexts.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult lawyerpicupdate(IFormFile Lawyer_image,lawyersdetail my_law)
        {
            string fileExtension = Path.GetExtension(Lawyer_image.FileName);
            if(fileExtension == ".jpg" ||fileExtension==".png" || fileExtension== ".jpeg")
            {
                string filename = Path.GetFileName(Lawyer_image.FileName);
                string filepath = Path.Combine(env.WebRootPath, "userimages", filename);
                FileStream fs = new FileStream(filepath,FileMode.Create);
                Lawyer_image.CopyTo(fs);
                my_law.Lawyer_image = filename;
                contexts.tbL_lawyersdetail.Update(my_law);
                contexts.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return RedirectToAction("index");
            }
        }
        public IActionResult loginfrom_lawyer()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult loginfrom_lawyer(string lawyerEmail, string lawyerPassword)
        {
            var lawyerdetails = contexts.tbL_lawyersdetail.FirstOrDefault(law => law.lawyer_email == lawyerEmail);
             if(lawyerdetails!= null && lawyerdetails.lawyer_password==lawyerPassword)
            {
                HttpContext.Session.SetString("lawyer_session",lawyerdetails.lawyer_id.ToString());
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.errormsg = "inccorected password or email";
                return View();
            }

             

        }
        public IActionResult appoitmentDetails(string search_text)
        {
            var notlogined = HttpContext.Session.GetString("lawyer_session");
            if (notlogined != null)
            {
                var lawyerId = int.Parse(notlogined);
                List<bookeduser> mybooking = new List<bookeduser>();
                if (string.IsNullOrEmpty(search_text))
                {
                    mybooking = contexts.tbl_bokedappointment.Where(la=>la.lawyer_id==int.Parse(notlogined)).ToList();
                }
                else
                {
                    mybooking = contexts.tbl_bokedappointment.
                         FromSqlInterpolated

                         ($"select * from tbl_bokedappointment where lawyer_id={lawyerId}  and  Booked_useremail like '%'+ {search_text} +'%' or Booked_username  like '%'+ {search_text} +'%' ").ToList();

                }
                if (mybooking.Count == 0)
                {
                    TempData["error"] = $"record not founded {search_text}";

                }


                var Lawyer_Records = contexts.tbL_lawyersdetail.Where(e => e.lawyer_id == int.
                Parse(notlogined)).ToList();
                var appointment_booked = contexts.tbl_bokedappointment.
             Where(law => law.lawyer_id == int.Parse(notlogined)).ToList();

                lawyerViewModel lawyer_data = new lawyerViewModel()
                { lawyersdetails = Lawyer_Records,
                 get_appointments = mybooking
                };

                return View(lawyer_data);
            }
            else
            {
                return RedirectToAction("loginfrom_lawyer");
            }

        }

        public IActionResult delete_appoitment(int id)
        {
            var del_id = contexts.tbl_bokedappointment.Find(id);
            contexts.tbl_bokedappointment.Remove(del_id);
            contexts.SaveChanges();
            return RedirectToAction("appoitmentDetails");
        }
        public IActionResult status_appoitment(int id)
        {
             
            var findid = contexts.tbl_bokedappointment.Find(id);
            if (findid.status == 0)
            {
                findid.status = 1;
                findid.status_updates = "approved";
               

            }
            else
            {
                findid.status = 0;
                findid.status_updates = "pending";

            }
            contexts.SaveChanges();

            return RedirectToAction("appoitmentDetails");
        }
    }
}
