
using laywer_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;


namespace laywer_web.controllers
{
    public class Admin : Controller
    {

        private readonly mycontext _context;
        private IWebHostEnvironment _env;
        public Admin(mycontext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult mypage()
        {

            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { myadmin = adminRecords };
                var admin = _context.tbl_admindetails.Count();
                ViewBag.admin = admin;
                var lawyer = _context.tbL_lawyersdetail.Count();
                ViewBag.lawyer = lawyer;
                var user = _context.tbl_user.Count();
                ViewBag.user = user;
                var contact = _context.tbl_contact.Count();
                ViewBag.contact = contact;
               /* var countries = _context.tbl_mycountrry.Count();
                ViewBag.countries = countries;*/
                var appointments = _context.tbl_bokedappointment.Count();
                ViewBag.appoitment = appointments;

                return View(mydata);

            }
            else
            {
                return RedirectToAction("adminlogin");
            }
        }
        /*to view the login form for admin*/


        public IActionResult adminlogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult adminlogin(string adminEmail,string adminPassword)
        {
           
            var admindata = _context.tbl_admindetails.FirstOrDefault(e => e.admin_email==adminEmail);
            if (admindata != null && admindata.admin_password==adminPassword)
            {
                HttpContext.Session.SetString("admin_session", admindata.admin_id.ToString());
                return RedirectToAction("mypage");


            }
            else
            {
            
                TempData["alertmassage"] = "email or password is incorrected";
                return RedirectToAction("adminlogin");
            }
        }
        /*index page*/
        public IActionResult index()
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { myadmin = adminRecords };



                return View(mydata);

            }


            else
            {
                return RedirectToAction("adminlogin");
            }



        }


        [HttpPost]
        public IActionResult Index(IFormFile Lawyer_image, lawyersdetail lawyers, string lawyer_name)
        {

            /*to get the name of the lawyer*/
            string lawywerName = lawyers.lawyer_name;

            /*to get the extension of the file*/
            string fileExtension = Path.GetExtension(Lawyer_image.FileName);
          
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {
                if (fileExtension == ".jpg" || fileExtension==".png" ||fileExtension==".jpeg")
                {
                    string FileName = Path.GetFileName(Lawyer_image.FileName);

                    string directorypath = Path.Combine(_env.WebRootPath, "userimages", FileName);

                       
                        FileStream fs = new FileStream(directorypath, FileMode.Create);
                        Lawyer_image.CopyTo(fs);

                        /*to send the data in the Database*/
                        lawyers.Lawyer_image = FileName;
                        _context.tbL_lawyersdetail.Add(lawyers);
                        _context.SaveChanges();
                        TempData["laywerdetails"] = "lawyer has been added sucessfully ";
                    
                }
                else
                {
                    TempData["pictureError"] = "this file is not supported ";

                }



                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { myadmin = adminRecords };



                return View(mydata);

            }

            return View();

        }
        /*to fetch the details of lawyers */



        public IActionResult lawyerdetails()
        {

            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var lawyerData = _context.tbL_lawyersdetail.ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    lawyersdetails = lawyerData,
                };

                return View(mydata);






            }
            else
            {
                return RedirectToAction("adminlogin");
            }


        }


        /*to sreach tha data*/
        [HttpGet]

        public IActionResult lawyerdetails(string search_text)
        {

            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {


                /*we create the object with the help of model*/
                List<lawyersdetail> lawyerData = new List<lawyersdetail>();
                if (string.IsNullOrEmpty(search_text))
                {
                    lawyerData = _context.tbL_lawyersdetail.ToList();



                }

                else
                {
                    lawyerData = _context.tbL_lawyersdetail.FromSqlInterpolated(

                   $"select * from tbl_lawyersdetail where lawyer_name like '%' +  {search_text} + '%' or lawyer_dealed like '%' +{search_text} + '%'").
                   ToList();



                }
                if (lawyerData.Count == 0)
                {
                    TempData["error"] = $"record not found {search_text} ";

                }

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    lawyersdetails = lawyerData,
                };
                return View(mydata);




            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }
        public IActionResult lawyers_profile(int id)
        {

            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var lawyerData = _context.tbL_lawyersdetail.Find(id);
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    lawyersdetail = lawyerData,
                };

                return View(mydata);






            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }

        /*TO delete the spefic lawyer*/
        public IActionResult deletelawyer(int id)

        {

            var del = _context.tbL_lawyersdetail.Find(id);
            string file = del.Lawyer_image;
            string directorypath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/userimages",file);
            if (System.IO.File.Exists(directorypath))
            {
                System.IO.File.Delete(directorypath);

            }
            _context.tbL_lawyersdetail.Remove(del);
            _context.SaveChanges();
            return RedirectToAction("lawyerdetails");
        }
        /*to edit the spefic the laywer*/
        /*public IActionResult editlawyers(int id)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)

            {
                
                
                var adminRecords = _context.tbl_admin.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var findid = _context.tbL_lawyersdetail.Find(id.ToString());
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                  lawyersdetails = findid,
                };
              
                

                return View(mydata);




            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }*/
        public IActionResult editlawyers(int id)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var find_id = _context.tbL_lawyersdetail.Find(id);



                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    lawyersdetail = find_id,

                };

                return View(mydata);
            }
            else
            {
                return RedirectToAction("adminlogin");
            }
        }

        /*is pr kam krna hai*/
        [HttpPost]
        public IActionResult editlawyers(lawyersdetail law)
        {
            
                          
                 _context.tbL_lawyersdetail.Update(law);
                      _context.SaveChanges();
                    TempData["editedlawyermassage"] = "lawyer is updated successfully.";
                    return RedirectToAction("lawyerdetails");
                
        }
        [HttpPost]
        public IActionResult lawyerpicupdate(IFormFile Lawyer_image, lawyersdetail lawyers)
        {  /*to get the extension of the file*/
            string fileExtension = Path.GetExtension(Lawyer_image.FileName);
            if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
            {
                string FileName = Path.GetFileName(Lawyer_image.FileName);

                string directorypath = Path.Combine(_env.WebRootPath, "userimages", FileName);


                FileStream fs = new FileStream(directorypath, FileMode.Create);
                Lawyer_image.CopyTo(fs);

                /*to send the data in the Database*/
                lawyers.Lawyer_image = FileName;
                _context.tbL_lawyersdetail.Update(lawyers);
                _context.SaveChanges();
              
                return RedirectToAction("lawyerdetails");
            }
            else
            {
                
                return RedirectToAction("lawyerdetails");
            }


        }

        /*to fetech the details of contact*/
        [HttpPost]
        public IActionResult contactdetails(string search_text)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
               /* List<contact> mycons = new List<contact>();
                if (string.IsNullOrEmpty(search_text))
                {
                    mycons = _context.tbl_contact.ToList();

                }
                else
                {
                    mycons = _context.tbl_contact.FromSqlInterpolated($"select * from tbl_contact where user_name like '%'+{search_text}+ '%' ").ToList();
                }

                if (mycons.Count == 0)
                {
                    TempData["error"] = $"not record found for {search_text}";
                }

*/                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var contact_us = _context.tbl_contact.ToList();
                lawyerViewModel data = new lawyerViewModel()
                {user_Contact=contact_us,
                    myadmin = adminRecords,
                   
                };

                return View(data);
            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }

        /*to delete the contact */
        public IActionResult deletecontact(int id)
        {

            var delcont = _context.tbl_contact.Find(id);
            _context.tbl_contact.Remove(delcont);
            _context.SaveChanges();
            return RedirectToAction("contactdetails");
        }

        /*to fetch the data of the user*/
        public IActionResult userdetails()
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)

            {
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var userdata = _context.tbl_user.ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    user_detail = userdata,
                };

                return View(mydata);
            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }
        public IActionResult statuseuser(int id)
        {
            var findid = _context.tbl_user.Find(id);
            if (findid.status == 1)
            {
                findid.status = 0;
                findid.updatedstatus = "deactive";
                _context.SaveChanges();
                RedirectToAction("waitedpage");
            }
            else
            {
                findid.status = 0;
                findid.updatedstatus = "active";
                _context.SaveChanges();
                RedirectToAction("home","laywersdetails");

            }
            return RedirectToAction("userdetails");

        }
        /*sreach funtionality for the user*/
        [HttpGet]
        public IActionResult userdetails(string search_text)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
                List<user> userdata = new List<user>();


                if (string.IsNullOrEmpty(search_text))
                {
                    userdata = _context.tbl_user.ToList();


                }
                else
                {
                    userdata = _context.tbl_user.FromSqlInterpolated(
                 $"select * from tbl_user where user_name like '%' + {search_text} + '%'   or user_email like '%' + {search_text} + '%'").
                 ToList();

                }



                if (userdata.Count == 0)
                {
                    TempData["usererror"] = $"record not found {search_text}";


                }

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    user_detail = userdata,
                };
                return View(mydata);




            }

            else
            {
                return RedirectToAction("adminlogin");
            }


        }


        /*to delete the user*/
        public IActionResult deleteuser(int id)
        {
            var user_data = _context.tbl_user.Find(id);
            _context.tbl_user.Remove(user_data);
            _context.SaveChanges();
            return RedirectToAction("userdetails");
        }
        public IActionResult edituser(int id)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();

                var findid = _context.tbl_user.Find(id);
                lawyerViewModel mydata = new lawyerViewModel()
                {

                    myadmin = adminRecords,
                    user_data = findid
                };



                return View(mydata);
            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }
        [HttpPost]
        public IActionResult edituser(user user)
        {

            _context.tbl_user.Update(user);
            _context.SaveChanges();
            return RedirectToAction("userdetails");
        }

        /*to fetch the details of admin */
        public IActionResult adminProfile()
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {
                var admindata = _context.tbl_admindetails.ToList();
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {

                    myadmin = adminRecords,



                };



                return View(mydata);


            }
            else
            {
                return RedirectToAction("adminlogin");
            }
        }
        public IActionResult myadminedit(int id)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();

                var findid = _context.tbl_admindetails.Find(id);
                lawyerViewModel mydata = new lawyerViewModel()
                {

                    myadmin = adminRecords,
                    editedadmin = findid
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("adminlogin");
            }





        }
        [HttpPost]
        public IActionResult myadminedit(admindetail user)
        {

            _context.tbl_admindetails.Update(user);
            _context.SaveChanges();
            return View("adminprofile");
        }
        /*to add the country*/
        public IActionResult addCountries()
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { myadmin = adminRecords };



                return View(mydata);

            }


            else
            {
                return RedirectToAction("adminlogin");
            }

        }
        [HttpPost]
        public IActionResult addCountries(mycountries mycountry)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {
                var countriedAdded = _context.tbl_mycountrry.Add(mycountry);
                _context.SaveChanges();
                ViewBag.mycountriesadded = "the country has been added sucessfully";


                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { myadmin = adminRecords };



                return View(mydata);

            }


            else
            {
                return RedirectToAction("adminlogin");
            }


        }
        //public IActionResult viewCountry()
        //{
        //    var notlogin = HttpContext.Session.GetString("admin_session");
        //    if (notlogin != null)
        //    {
        //        var countrieView = _context.tbl_mycountrry.ToList();
        //        _context.SaveChanges();
             


        //        var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
        //        lawyerViewModel mydata = new lawyerViewModel()
        //        { myadmin = adminRecords,
        //        countriesName=countrieView
                  
        //        };



        //        return View(mydata);

        //    }
        //    else
        //    {
        //        return RedirectToAction("adminlogin");
        //    }

        //}
        //public IActionResult deletecountry(int id)
        //{
        //    var country_id = _context.tbl_mycountrry.Find(id);
        //    _context.tbl_mycountrry.Remove(country_id);
        //    _context.SaveChanges();
        //    return RedirectToAction("viewCountry");
        //}
      public IActionResult updateCountry(int id)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");

            if (notlogin != null)
            {
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                var find_Id = _context.tbl_mycountrry.Find(id);



                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    editedcountries = find_Id

                };

                return View(mydata);
            }
            else
            {
                return RedirectToAction("adminlogin");
            }

        }
        [HttpPost]
        //public IActionResult updateCountry(mycountries countries)
        //{
        //    _context.tbl_mycountrry.Update(countries);
        //    _context.SaveChanges();
        //    return View("viewCountry");


        //}
        public IActionResult Addcities()
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {

                List<mycountries> Mycounrties=_context.tbl_mycountrry.ToList();
                ViewData["countriesDropdown"]= Mycounrties;
              
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { myadmin = adminRecords,
                countriesName= Mycounrties,
              
                  
                };

               

                return View(mydata);

            }


            else
            {
                return RedirectToAction("adminlogin");
            }

        }
        [HttpPost]
        //public IActionResult Addcities(mycities cities)
        //{
        //    var notlogin = HttpContext.Session.GetString("admin_session");
        //    if (notlogin != null)
        //    {
        //        _context.tbl_mycitiyes.Add(cities);
        //        _context.SaveChanges();

        //        List<mycountries> Mycounrties = _context.tbl_mycountrry.ToList();
        //        ViewData["countriesDropdown"] = Mycounrties;

        //        var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
        //        lawyerViewModel mydata = new lawyerViewModel()
        //        {
        //            myadmin = adminRecords,
        //            countriesName = Mycounrties,


        //        };



        //        return View(mydata);

        //    }


        //    else
        //    {
        //        return RedirectToAction("adminlogin");
        //    }

        //}
        public IActionResult viewCity()
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {
        
             var viewCity = _context.tbl_mycitiyes.Include(p=>p.mycountries).ToList();
                ;

               

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                    showCities= viewCity,


                };



                return View(mydata);

            }


            else
            {
                return RedirectToAction("adminlogin");
            }
        }
        [HttpGet]
        public IActionResult appointment(string search_text)
        {
            var notlogin = HttpContext.Session.GetString("admin_session");
            if (notlogin != null)
            {
                List<bookeduser> appointments = new List<bookeduser>();
                if (string.IsNullOrEmpty(search_text))
                {
                    appointments= _context.tbl_bokedappointment.ToList();
                }
                else{
                    appointments = _context.tbl_bokedappointment.
                        FromSqlInterpolated
                        ($"select * from tbl_bokedappointment where lawyer_name like '%'+ {search_text} +'%' or Booked_username  like '%'+ {search_text} +'%' ").ToList();

                }
                if (appointments.Count == 0)
                {
                    TempData["error"] = $"record not founded {search_text}";
                }



            
                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
                     get_appoiment=appointments,


                };



                return View(mydata);

            }


            else
            {
                return RedirectToAction("adminlogin");
            }
        }

        public IActionResult logout()
        {
             
           HttpContext.Session.Remove("admin_session");
            return RedirectToAction("adminlogin");
        }
        [HttpGet]
        public IActionResult contacts(string sreach_text)
        {
            var login = HttpContext.Session.GetString("admin_session");
            if (login != null)
            {
                List<contact> contact = new List<contact>();
                if (string.IsNullOrEmpty(sreach_text))
                {
                    contact = _context.tbl_contact.ToList();
                }
                else
                {

                    contact = _context.tbl_contact.
                        FromSqlInterpolated
                        ($"select * from tbl_contact where user_name like '%'+ {sreach_text} +'%' or user_email like '%'+ {sreach_text} +'%' ").ToList();
                }
                if (contact.Count == 0)
                {
                    TempData["error"] = $"record not founded {sreach_text}";
                }

                var adminRecords = _context.tbl_admindetails.Where(e => e.admin_id == int.Parse(login)).ToList();
                var getappoiment = _context.tbl_bokedappointment.ToList();
             
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    myadmin = adminRecords,
               user_Contact=contact
    

                };
                return View(mydata);

            }
            else
            {
                return RedirectToAction("adminlogin");
            }
        }
        public IActionResult delete_appointments(int id)
        {
            var find_id = _context.tbl_bokedappointment.Find(id);
            _context.tbl_bokedappointment.Remove(find_id);
            _context.SaveChanges();
            return RedirectToAction("appointment");
        }
    }
}