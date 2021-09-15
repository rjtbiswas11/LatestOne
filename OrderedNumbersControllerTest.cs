using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using OrderedNumbers;
using OrderedNumbers.Controllers;

namespace UnitTests.Controllers
{
    public class OrderedNumbersControllerTest
    {
        private OrderedNumbersController controller = null;
        private ILogger<OrderedNumbersController> logger;

        [SetUp]
        public void Setup()
        {
            logger = Substitute.For<ILogger<OrderedNumbersController>>();
        }

        [TestCase()]
        public async Task SaveSortedNumbersTest()
        {
            SaveOrderedNumberRequest saveOrderedNumberRequest = new SaveOrderedNumberRequest()
            {
                ArrayToSort = new int[] { -8, 34, 25, 12, 22, 11, 90 },
                FileName = "Random"
            };

            controller = new OrderedNumbersController(logger);
            var response = await controller.SaveSortedNumbers(saveOrderedNumberRequest);
            Assert.IsNotNull(response);
        }

        [TestCase()]
        public async Task GetSortedNumbersTest()
        {
            LoadOrderedNumberRequest loadOrderedNumberRequest = new LoadOrderedNumberRequest()
            {
                FileName = "Random"
            };

            controller = new OrderedNumbersController(logger);
            var response = await controller.GetSortedNumbers(loadOrderedNumberRequest);
            Assert.IsNotNull(response);
        }
    }
}
