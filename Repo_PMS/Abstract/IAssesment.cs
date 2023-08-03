using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Abstract
{
    public interface IAssesment
    {
        string DeleteQuestion(Question Question);
        string updateQuestion(Question Question);
        string AddAssesmentQuestion(Question Question);
        Question GetQuestionData(string QID);
        List<Degination> GetDeginationsForDL();
        List<Department> GetDepartmentsforDL();
        List<Question> GetAllQuestions();
        List<assesment> getassestmentfordl();
        List<Question> getassesmentquestions(int deptid, int degid);
        List<Department> GetDepts();
        List<Degination> GetDegination();
        string AddAssesmentQuestion(QuestionSet QS);
        string saveassesmentrespons(AssesmentResponse ar);
        Question getAssesmentQuestion(string empid, int assementid, out int Total, out int Qno, out string name);
        List<assesment> GetAssesments();



    }
}
