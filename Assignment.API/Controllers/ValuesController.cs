using Assignment.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public ValuesController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getStatus")]
        public ActionResult<bool> Get()
        {
            try
            {
                bool isConnected = _dbContext.TestConnection();
                return Ok(isConnected);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
