using System.Threading.Tasks;
using BuildingTuts.Models.TokenAuth;
using BuildingTuts.Web.Controllers;
using Shouldly;
using Xunit;

namespace BuildingTuts.Web.Tests.Controllers
{
    public class HomeController_Tests: BuildingTutsWebTestBase
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