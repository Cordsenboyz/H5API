using H5API.Controllers;
using H5API.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit.Sdk;

namespace H5APITest
{
    public class UnitTest1
    {
        private readonly UnitOfWork _unitOfWork;
        [Fact]
        public void GetAllStores_ShouldReturnAllStores()
        {
            StoreController controller = new(_unitOfWork);
            var response = controller.GetAll();

            var statusCode = ((IStatusCodeActionResult)response).StatusCode;

            Assert.Equal((int)HttpStatusCode.OK, statusCode);
        }
    }
}