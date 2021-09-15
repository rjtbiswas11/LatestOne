using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OrderedNumbers.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class OrderedNumbersController : ControllerBase
    {
        private readonly ILogger<OrderedNumbersController> _logger;

        public OrderedNumbersController(ILogger<OrderedNumbersController> logger)
        {
            _logger = logger;
        }

        [HttpPost("api/SaveOrderedNumbers/", Name = "SaveOrderedNumbers")]
        public async Task<IActionResult> SaveSortedNumbers([FromBody] SaveOrderedNumberRequest saveOrderedNumberRequest)
        {
            Utility utility = new Utility();
            utility.BubbleSort(saveOrderedNumberRequest.ArrayToSort);
            utility.SaveToText(saveOrderedNumberRequest.ArrayToSort, saveOrderedNumberRequest.FileName);
            return Ok(saveOrderedNumberRequest.ArrayToSort);
        }

        [HttpGet("api/LoadOrderedNumbers/", Name = "LoadOrderedNumbers")]
        public async Task<IActionResult> GetSortedNumbers([FromQuery] LoadOrderedNumberRequest loadOrderedNumberRequest)
        {
            Utility utility = new Utility();
            string contents = utility.ReadFromFile(loadOrderedNumberRequest.FileName);
            return Ok(contents);
        }
    }

    public class Utility
    {
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public void SaveToText(int[] arr, string fileName)
        {
            string filepath = @"C:\" + fileName + ".txt";

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            var stringBuilder = new StringBuilder();
            foreach (var arrayElement in arr)
            {
                stringBuilder.Append(string.Format("{0} ", arrayElement.ToString()));
            }
            File.WriteAllText(filepath, stringBuilder.ToString());
        }

        public string ReadFromFile(string fileName)
        {
            string filepath = @"C:\" + fileName + ".txt";
            string contents = File.ReadAllText(filepath);
            return contents;
        }
    }
}

