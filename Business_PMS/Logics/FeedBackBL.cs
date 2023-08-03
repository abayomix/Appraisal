using Business_PMS.Abstract;
using Repo_PMS.Abstract;
using Repo_PMS.Models;
using Repo_PMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_PMS.Logics
{
    public class FeedBackBL : IFeedbackBussiness
    {
        IFeedback _Feedback = new RepoFeedBack();
       public string AddfeedbackQuestion(FeedBack_Question Question)
        {
            Question.createdDate = DateTime.Now;
            return _Feedback.AddfeedbackQuestion(Question);
        }
       public string DeleteFeedBackQuestion(string id)
        {

            return _Feedback.DeleteFeedBackQuestion(id);
        }
       public FeedBack_Question getQuestionData(string id)
        {
            return _Feedback.getQuestionData(id);

        }
       public string updatequestion(FeedBack_Question ques)
        {

            ques.ModifiedDate=DateTime.Now;

            return _Feedback.updatequestion(ques);
        }

        public List<FeedBack_Question> GetFeedbackQuestions()
        {
            return _Feedback.GetFeedbackQuestions();
        }
        public List<Review> GetFeedbacks()
        {
            return _Feedback.GetFeedbacks();
        }

        public List<UsersDLVM> GetUserDetailsforfeedback(string MGREmpID)
        {
            return _Feedback.GetUserDetailsforfeedback(MGREmpID);
        }
        public string AddfeedbackQuestion(List<Feedback> feedbacks)
        {
            foreach(Feedback feedback in feedbacks)
            {
                feedback.createdDate = DateTime.Now;
            }

            return _Feedback.AddfeedbackQuestion(feedbacks);


        }




    }
}
