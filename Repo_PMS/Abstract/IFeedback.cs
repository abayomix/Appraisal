using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Abstract
{
    public interface IFeedback
    {

        string AddfeedbackQuestion(FeedBack_Question Question);
        string DeleteFeedBackQuestion(string id);
        FeedBack_Question getQuestionData(string id);

        string updatequestion(FeedBack_Question ques);
        List<FeedBack_Question> GetFeedbackQuestions();

        List<Review> GetFeedbacks();
        List<UsersDLVM> GetUserDetailsforfeedback(string MGREmpID);
        string AddfeedbackQuestion(List<Feedback> feedbacks);



    }
}
