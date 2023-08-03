using Repo_PMS.Abstract;
using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Repository
{
    public class RepoFeedBack: IFeedback
    {


        private ContextPMS _context = new ContextPMS();

        public string AddfeedbackQuestion (FeedBack_Question Question)
        {
            string response;

            if (Question != null)
            {

                try
                {
                    if(_context.FeedBack_Questions.Any(fq=> fq.Question == Question.Question))
                    {
                        response = "Duplicate";
                        
                    }
                    else
                    {

                        _context.FeedBack_Questions.Add(Question);
                        _context.SaveChanges();

                        if (Question.Id > 0)
                        {
                            response = "Success";

                        }
                        else
                        {
                            response = "Failed Due To Server Error Please Try Later";
                        }

                    }



                }
                catch (Exception)
                {

                    response = "Server Error";
                }

                


            }
            else
            {
                response = "All Fileds are Mandatory";
            }

            return response; 
        }


        public string DeleteFeedBackQuestion(string id)
        {
            string response;

            try
            {
                FeedBack_Question fQ = _context.FeedBack_Questions.FirstOrDefault(f => f.Id == Convert.ToInt32(id));

                _context.FeedBack_Questions.Remove(fQ);
                _context.SaveChanges();

                response = "Success";
               

            }
            catch (Exception)
            {

                response = "Server Error";
            }

            return response;
        }


        public FeedBack_Question getQuestionData(string id)
        {
            FeedBack_Question fQ = _context.FeedBack_Questions.FirstOrDefault(f => f.Id == Convert.ToInt32(id));

            return fQ;

        }




        public string updatequestion(FeedBack_Question ques)
        {
            FeedBack_Question fQ = _context.FeedBack_Questions.FirstOrDefault(f => f.Id== ques.Id);

            fQ.Question = ques.Question;

            _context.SaveChanges();

            return "Success";

            

        }


        public List<FeedBack_Question> GetFeedbackQuestions()
        {
            List<FeedBack_Question> lstquestion=_context.FeedBack_Questions.ToList();

            return lstquestion;
        }

        public List<Review> GetFeedbacks()
        {
            List<Review> feedbacks = _context.reviews.Where(f => f.IsActive == true).ToList();

            return feedbacks;

        }



        public List<UsersDLVM> GetUserDetailsforfeedback(string MGREmpID)
        {


            List<UsersDLVM> Lstusers = _context.UserDetails.Where(u=> !_context.feedbacks.Any(F=> F.empid== u.EmpID) && u.ManagerID == MGREmpID).Select(u => new UsersDLVM { EmpID = u.EmpID, EmpName = u.Name }).ToList();

            return Lstusers;


        }

        public string AddfeedbackQuestion(List<Feedback> feedbacks)
        {
            string response;

            if (feedbacks != null)
            {

                try
                {
                    int sucesscount=0;
                   
                  

                        _context.feedbacks.AddRange(feedbacks);
                        _context.SaveChanges();

                    foreach (Feedback f in feedbacks)
                    {
                        if (f.ID > 0)
                        {
                            sucesscount++;
                        }
                        else
                        {
                            continue;
                        }

                    }

                    if (sucesscount == feedbacks.Count)
                    {
                        response = "Success";
                    }
                    else
                    {
                        response = "Failed To Insert All Record";
                    }



                }
                catch (Exception)
                {

                    response = "Server Error";
                }




            }
            else
            {
                response = "All Fileds are Mandatory";
            }

            return response;
        }

    }
}
