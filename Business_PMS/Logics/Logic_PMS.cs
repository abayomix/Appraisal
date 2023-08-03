using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo_PMS;
using Repo_PMS.Models;
using Repo_PMS.Abstract;
using Repo_PMS.Repository;
using Business_PMS.Abstract;

namespace Business_PMS.Logics

{
    public class Logic_PMS : IBusiness
    {

        Irepo _repo = new _RepoPMS();
        public string addrole(RoleDetail Role)
        {
            Role.CreatedDate = DateTime.Now;
            string message = _repo.AddRole(Role);

            return message;

        }


        public List<RoleDetail> GetAllRoles()
        {
            List<RoleDetail> lstRoles =_repo.GetAllRoles();



            return lstRoles;
        }


        public string AddUser(UserDetail User, string btn_click)
        {   
            string message;
            try
            {
               
                    Random random = new Random();
                    User.Password = random.Next(11111,99999).ToString();
                    message=_repo.AddUser(User, btn_click);
                    return(message);
                
                             




            }
            catch (Exception E)
            {
                message = E.Message;
                return message;


            }


        }

       public  user validateuser(Login login, string btn_click)
        {
            return _repo.validateuser(login,btn_click);
            
        }


        //public string getUserRole(string userid)
        //{
        //  string message=_repo.getUserRole(userid);
        //    return message;
        //}


        //public string getPasswordChangeStatus(string userid)
        //{
        //    string message=_repo.getPasswordChangeStatus(userid);
        //    return message;

        //}


        public string Changepassword(ChangePasswordVM changepassword)
        {
            string message=_repo.Changepassword(changepassword);
            return message;

        }



        public string AddDept(Department dept)
        {
            dept.CreateDate = DateTime.Now;
            return _repo.AddDept(dept);

        }
        public string AddDegination(Degination deg)
        {
            deg.CreateDate = DateTime.Now;
            return _repo.AddDegination(deg);

        }
        public List<Degination> GetDegination()
        {
            return _repo.GetDegination();
        }
        public List<Department> GetDepts()
        {
            return _repo.GetDepts();
        }
        public List<UsersDLVM> GetUserForDL()
        {
            return _repo.GetUserForDL();
        }

        public List<UserDetail> GetUsers()
        {
            return _repo.GetUsers();
        }


        public string AddAssesment(assesment Assesment)
        {
            Assesment.CreateDate = DateTime.Now;
            
            return _repo.AddAssesment(Assesment);

        }
       public string AddReview(Review review)
        {
            review.CreateDate = DateTime.Now;

            return _repo.AddReview(review);
        }
        public List<Review> GetAllReviews()
        {
            return _repo.GetAllReviews();
        }


        public Review GetReviewData(string Reviewid)
        {
            return _repo.GetReviewData(Reviewid);
        }
        public string updateReview(Review review)
        {
            return _repo.updateReview(review);
        }
        public string DeleteReview(Review review)
        {
            return _repo.DeleteReview(review);
        }
        public string ActDeactReview(string id)
        {
            return _repo.ActDeactReview(id);
        }


        public List<assesment> GetAllAssesment()
        {
            return _repo.GetAllAssesment();

        }
        public assesment GetAssesmentData(string Assesmentid)
        {
            return _repo.GetAssesmentData(Assesmentid);
        }
        public string updateAssesment(assesment assesment)
        {
            return _repo.updateAssesment(assesment);
        }
        public string DeleteAssesment(assesment assesmet)
        {
            return _repo.DeleteAssesment(assesmet);
        }
        public string ActDeactAssement(string id)
        {

            return _repo.ActDeactAssement(id);
        }

       public List<VMScoreCard> ShowFinalScore(string year)
        {
            return _repo.ShowFinalScore(year);
        }
        public List<VMScoreCard> ShowFinalScoreV2(int dept, int deg, string year)
        {
            return _repo.ShowFinalScoreV2(dept,deg,year);
        }

    }
}
