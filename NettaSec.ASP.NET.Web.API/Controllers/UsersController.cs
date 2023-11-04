using Microsoft.AspNetCore.Mvc;
using NettaSec.ASP.NET.Web.Core.Models;
using System.Data;
using NettaSec.ASP.NET.Web.Repository.IRepositories;
using Dapper;
using System.Collections.Immutable;

namespace NettaSec.ASP.NET.Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : CustomController
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return GetReturnStatus(await _usersRepository.UsersGet(id), null);
            }
            catch (Exception ex)
            {
                return GetReturnStatus(null, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users users)
        {
            try
            {
                return PostReturnStatus(await _usersRepository.UsersPost(users), null);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> Put(Users users)
        {
            try
            {
                await _usersRepository.UsersPut(users);
                return PutReturnStatus(users.id, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usersRepository.UsersDelete(id);
                return DeleteReturnStatus(id,null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
