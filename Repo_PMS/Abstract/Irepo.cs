using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Abstract
{
    public interface Irepo
    {
        user validateuser(Login login, string btn_click);
        string AddUser(UserDetail User, string btn_click);
        string AddRole(RoleDetail Role);
   
        //string getUserRole(string userid);
        string Changepassword(ChangePasswordVM changepassword);
        //public string getPasswordChangeStatus(string userid);
        List<RoleDetail> GetAllRoles();

        string AddDept(Department dept);
        string AddDegination(Degination deg);
        List<Degination> GetDegination();
        List<Department> GetDepts();
        List<UsersDLVM> GetUserForDL();

        List<UserDetail> GetUsers();
        string AddAssesment(assesment Assesment);
        string AddReview(Review review);
        List<Review> GetAllReviews();
        Review GetReviewData(string Reviewid);
       string updateReview(Review review);
        string DeleteReview(Review review);
        string ActDeactReview(string id);

        List<assesment> GetAllAssesment();
        assesment GetAssesmentData(string Assesmentid);
        string updateAssesment(assesment assesment);
        string DeleteAssesment(assesment assesmet);
        string ActDeactAssement(string id);
        List<VMScoreCard> ShowFinalScore(string year);
        List<VMScoreCard> ShowFinalScoreV2(int dept, int deg, string year);


    }
}
