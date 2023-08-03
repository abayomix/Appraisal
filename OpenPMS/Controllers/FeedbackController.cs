using Business_PMS.Abstract;
using Business_PMS.Logics;
using Microsoft.AspNetCore.Mvc;
using Repo_PMS.Models;

namespace OpenPMS.Controllers
{
    public class FeedbackController : Controller
    {
        IFeedbackBussiness _IFB = new FeedBackBL();

        [HttpGet]
        public IActionResult AddFeedbackQuestion()
        {
            VMFeedback VMfb = new VMFeedback();

            VMfb.LstQuestions=_IFB.GetFeedbackQuestions();


            return View(VMfb);
        }


        [HttpPost]
        public IActionResult AddFeedbackQuestion(VMFeedback VMfb)
        {

           
            VMfb.LstQuestions = _IFB.GetFeedbackQuestions();

            if (ModelState.IsValid)
            {
                string response = _IFB.AddfeedbackQuestion(VMfb.Question);

                if (response == "Success")
                {
                    TempData["Message"] = "Question Added Sucess";
                    return RedirectToAction("AddFeedbackQuestion");

                }
                else
                {
                    TempData["Message"] = response;
                    return View(VMfb);
                }

            }

            else
            {
                TempData["Message"] = "All Fileds Mandatory !";
                return View(VMfb);
            }


            
        }

        [HttpGet]
        public IActionResult deleteQuestion(string id)
        {

            string response = _IFB.DeleteFeedBackQuestion(id);

            if (response == "Success")
            {
                TempData["Message"] = "Question Deleted Success";
                return RedirectToAction("AddFeedbackQuestion");

            }
            else
            {
                TempData["Message"] = "Question Not Deleted Due To Error";
                return RedirectToAction("AddFeedbackQuestion");
            }
        }


        [HttpGet]
        public IActionResult UpdateQuestion(string id)
        {
            VMFeedback VMfb = new VMFeedback();

            VMfb.Question = _IFB.getQuestionData(id);

            VMfb.LstQuestions = _IFB.GetFeedbackQuestions();


            return View(VMfb);
        }


        [HttpPost]
        public IActionResult UpdateQuestion(VMFeedback VMfb)
        {


            VMfb.LstQuestions = _IFB.GetFeedbackQuestions();

            if (ModelState.IsValid)
            {
                string response = _IFB.updatequestion(VMfb.Question);

                if (response == "Success")
                {
                    TempData["Message"] = "Question Updated Sucess";
                    return RedirectToAction("AddFeedbackQuestion");

                }
                else
                {
                    TempData["Message"] = response;
                    return View(VMfb);
                }

            }

            else
            {
                TempData["Message"] = "All Fileds Mandatory !";
                return View(VMfb);
            }



        }


        [HttpGet]
        public IActionResult Feedbacks()
        {
            VMFeedbacks VFBL = new VMFeedbacks();

            VFBL.reviews=_IFB.GetFeedbacks();

          


            return View(VFBL);
        }

        [HttpGet]
        public IActionResult GetReportees(string ReviewName, string MGREmpID)
        {
            VMfeedbackList VMFL = new VMfeedbackList();

            VMFL.reviewname = ReviewName;
            VMFL.mgrEmpID=MGREmpID;
            VMFL.lstreporties = _IFB.GetUserDetailsforfeedback(MGREmpID);




            return View(VMFL);
        }

        [HttpPost]
        public IActionResult RecordFeedback(VMfeedbackList VMFL)
        {
            


            VMFL.lstfbQuestion = _IFB.GetFeedbackQuestions();
            VMFL.EmpName = (VMFL.lstreporties = _IFB.GetUserDetailsforfeedback(VMFL.mgrEmpID)).FirstOrDefault(E => E.EmpID == VMFL.EmpID).EmpName;

            return View(VMFL);


        }
        [HttpPost]
        public IActionResult savefeedback(VMfeedbackList VMFL)
        {
            string Response;
            
           if(VMFL != null)
            {
                Response = _IFB.AddfeedbackQuestion(VMFL.lstfeedback);

                if(Response== "Success")
                {
                    TempData["Message"] = "Feedback Added Sucessfully";
                    return RedirectToAction("GetReportees", "Feedback", new { VMFL.mgrEmpID, VMFL.reviewname });

                }
                else
                {
                    TempData["Message"] = Response;
                    return RedirectToAction("GetReportees", "Feedback", new { VMFL.mgrEmpID, VMFL.reviewname });
                }




            }
            else
            {

                VMFL.lstfbQuestion = _IFB.GetFeedbackQuestions();
                return View(VMFL);

            }



           


        }


    }
}
