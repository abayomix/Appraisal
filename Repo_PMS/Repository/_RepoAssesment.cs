using Repo_PMS.Abstract;
using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Repository
{
    
    public  class _RepoAssesment: IAssesment
    {
        private ContextPMS _context = new ContextPMS();

        public string AddAssesmentQuestion(Question Question)
        {
            string message;
            if (_context.Questions.Any(Q => Q.Question_Text == Question.Question_Text))
            {

                message = "Duplicate Question";
                return message;

            }
            else
            {

                try
                {
                    if (Question != null)
                    {

                        _context.Questions.Add(Question);
                        _context.SaveChanges();

                        if (Question.Qid > 0)
                        {
                            message = "Question Added SucessFully";
                            return message;
                        }
                        else
                        {
                            message = "Faild Question not Added Due To Some Error";
                            return message;
                        }




                    }
                    else
                    {
                        message = "Oops you have filled all the required Fields";
                        return message;


                    }




                }
                catch (Exception E)
                {
                    message = E.Message;
                    return message;


                }
            }

        }



        public Question GetQuestionData(string QID)
        {
            Question Q = _context.Questions.Where(Q => Q.Qid== int.Parse(QID)).FirstOrDefault();


            return Q;
        }

        public string updateQuestion(Question Question)
        {
            Question Q = _context.Questions.Where(Q => Q.Qid == Question.Qid).FirstOrDefault();

            Q.Question_Text = Question.Question_Text;
            Q.option_1 = Question.option_1;
            Q.option_2 = Question.option_2;
            Q.option_3 = Question.option_3;
            Q.option_4 = Question.option_4;
            Q.Correct = Question.Correct;
            Q.DegID = Question.DegID;
            Q.DeptID=Question.DeptID;
            Q.ModifiedBY=Question.ModifiedBY;
           


            _context.SaveChanges();

            return "Sucess";

        }

        public string DeleteQuestion(Question Question)
        {
            _context.Remove(Question);
            _context.SaveChanges();
            return "Sucess";

        }


        public List<Department> GetDepartmentsforDL()
        {


            List<Department> lstDept = _context.departments.Select(Dept => new Department { DeptName= Dept.DeptName, Id= Dept.Id }).ToList();

            return lstDept;


        }


        public List<Degination> GetDeginationsForDL()
        {


            List<Degination> lstdegination = _context.deginations.Select(deg => new Degination {  DeginationName = deg.DeginationName, Id=deg.Id }).ToList();

            return lstdegination;


        }

        public List<Question> GetAllQuestions()
        {


            List<Question> lstQuestion = _context.Questions.ToList();
            return lstQuestion;


        }

        public List<string> getassestmentCategories()
        {

            List<string> lstascat = _context.assesments.Select(a => a.AssessmentCAtegory).Distinct().ToList();
            return lstascat;
        }

        public List<string> getassestmentyear()
        {

            List<string> lstyear = _context.assesments.Select(a => a.AssessmentYear).Distinct().ToList();
            return lstyear;
        }



        public List<assesment> getassestmentfordl()
        {

            List<assesment> lstaasement = _context.assesments.Select(a=> new assesment { Id = a.Id, AssessmentName = a.AssessmentName, AssessmentYear = a.AssessmentYear, AssessmentCAtegory = a.AssessmentCAtegory }).ToList();
            return lstaasement;
        }

        public List<Question> getassesmentquestions(int deptid,int degid)
        {

            List<Question> lstassques =_context.Questions.Where(Q=> Q.DegID==degid && Q.DeptID==deptid).Select(Q => new Question {Question_Text=Q.Question_Text,Qid=Q.Qid}).ToList();
            return lstassques;
        
        
        }

        public List<Department> GetDepts()
        {
            List<Department> LstDepts = _context.departments.Select(D=> new Department { Id=D.Id, DeptName=D.DeptName}).ToList();

            return LstDepts;


        }

        public List<Degination> GetDegination()
        {
            List<Degination> LstDeg = _context.deginations.Select(D => new Degination { Id=D.Id , DeginationName=D.DeginationName}).ToList();

            return LstDeg;


        }


        public string AddAssesmentQuestion (QuestionSet QS)
        {
            string response;

            if (QS != null)
            {
                try
                {
                    if(_context.QuestionSets.Any(Q=> Q.AssesmentID == QS.AssesmentID))
                    {

                        QuestionSet Set = _context.QuestionSets.FirstOrDefault(f => f.AssesmentID == QS.AssesmentID);

                        Set.QuestionID = QS.QuestionID;
                        Set.ModifiedDate = DateTime.Now;

                        _context.SaveChanges();

                        response = "Success";
                    }
                    else
                    {
                        _context.QuestionSets.Add(QS);
                        _context.SaveChanges();

                        if (QS.id > 0)
                        {

                            response = "Success";
                        }
                        else
                        {
                            response = "Failed";
                        }


                    }




                }
                catch (Exception)
                {

                    response = "Error Ocured Questionset Not Added";
                }


            }
            else
            {
                response = "oops All Fields Requiered";
            }

            return response;


        }


        public List<assesment> GetAssesments()
        {
            List<assesment> assesments = _context.assesments.Where(f => f.IsActive == true).ToList();

            return assesments;

        }


        public Question getAssesmentQuestion(string empid,int assementid ,out int Total,out int Qno,out string name)
        {

            UserDetail u = _context.UserDetails.Select(U => new UserDetail { EmpID = U.EmpID, DeptID = U.DeptID, Name= U.Name })
                .FirstOrDefault(U => U.EmpID == empid);

            name = u.Name;

            string quentions = _context.QuestionSets.FirstOrDefault(Qs => Qs.AssesmentID == assementid).QuestionID;


       

            List<int> questionids = quentions.Split(',').Select(int.Parse).ToList();
            Total = questionids.Count;

            List<int> Qids = questionids.Where(Q => !_context.AssesmentResponses
            .Where(A => A.AssementID == assementid && A.Empid == empid)            
            .Select(A=> new {i=A.QID}).Any(a=> a.i==Q)).ToList();
            Qno = Total - Qids.Count + 1;

            Question? Que = new Question();

            try
            {
                Que = _context.Questions
                .Select(Q => new Question
                {
                    Question_Text = Q.Question_Text,
                    Qid = Q.Qid,
                    option_1 = Q.option_1,
                    option_2 = Q.option_2,
                    option_3 = Q.option_3,
                    option_4 = Q.option_4
                }).FirstOrDefault(Q => Q.Qid == Qids.First());

            }
            catch (Exception)
            {
                return new Question();
                
            }
            
            

            return Que;







            //List<Question> lstassques = _context.Questions.Where(Q => Q.DegID == u.DeginationID && Q.DeptID == u.DeginationID && questionids.Any(E=> E==Q.Qid))
            //     .Select(Q => new Question
            //     {
            //         Question_Text = Q.Question_Text,
            //         Qid = Q.Qid,
            //         option_1 = Q.option_1,
            //         option_2 = Q.option_2,
            //         option_3 = Q.option_3,
            //         option_4 = Q.option_4
            //     }).ToList();


          
        }


        public string saveassesmentrespons(AssesmentResponse ar)
        {

            string response;

            try
            {
                int correct = _context.Questions.FirstOrDefault(A => A.Qid == ar.QID).Correct;
                if (ar.AnswerResponse == correct)
                {
                    ar.iscorrect=true;
                }

                _context.AssesmentResponses.Add(ar);
                _context.SaveChanges();

                if (ar.ARID >0)
                {

                    response = "Success";
                }
                else
                {
                    response = "Failed";
                }
            }
            catch (Exception e)
            {
                response = e.Message;
                
            }


            return response;
        }

 


}
}
