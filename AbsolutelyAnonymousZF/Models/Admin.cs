namespace AbsolutelyAnonymousZF
{
    using System;

    [Serializable]
    public class Admin
    {

        public string Password { get; set; }

        public string Username { get; set; }

        private bool isLoggedIn;

        public Admin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }





        // public void AddCourse(int cKey, string cName)
        // {
        // this.courseList.AddCourse(cKey, cName);
        // }
        //public void AddUser(string username, string password)
        //{
        //    this.myAdminList.AddAdmin(username, password);
        //}

        //public void InsertFeedBackFilter()
        //{
        //}

        //public void RemoveQuery()
        //{
        //}
    }
}