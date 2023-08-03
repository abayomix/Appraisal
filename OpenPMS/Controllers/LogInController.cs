using Business_PMS.Abstract;
using Business_PMS.Logics;
using Microsoft.AspNetCore.Mvc;
using Repo_PMS.Models;

namespace OpenPMS.Controllers
{

    public class LogInController : Controller
    {
        IBusiness _Brepo = new Logic_PMS();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login Login, string Btn_click)
        {
            if (!ModelState.IsValid)
            {
                return View(Login);
            }
            else
            {
                user u = _Brepo.validateuser(Login, Btn_click);

                if (u.response == 200)
                {
                    if (u.userid != null)
                    {
                        if (u.IsVAliduser == "True")
                        {
                            HttpContext.Session.SetString("IsUserValid", "True");
                            HttpContext.Session.SetString("uid", u.userid);
                            HttpContext.Session.SetString("EmpID", u.empId);
                            HttpContext.Session.SetString("PwdChgStatus", u.pwdchgstatus);
                            HttpContext.Session.SetString("URole", u.role);
                             HttpContext.Session.SetString("UDeg", u.udeg);
                             HttpContext.Session.SetString("UDept", u.udept);
                            HttpContext.Session.SetString("Utype", u.utype);
                            //var check=HttpContext.Session.GetString("URole");

                            return RedirectToAction("USerRedirection", "LogIn");
                        }
                        else
                        {
                            TempData["Message"] = "InCorrect Password ";
                            return View(Login);
                        }

                    }
                    else
                    {
                        TempData["Message"] = "User Not found You Tried With :" + Btn_click;
                        return View(Login);
                    }
                }
                else
                {
                    TempData["Message"] = "Internal Error Server Not Responded";
                    return View(Login);
                }

            }

        }
        public IActionResult USerRedirection()
        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                string utype = HttpContext.Session.GetString("Utype");
                string changePwdSts = HttpContext.Session.GetString("PwdChgStatus");

                if (utype == "Self")
                {
                    if (changePwdSts == "True")
                    {
                        string getrole = HttpContext.Session.GetString("URole");

                        if (getrole == "Admin" || getrole == "HR")
                        {

                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {

                            return RedirectToAction("Index", "User");
                        }
                    }
                    else
                    {
                        return RedirectToAction("ChangePassword");
                    }
                }

                else
                {
                    string getrole = HttpContext.Session.GetString("URole");

                    if (getrole == "Admin" || getrole == "HR")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }

                }

            }

        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("IsUserValid") == "True")
            {
                string utype = HttpContext.Session.GetString("Utype");

                if (utype == "Self")
                {
                    string uid = HttpContext.Session.GetString("uid");
                    ChangePasswordVM CVM = new ChangePasswordVM();
                    CVM.UserId = uid;

                    return View(CVM);
                }
                else
                {
                    TempData["Message"] = "Change Password Allowed For OPMS Users Only";

                    return RedirectToAction("USerRedirection", "LogIn");
                }

            }
            else
            {
                return RedirectToAction("Login", "LogIn");
            }

        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM CVM)
        {
            string response = _Brepo.Changepassword(CVM);

            if (response == "Sucess")
            {
                HttpContext.Session.SetString("PwdChgStatus", "True");
                TempData["Message"] = "Password Changed Sucessfully";
                return RedirectToAction("USerRedirection", "LogIn");
            }
            else
            {
                return View(CVM);
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "LogIn");

        }

    }
}
