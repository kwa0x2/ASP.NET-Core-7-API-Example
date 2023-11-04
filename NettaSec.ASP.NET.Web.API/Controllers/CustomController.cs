using Microsoft.AspNetCore.Mvc;
using NettaSec.ASP.NET.Web.Core.Models;

namespace NettaSec.ASP.NET.Web.API.Controllers
{
    public class CustomController : ControllerBase
    {
        [NonAction]
        public IActionResult GetReturnStatus(object data, string? error)
        {
            ApiStatus<Object> status = new ApiStatus<Object>();
            if(data != null)
            {
                status.json = data;
                status.rowCount = ((IEnumerable<object>)data).ToList().Count;
                if(status.rowCount > 0)
                {
                    status.statusCode = 200;
                }
                else
                {
                    status.statusCode = 204;
                }

                return Ok(status);
            }
            else
            {
                status.statusCode = 400;
                status.errors = error;
                return BadRequest(status);
            }
        }

        [NonAction]
        public IActionResult PostReturnStatus(object data, string? error)
        {
            ApiStatus<Object> status = new ApiStatus<object>();
            if(error == null)
            {
                status.statusCode=200;
                status.json= data;
                return Ok(status);
            }
            else
            {
                status.statusCode = 400;
                status.errors = error;
                return BadRequest(status);
            }
        }
        [NonAction]
        public IActionResult PutReturnStatus(object data, string? error)
        {
            ApiStatus<Object> status = new ApiStatus<object>();
            if(data!= null)
            {
                status.statusCode = 200;
                status.json = data;
                return Ok(status);
            }
            else if(error != null)
            {
                status.statusCode = 400;
                status.errors = error;
                return BadRequest(status);
            }
            else
            {
                status.statusCode = 400;
                status.errors = "Hiçbir satır etkilenmedi";
                return BadRequest(status);
            }
        }

        [NonAction]
        public IActionResult DeleteReturnStatus(int id, string? error)
        {
            ApiStatus<Object> status = new ApiStatus<object>();
            if (id > 0)
            {
                status.statusCode = 200;
                status.id = id;
                return Ok(status);
            }
            if(error != null)
            {
                status.statusCode = 400;
                status.id = id;
                status.errors = error;
                return BadRequest(status);
            }
            else
            {
                status.statusCode = 400;
                status.id = id;
                status.errors = "Hiçbir satır etkilenmedi";
                return BadRequest(status);
            }
        }
    }
}
