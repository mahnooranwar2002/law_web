
using laywer_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NuGet.Protocol.Plugins;
using System.Collections.Generic;

namespace laywer_web.controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                lawyerViewModel mydata = new lawyerViewModel()
                {

                   
                    user_detail = logined

                };
                return View(mydata);

                
            }
            else
            {
                TempData["login"] = "login";
            }

            return View();
        }
        public IActionResult about()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                lawyerViewModel mydata = new lawyerViewModel()
                {


                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }
        public IActionResult service()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                lawyerViewModel mydata = new lawyerViewModel()
                {


                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }
        public IActionResult blog()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                lawyerViewModel mydata = new lawyerViewModel()
                {


                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }
        public IActionResult blogchild()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                lawyerViewModel mydata = new lawyerViewModel()
                {


                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }

        public IActionResult contact()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                lawyerViewModel mydata = new lawyerViewModel()
                {


                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }
        private mycontext _Context;


        public HomeController(mycontext context)
        {
            _Context = context;

        }
        /*for dropdown*/


        [HttpPost]
        public IActionResult contact(contact user)
        {
            _Context.tbl_contact.Add(user);
            _Context.SaveChanges();
            TempData["msg"] = "thankyou for contact us !";
            return View();
        }
        /* for login*/
        public IActionResult user_login()
        {
            return View();
        }


        public IActionResult logineduser()
        {

            var notlogin = HttpContext.Session.GetString("user_session");
            if (string.IsNullOrEmpty(notlogin))
            {


                return View();
            }


            else
            {

                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                { user_detail = logined };

                return View(mydata);

            }


        }
        [HttpPost]
       public IActionResult user_login(string userEmail, string userPassword)
        {
            var data = _Context.tbl_user.FirstOrDefault(e => e.user_email == userEmail);
            if (data != null && data.user_password == userPassword )
            {
                if(data.status == 1)
                {
                    HttpContext.Session.SetString("user_session",data.user_id.ToString());
                    return RedirectToAction("index");
                }
                else
                {
                    return RedirectToAction("waitedPage");

                }
            }
            else
            {
                ViewBag.message = "Incorrect Password";
                TempData["alertmassage"] = "email or password is incorrected";
                return View();
            }


        }
        public IActionResult waitedPage()
        {
            return View();
        }

        /*for register*/
        public IActionResult user_register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult user_register(user userdetails, string user_email)
        {

            _Context.tbl_user.Add(userdetails);
            _Context.SaveChanges();

            return RedirectToAction("user_login");
        }


        /* for log out*/
        public IActionResult logout()
        {
            HttpContext.Session.Remove("user_session");
            return RedirectToAction("index");

        }
       
        public IActionResult laywersdetails(string search_text)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {

                List<lawyersdetail> lawyerData = new List<lawyersdetail>();
                if (string.IsNullOrEmpty(search_text))
                {
                    lawyerData = _Context.tbL_lawyersdetail.ToList();



                }

                else
                {
                    lawyerData = _Context.tbL_lawyersdetail.FromSqlInterpolated(

                   $"select * from tbl_lawyersdetail where lawyer_name like   '%' +{search_text}+ '%' or lawyer_dealed like  '%' +{search_text}+ '%'")
                        .
                   ToList();



                }
                if (lawyerData.Count == 0)
                {
                    TempData["error"] = $"record not found {search_text} ";

                }

                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();
               
                lawyerViewModel mydata = new lawyerViewModel()
                {


                    user_detail = logined,
                    lawyersdetails=lawyerData

                };
                return View(mydata);


            }
            else
            {
                return RedirectToAction("user_login");
            }


    

        }
        /*for sreach the lawyer*/
               /*to sreach tha data*/

        public IActionResult lawyer_profile(int id)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();

                var laywerDetail = _Context.tbL_lawyersdetail.FirstOrDefault(u => u.lawyer_id == id);
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    user_detail = logined,
                    lawyersdetail = laywerDetail,
                };
                return View(mydata);
            }
            else
            {
                return RedirectToAction("user_login");
            }
        }
        public IActionResult get_appoint(int id)
        {
            var notlogined = HttpContext.Session.GetString("user_session");
            if (notlogined != null)
            {TempData["logins"] = "login";
                var laywerDetail = _Context.tbL_lawyersdetail.FirstOrDefault(u => u.lawyer_id == id);
                var logined = _Context.tbl_user.Where
                    (s => s.user_id == int.Parse(notlogined)).ToList();

                

                lawyerViewModel mydata = new lawyerViewModel()
                {

                    lawyersdetail = laywerDetail,
                    user_detail = logined

                };
                TempData["logins"] = "login";
                return View(mydata);


            }

            else
            {
                return RedirectToAction("user_login");
            }
        }

        /*for actual add up*/
        [HttpPost]
        public IActionResult get_appoint(int id, bookeduser get_appoitment)
        {
            var notlogined = HttpContext.Session.GetString("user_session");
            if (notlogined != null)
            {
                _Context.tbl_bokedappointment.Add(get_appoitment);
                _Context.SaveChanges();
                var laywerDetail = _Context.tbL_lawyersdetail.FirstOrDefault(u => u.lawyer_id == id);
                var logined = _Context.tbl_user.Where
                  (s => s.user_id == int.Parse(notlogined)).ToList();
                TempData["msg"] = "Your appointment is booked now";
                lawyerViewModel mydata = new lawyerViewModel()
                {

                    lawyersdetail = laywerDetail,
                    user_detail = logined

                };
                return View(mydata);


            }

            else
            {
                return RedirectToAction("user_login");
            }

        }
        

        [HttpGet]

        public IActionResult view_appoint(string search_text)
        {

            var notlogin = HttpContext.Session.GetString("user_session");

            if (notlogin != null)
            {
                List<bookeduser> lawyerData = new List<bookeduser>();
                if (string.IsNullOrEmpty(search_text))
                {

                }

                else
                {
                    lawyerData = _Context.tbl_bokedappointment.FromSqlInterpolated(

                   $"select * from  tbl_bokedappointment where booked_username like '%'+ {search_text} +'%' or Booked_useremail like '%'+ {search_text} +'%'")
                        .
                   ToList();


                }
                if (lawyerData.Count == 0)
                {
                    TempData["error"] = $" Any record does  not found {search_text} ";

                }





                TempData["logins"] = "login";

                var adminRecords = _Context.tbl_user.Where(e => e.user_id == int.Parse(notlogin)).ToList();
                lawyerViewModel mydata = new lawyerViewModel()
                {get_appointments=lawyerData,
                    user_detail = adminRecords,
                   
                };
                return View(mydata);




            }
            else
            {
                return RedirectToAction("user_login");
            }

        }
        public IActionResult user_profile(int id)
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();
                var datas = _Context.tbl_user.Find(id);
                lawyerViewModel mydata = new lawyerViewModel()
                {
                    user_data=datas,

                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }
        [HttpPost]
        public IActionResult user_profile(user myuser)
        {
            _Context.tbl_user.Update(myuser);
            _Context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult cancel_appointment(int id)
        {
            var find = _Context.tbl_bokedappointment.Find(id);
            _Context.tbl_bokedappointment.Remove(find);
            _Context.SaveChanges();
            return RedirectToAction("view_appoint");
        }
        public IActionResult user_appointments()
        {
            var login = HttpContext.Session.GetString("user_session");
            if (login != null)
            {
                TempData["logins"] = "login";
                var logined = _Context.tbl_user.Where(s => s.user_id == int.Parse(login)).ToList();
             
                lawyerViewModel mydata = new lawyerViewModel()
                {
                  

                    user_detail = logined

                };
                return View(mydata);


            }
            else
            {
                TempData["login"] = "login";
            }
            return View();
        }

    }


}
