using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutelyAnonymousZF.Data_Access
{
    public interface IAdminList : IListBase
    {
        IEnumerable<Admin> GetAll();

        void AddAdmin(Admin admin);
    }
}
