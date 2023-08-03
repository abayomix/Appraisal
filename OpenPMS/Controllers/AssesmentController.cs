using Business_PMS.Logics;
using Microsoft.AspNetCore.Mvc;
using Business_PMS.Abstract;
using Repo_PMS.Models;
using System.Text;

namespace OpenPMS.Controllers
{
    public class AssesmentController : Controller
    {
        IAssesmentBussiness _IAssBuss = new AssesmentLogicBL();

        [HttpGet]
        public IActionResult AddQuestion()
        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                VMAssesmentQuestion AQ = new VMAssesmentQuestion();

                AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();

                return View(AQ);
            }



           
        }


        [HttpPost]
        public IActionResult AddQuestion(VMAssesmentQuestion AQ)
        {
            string Response;

            if (ModelState.IsValid)
            {
                Response = _IAssBuss.AddAssesmentQuestion(AQ.Question);

                if (Response == "Question Added SucessFully")
                {
                    TempData["Message"] = "Question Added Successfully";

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                    AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();
                    TempData["Message"] = Response;
                    return View(AQ);
                }


            }
            else
            {
                AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();
                TempData["Message"] = "All Fields are required";
                return View(AQ);
            }
            
        }


        [HttpGet]
        public IActionResult ViewAllQuestions()
        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                VMAssesmentQuestion AQ = new VMAssesmentQuestion();

                AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();
                AQ.questions = _IAssBuss.GetAllQuestions();

                return View(AQ);
            }




        }



        [HttpGet]
        public IActionResult EditQuestion(string id)
        {
            if (HttpContext.Session.GetString("IsUserValid") != "True")
            {
                return RedirectToAction("Login", "LogIn");
            }
            else
            {
                VMAssesmentQuestion AQ = new VMAssesmentQuestion();
                AQ.Question = _IAssBuss.GetQuestionData(id);
                AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();

                return View(AQ);
            }




        }


        [HttpPost]
        public IActionResult EditQuestion(VMAssesmentQuestion AQ)
        {
            string Response;

            if (ModelState.IsValid)
            {
                Response = _IAssBuss.updateQuestion(AQ.Question);

                if (Response == "Sucess")
                {
                    TempData["Message"] = "Question Updated Successfully";

                    return RedirectToAction("ViewAllQuestions", "Assesment");
                }
                else
                {
                    AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                    AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();
                    TempData["Message"] = Response;
                    return View(AQ);
                }


            }
            else
            {
                AQ.DepartmentList = _IAssBuss.GetDepartmentsforDL();
                AQ.DeginationsList = _IAssBuss.GetDeginationsForDL();
                TempData["Message"] = "All Fields are required";
                return View(AQ);
            }

        }


        [HttpGet]
        public IActionResult DeleteQuestion(string id)
        {
            string Response;

          
                Question q = _IAssBuss.GetQuestionData(id);
            Response = _IAssBuss.DeleteQuestion(q);

                if (Response == "Sucess")
                {
                    TempData["Message"] = "Question Deleted Successfully";

                    return RedirectToAction("ViewAllQuestions", "Assesment");
                }
                else
                {
                TempData["Message"] = "Question Not Deleted Due To Error";

                return RedirectToAction("ViewAllQuestions", "Assesment");
               
                }


            }


   


        [HttpGet]
        public IActionResult setassementQuestion()
        {
            VMsetassesmentQuestion VMAQ = new VMsetassesmentQuestion();

            VMAQ.lstAssements = _IAssBuss.getassestmentfordl();
            VMAQ.deginations = _IAssBuss.GetDegination();
            VMAQ.departments = _IAssBuss.GetDepartmentsforDL();


            return View(VMAQ);
        }


        [HttpPost]

            
        public IActionResult setassementQuestion(VMsetassesmentQuestion VMAQ)
        {
            string response;

            if(VMAQ.Questionset.Dept!=0 && VMAQ.Questionset.Deg != 0)
            {

                StringBuilder sb = new StringBuilder();
                if (VMAQ.questions != null)
                {
                    foreach (var question in VMAQ.questions)
                    {
                        if (question.selected == true)
                        {
                            if (sb.Length == 0)
                            {

                                sb.Append(question.Qid.ToString());
                            }
                            else
                            {
                                sb.Append("," + question.Qid.ToString());
                            }
                        }
                        else
                        {
                            continue;
                        }

                    }
                }
                if (sb.Length > 0)
                {
                    VMAQ.Questionset.QuestionID=sb.ToString();
                    response = _IAssBuss.AddAssesmentQuestion(VMAQ.Questionset);

                    if (response == "Success")
                    {
                        TempData["Message"] = "Questions Set Successfully Added to Assesment";
                        return RedirectToAction("setassementQuestion");
                    }
                    else
                    {
                        TempData["Message"] = "Questions Set not Added to Assesment Due To Some Error";
                        return RedirectToAction("setassementQuestion");
                    }
                    
                }
                else
                {

                    VMAQ.lstAssements = _IAssBuss.getassestmentfordl();
                    VMAQ.deginations = _IAssBuss.GetDegination();
                    VMAQ.departments = _IAssBuss.GetDepartmentsforDL();
                    VMAQ.questions = _IAssBuss.getassesmentquestions(VMAQ.Questionset.Dept, VMAQ.Questionset.Deg);

                    return View(VMAQ);


                }

            }
            else
            {
                VMAQ.lstAssements = _IAssBuss.getassestmentfordl();
                VMAQ.deginations = _IAssBuss.GetDegination();
                VMAQ.departments = _IAssBuss.GetDepartmentsforDL();
                return View(VMAQ);
            }
            
            
            
           

           
            }


        [HttpGet]
        public IActionResult Assesments()
        {
            //VMrecordAssesment VMRA = new VMrecordAssesment();

            List<assesment> lstasses = _IAssBuss.GetAssesments();
            //VMRA.assesments = _IAssBuss.GetAssesments();


            return View(lstasses);
        }

        [HttpGet]
        [HttpPost]
        public IActionResult GiveAssesment(string EMPID, string ASID, string AssesmentName)
        {
            int noQ;
            int QN;
            string empname;

            VMrecordAssesment VMRA = new VMrecordAssesment();

            VMRA.Question = _IAssBuss.getAssesmentQuestion(EMPID,Convert.ToInt32( ASID), out noQ, out QN,out empname);

            if(VMRA.Question.Question_Text != null)
            {

                VMRA.NumberOfQuestion = noQ;
                VMRA.QuestionNo = QN;
                VMRA.EMPNAme = empname;
                VMRA.AssesmentName = AssesmentName;
                VMRA.EMPID = EMPID;
                VMRA.ASID = Convert.ToInt32(ASID);


                return View(VMRA);
            }
            else
            {
                TempData["Message"] = "All Questions Attempted For this Assesment";

                return RedirectToAction("Assesments");
            }




        }

        [HttpPost]
        public IActionResult SaveAssesmentResponse(VMrecordAssesment VMRA)
        {
            VMRA.AR.AssementID = VMRA.ASID;
            VMRA.AR.Empid = VMRA.EMPID;
           

            string response = _IAssBuss.saveassesmentrespons(VMRA.AR);

            if (response == "Success")
            {
                if(VMRA.NumberOfQuestion == VMRA.QuestionNo)
                {
                    TempData["Message"] = "Thank you For Seeking Assement";

                    return RedirectToAction("Assesments");
                }
                else
                {

                    
                    return RedirectToAction("GiveAssesment", new { EMPID=VMRA.EMPID , ASID=VMRA.ASID , AssesmentName=VMRA.AssesmentName });
                }

            }

            else
            {
                TempData["Message"] = "Response";
                return RedirectToAction("GiveAssesment", new { EMPID = VMRA.EMPID, ASID = VMRA.ASID, AssesmentName = VMRA.AssesmentName });
            }


            


        }





    }


        






    }

