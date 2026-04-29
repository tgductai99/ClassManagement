using System.Threading.Tasks;
using TaskQLLH.Models.TokenAuth;
using TaskQLLH.Web.Controllers;
using Shouldly;
using Xunit;

namespace TaskQLLH.Web.Tests.Controllers
{
    public class HomeController_Tests: TaskQLLHWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}