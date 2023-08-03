namespace mywebapi.Models
{
    public class User
    {

        public string userid { get; set; }
        public string name { get; set; }
        public string empId { get; set; }
        public string role { get; set; }
        public string IsVAliduser { get; set; }
        public string pwdchgstatus { get; set; }
        public string utype { get; set; }

        public string udeg { get; set; }

        public string udept { get; set; }

        public int response { get; set; }
    }
}
