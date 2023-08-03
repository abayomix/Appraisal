using Business_PMS.Abstract;
using Business_PMS.Logics;
using Microsoft.AspNetCore.Mvc;
using Repo_PMS.Abstract;
using Repo_PMS.Models;
using Repo_PMS.Repository;

namespace OpenPMS.Controllers
{
    public class AdminController : Controller
    {
        IBusiness _Brepo = new Logic_PMS();

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                UserRegistrationVM URVM = new UserRegistrationVM();

                URVM.LstRoles = _Brepo.GetAllRoles();
                URVM.Departments = _Brepo.GetDepts();
                URVM.Deginations = _Brepo.GetDegination();
                URVM.users = _Brepo.GetUserForDL();

                return View(URVM);
            }
            

        }

        [HttpPost]
        public IActionResult CreateUser(UserRegistrationVM URVM,string btn_click)
        {
            URVM.LstRoles = _Brepo.GetAllRoles();
            URVM.Departments = _Brepo.GetDepts();
            URVM.Deginations = _Brepo.GetDegination();
            URVM.users = _Brepo.GetUserForDL();

            if (ModelState.IsValid)
            {

                string response = _Brepo.AddUser(URVM.UserDetail, btn_click);

                if (response == "Success")
                {
                    TempData["Message"] = "User Added Successfully";

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Message"] = response;
                    return View(URVM);
                }


            }


            TempData["Message"] = "Please Fill All Reqired Field";

            return View(URVM);

        }

        [HttpGet]
        public IActionResult AddRole()
        
        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else 
            {
            
            return View();
            }
        }
        [HttpPost]
       public IActionResult AddRole(RoleDetail role)
        {
            if (ModelState.IsValid)
            {

                string response = _Brepo.addrole(role);

                if (response == "Success")
                {
                    TempData["Message"] = "User Added Successfully";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Message"] = response;
                    return View(role);
                }

            }
            TempData["Message"] = "Please Fill All Reqired Field";
            return View(role);
        }


        public IActionResult addDept()

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {

                return View();
            }
        }
        [HttpPost]
        public IActionResult addDept(Department dept)
        {
            if (ModelState.IsValid)
            {

                string response = _Brepo.AddDept(dept);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Department Added Successfully";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Message"] = Response;
                    return View(dept);
                }

            }
           
            TempData["Message"] = "Please Fill All Reqired Field";
            return View(dept);
}



        public IActionResult AddDegination()

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {

                return View();
            }
        }
        [HttpPost]
        public IActionResult AddDegination(Degination deg)
        {
            if (ModelState.IsValid)
            {

                string response = _Brepo.AddDegination(deg);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Degination Added Successfully";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Message"] = Response;
                    return View(deg);
                }

            }

            TempData["Message"] = "Please Fill All Reqired Field";
            return View(deg);
        }


        public IActionResult AddAssesment()

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                VMassesment ObjAssesment = new VMassesment();

                ObjAssesment.assesments = _Brepo.GetAllAssesment();

                return View(ObjAssesment);
            }
        }
        [HttpPost]
        public IActionResult AddAssesment(VMassesment ObjAssesment)

        {
            if (ModelState.IsValid)
            {
                ObjAssesment.assesments = _Brepo.GetAllAssesment();
                string response = _Brepo.AddAssesment(ObjAssesment.assesment);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Assesment Added Successfully";
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData ["Message"] = response;
                    return View(ObjAssesment);
                }
            }
            TempData["Message"] = "Please Fill All Reqired Field";
            return View(ObjAssesment);
        }


        public IActionResult Addreview()

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                VMReview objreview = new VMReview();

                objreview.lstReviews = _Brepo.GetAllReviews();

                return View(objreview);
            }
        }
        [HttpPost]
        public IActionResult Addreview(VMReview objreview)

        {
            if (ModelState.IsValid)
            {
                objreview.lstReviews = _Brepo.GetAllReviews();
                string response = _Brepo.AddReview(objreview.review);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Review Added Successfully";
                    return RedirectToAction("Addreview", "Admin");
                }
                else
                {
                    TempData["Message"] = response;
                    return View(objreview);
                }
            }
            TempData["Message"] = "Please Fill All Reqired Field";
            return View(objreview);
        }



        public IActionResult EditReview(string id)

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                VMReview objreview = new VMReview();

                objreview.review = _Brepo.GetReviewData(id);
               

                return View(objreview);
            }
        }
        [HttpPost]
        public IActionResult EditReview(VMReview objreview)

        {
            if (ModelState.IsValid)
            {
                objreview.lstReviews = _Brepo.GetAllReviews();
                string response = _Brepo.updateReview(objreview.review);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Review Updated Successfully";
                    return RedirectToAction("Addreview", "Admin");
                }
                else
                {
                    TempData["Message"] = response;
                    return View(objreview);
                }
            }
            
            TempData["Message"] = "Please Fill All Reqired Field";
            return View(objreview);
        }



        public IActionResult deletereview(string id)

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                Review review = _Brepo.GetReviewData(id);

                string response = _Brepo.DeleteReview(review);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Review Deleted Successfully";
                    return RedirectToAction("Addreview", "Admin");
                }
                else
                {
                    TempData["Message"] = "Oops Review Not Deleted Some Error Occurred";
                    return RedirectToAction("Addreview", "Admin");
                }

            }
        }


        public IActionResult actdeactreview(string id)

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                

                string response = _Brepo.ActDeactReview(id);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Review Activated/Deactivated Successfully";
                    return RedirectToAction("Addreview", "Admin");
                }
                else
                {
                    TempData["Message"] = "Oops  Error Occurred";
                    return RedirectToAction("Addreview", "Admin");
                }

            }
        }




        public IActionResult EditAssesment(string id)

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                VMassesment ObjAssesment = new VMassesment();

                ObjAssesment.assesment = _Brepo.GetAssesmentData(id);


                return View(ObjAssesment);
            }
        }
        [HttpPost]
        public IActionResult EditAssesment(VMassesment ObjAssesment)

        {
            if (ModelState.IsValid)
            {
                ObjAssesment.assesments = _Brepo.GetAllAssesment();
                string response = _Brepo.updateAssesment(ObjAssesment.assesment);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Assement Updated Successfully";
                    return RedirectToAction("AddAssesment", "Admin");
                }
                else
                {
                    TempData["Message"] = response;
                    return View(ObjAssesment);
                }
            }

            TempData["Message"] = "Please Fill All Reqired Field";
            return View(ObjAssesment);
        }



        public IActionResult DeleteAssesment(string id)

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {
                assesment assesment = _Brepo.GetAssesmentData(id);

                string response = _Brepo.DeleteAssesment(assesment);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Assesment Deleted Successfully";
                    return RedirectToAction("AddAssesment", "Admin");
                }
                else
                {
                    TempData["Message"] = "Oops Review Not Deleted Some Error Occurred";
                    return RedirectToAction("AddAssesment", "Admin");
                }

            }
        }


        public IActionResult actdeactAssesment(string id)

        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }

            else
            {


                string response = _Brepo.ActDeactAssement(id);

                if (response == "Sucess")
                {
                    TempData["Message"] = "Assesment Activated/Deactivated Successfully";
                    return RedirectToAction("AddAssesment", "Admin");
                }
                else
                {
                    TempData["Message"] = "Oops  Error Occurred";
                    return RedirectToAction("AddAssesment", "Admin");
                }

            }
        }

        [HttpGet]
        public IActionResult ViewScore()
        {
            VMScoreboard VMS= new VMScoreboard();

            VMS.lstdepartment = _Brepo.GetDepts();
            VMS.lstdepartment.Add(new Department { Id = 0, DeptName = "All", CreateDate = DateTime.Now, CreatedBy = "System", DeptDescription = null });

            VMS.LstDegination=_Brepo.GetDegination();
            VMS.LstDegination.Add(new Degination { Id = 0, DeginationName = "All", CreateDate = DateTime.Now, CreatedBy = "System", D_Description = null });

            VMS.LstScoreCards = _Brepo.ShowFinalScoreV2(0, 0, "2023");

            return View(VMS);
        }
        public IActionResult ViewScore(VMScoreboard VMS)
        {
            

            VMS.lstdepartment = _Brepo.GetDepts();
            VMS.lstdepartment.Add(new Department { Id = 0, DeptName = "All", CreateDate = DateTime.Now, CreatedBy = "System", DeptDescription = null });

            VMS.LstDegination = _Brepo.GetDegination();
            VMS.LstDegination.Add(new Degination { Id = 0, DeginationName = "All", CreateDate = DateTime.Now, CreatedBy = "System", D_Description = null });

            VMS.LstScoreCards = _Brepo.ShowFinalScoreV2(VMS.DeptID, VMS.Degination, VMS.year);

            return View(VMS);
        }






    }
}
