using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettaSec.ASP.NET.Web.Core.Models;

namespace NettaSec.ASP.NET.Web.Repository.IRepositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> UsersGet(int id);
        Task<IEnumerable<Users>> UsersPost(Users users);
        Task<IEnumerable<Users>> UsersPut(Users users);
        Task<IEnumerable<Users>> UsersDelete(int id);

    }
}
