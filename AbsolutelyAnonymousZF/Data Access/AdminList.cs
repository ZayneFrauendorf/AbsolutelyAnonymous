namespace AbsolutelyAnonymousZF
{
    using System;
    using System.Collections.Generic;

    using AbsolutelyAnonymousZF.Data_Access;

    [Serializable]
    public class AdminList : ListBase, IAdminList
    {
        private IList<Admin> administrators;

        public AdminList()
            : base("admins.bin")
        {
            this.administrators = this.LoadFromStorage<Admin>();
        }

        public IEnumerable<Admin> Administrators
        {
            get
            {
                return this.administrators;
            }
        }

        public void AddAdmin(Admin admin)
        {
            this.administrators.Add(admin);
        }

        public IEnumerable<Admin> GetAll()
        {
            return this.Administrators;
        }

        public override void Save()
        {
            base.Save(this.administrators);
        }
    }
}