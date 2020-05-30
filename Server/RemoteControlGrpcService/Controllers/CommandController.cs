using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteControlGrpcService.Services;

namespace RemoteControlGrpcService.Controllers
{
    public class CommandController : Controller
    {
        private readonly RemoteControlService _service;

        public CommandController()
        {
            _service = new RemoteControlService();
        }

        [HttpGet]
        [Route("command/index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("command/index")]
        public async Task<IActionResult> Index(Guid id, int distance, int direction)
        {
            await _service.SendCommand(id, distance, direction);

            return View();
        }
    }
}
