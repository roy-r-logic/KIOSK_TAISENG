using Microsoft.AspNetCore.Mvc;
using SSKWeb.Helpers;
using SSKWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Controllers
{
    public class CollectQueueListController : Controller
    {
        private CollectQueueListApiServices _collectQueueListApiService = new CollectQueueListApiServices();
        public async Task<IActionResult> Index()
        {
            await Task.CompletedTask;
            return View();
        }


        public async Task<IActionResult> CollectQueueList()
        {
            var data =await _collectQueueListApiService.GetCollectQueueListAsync();

            return Ok(new { data = data });
        }

        public async Task<IActionResult> GetCollectQueueListStatusProcessingAsync()
        {
            var data = await _collectQueueListApiService.GetCollectQueueListStatusProcessingAsync();

            return Ok(new { data = data });
        }

        public async Task<IActionResult> UpdateCollectQueueListStatusToWaitingAsync()
        {
            var data = await _collectQueueListApiService.UpdateCollectQueueListStatusToWaitingAsync();

            return Ok(new { data = data });
        }


        public async Task<IActionResult> UpdateCollectQueueListToProcessingAsync()
        {
            var data = await _collectQueueListApiService.UpdateCollectQueueListToProcessingAsync();

            return Ok(new { data = data });
        }

        public async Task<IActionResult> UpdateCollectQueueListStatusToCompletedAsync()
        {
            var data = await _collectQueueListApiService.UpdateCollectQueueListStatusToCompletedAsync();

            return Ok(new { data = data });
        }
    }
}
