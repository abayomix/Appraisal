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
    public class AssesmentLogicBL: IAssesmentBussiness
    {

        IAssesment _assesment = new _RepoAssesment();
       public string DeleteQuestion(Question Question)
        {
            return _assesment.DeleteQuestion(Question);


        }
       public string updateQuestion(Question Question)

        {

            Question.ModifiedDate = DateTime.Now;

            return _assesment.updateQuestion(Question);

        }
      public  string AddAssesmentQuestion(Question Question)
        {
            Question.createdDate = DateTime.Now;

            return _assesment.AddAssesmentQuestion(Question);

        }
        public Question GetQuestionData(string QID)
        {
            return _assesment.GetQuestionData(QID);
        }
        public List<Degination> GetDeginationsForDL()
        {
            return _assesment.GetDeginationsForDL();
        }
        public List<Department> GetDepartmentsforDL()
        {
            return _assesment.GetDepartmentsforDL();
        }

        public List<Question> GetAllQuestions()
        {
            return _assesment.GetAllQuestions();
        }

        public List<assesment> getassestmentfordl() 
        
        {
            return _assesment.getassestmentfordl();
        }
        public List<Question> getassesmentquestions(int deptid, int degid)
        {
            return _assesment.getassesmentquestions(deptid,degid);
        }
        public List<Department> GetDepts()
        {
            return _assesment.GetDepts();

        }
        public List<Degination> GetDegination()
        {
            return _assesment.GetDegination();
        }
        public string AddAssesmentQuestion(QuestionSet QS)
        {
            

          QS.createdDate = DateTime.Now;


            return _assesment.AddAssesmentQuestion(QS);

        }

        public string saveassesmentrespons(AssesmentResponse ar)
        {
            ar.createddate = DateTime.Now;
            return _assesment.saveassesmentrespons(ar);
        }
        public Question getAssesmentQuestion(string empid, int assementid, out int Total, out int Qno, out string name)
        {


            return _assesment.getAssesmentQuestion(empid,assementid, out Total, out Qno, out name);


        }
        public List<assesment> GetAssesments()
        {
            return _assesment.GetAssesments();
        }


    }
}
