using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Duplicates.Api.Extensions;
using Duplicates.Core.Errors;
using Duplicates.Core.Files;
using Duplicates.Core.Interfaces;
using Duplicates.Data.Entities;
using Duplicates.Services.Statistics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using FileExtensions = Duplicates.Core.Files.FileExtensions;

namespace Duplicates.Api.Controllers
{
    [Route("api/v{version:apiVersion}/json")]
    [ApiVersion("1.0")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IStatisticsService _statisticsService;

        public JsonController(IFileService fileService, IStatisticsService statisticsService)
        {
            _fileService = fileService;
            _statisticsService = statisticsService;
        }

        [HttpPost("remove_duplicates")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveDuplicates(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(ErrorMessages.IncorrectFile);

            if (file.FileName.Contains($".{FileExtensions.JsonFileExtension}") == false)
                return BadRequest(ErrorMessages.IncorrectFileType);

            var fileContent = await file.GetBytes();
            var statistics = await _fileService.Deserialize<IEnumerable<Statistic>>(fileContent, new SnakeCaseNamingStrategy());
            
            var statisticsWithoutDuplicate = _statisticsService.GetStatisticsWithoutDuplicate(statistics);
            var jsonStatistics = _fileService.Serialize(statisticsWithoutDuplicate, new SnakeCaseNamingStrategy());
            var bytes = Encoding.UTF8.GetBytes(jsonStatistics);
            var ms = new MemoryStream(bytes);

            var fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)} without duplicates.{FileExtensions.JsonFileExtension}";
            return File(ms.ToArray(), FileContentType.JsonContentType, fileName);
        }
    }
}