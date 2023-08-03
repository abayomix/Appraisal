using mywebapi.Models;
using Newtonsoft.Json;
using Repo_PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Repository
{
    public class RepoMYAPI
    {
        private string baseurl = @"http://localhost:92/api/"; /// <summary>
        /// For Web Api Paste the api URL here
        /// </summary>

        private ContextPMS _context = new ContextPMS();
        public async Task<user> Login (Login Lgn)

        {
            user? VTMD = new user();
            using (HttpClient MyApiCLient = new HttpClient())
            {

                string endpoint = baseurl + @"MyAPi/Get";


                HttpContent body = new StringContent(JsonConvert.SerializeObject(Lgn), Encoding.UTF8, "application/json");
               
                var request = await MyApiCLient.PostAsync(endpoint,body);

                if(request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();

                    VTMD = JsonConvert.DeserializeObject<user>(response);
                }
            }

            if (VTMD.response == 200)
            {
                if(VTMD.name != null)
                {

                    VTMD.role = _context.RoleDetails.FirstOrDefault(r => r.RoleId == Convert.ToInt32(VTMD.role)).RoleName;
                    VTMD.udeg = _context.deginations.FirstOrDefault(r => r.Id == Convert.ToInt32(VTMD.udeg)).DeginationName;
                    VTMD.udept = _context.departments.FirstOrDefault(r => r.Id == Convert.ToInt32(VTMD.udept)).DeptName;
                }

            }



            return (VTMD);
        }

        public async Task<VmTupple> Createuser(UserDetail user)

        {
            VmTupple? VTMD = new VmTupple();
            
            using (HttpClient MyApiCLient = new HttpClient())
            {

                string endpoint = baseurl + @"MyAPi/Register";


                HttpContent body = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var request = await MyApiCLient.PostAsync(endpoint, body);

                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();

                    VTMD = JsonConvert.DeserializeObject<VmTupple>(response);
                }
            }

           



            return (VTMD);
        }



    }
}
