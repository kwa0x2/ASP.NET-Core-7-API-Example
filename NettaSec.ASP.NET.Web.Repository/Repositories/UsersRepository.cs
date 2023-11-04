using NettaSec.ASP.NET.Web.Core.Models;
using NettaSec.ASP.NET.Web.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NettaSec.ASP.NET.Web.Repository.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IDbConnection _connection;

        public UsersRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Users>> UsersGet(int id)
        {
            string sql = "SELECT * FROM nettasec ORDER BY id ASC";
            return await _connection.QueryAsync<Users>(sql);
        }
        public async Task<IEnumerable<Users>> UsersPost(Users users)
        {
            string sql = $"INSERT INTO nettasec(username,password) VALUES('{users.username}','{users.password}') RETURNING id,username,password";
            return await _connection.QueryAsync<Users>(sql); 
        }
        public async Task<IEnumerable<Users>> UsersPut(Users users)
        {
            string sql = $"UPDATE nettasec SET username='{users.username}', password='{users.password}' WHERE id={users.id} RETURNING id,username,password";
            return await _connection.QueryAsync<Users>(sql);
        }
        public async Task<IEnumerable<Users>> UsersDelete(int id)
        {
            string sql = $"DELETE FROM nettasec WHERE id={id}";
            return await _connection.QueryAsync<Users>(sql);
        }
    }
}
