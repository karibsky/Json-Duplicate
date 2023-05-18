using System.Collections.Generic;
using System.Threading.Tasks;
using Duplicates.Data.Entities;
using Duplicates.Services.Logs;
using Microsoft.AspNetCore.Mvc;

namespace Duplicates.Api.Controllers
{
    [Route("api/v{version:apiVersion}/logs")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;

        public LogsController(ILogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Log>>> GetAllAsync()
        {
            var logs = await _logsService.GetAllAsync();
            return Ok(logs);
        }
    }
}