using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Domain;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MissionController : ControllerBase
    {
        private IMissionService service;

        public MissionController(IMissionService service)
        {
            this.service = service;
        }

        [HttpPost("/input")]
        public async Task<IActionResult> StartMissionAsync()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var input = await reader.ReadToEndAsync();
                var result = service.Execute(input);
                var rawLogs = string.Join(Environment.NewLine, result.Log);
                return Ok(rawLogs);
            }
        }

        [HttpGet("/alive")]
        public IActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}
