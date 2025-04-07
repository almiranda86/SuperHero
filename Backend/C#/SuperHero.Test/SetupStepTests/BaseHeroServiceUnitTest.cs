using Moq;
using Moq.AutoMock;
using SuperHero.Domain.Model;
using SuperHero.Repository.Behavior;
using SuperHero.Service;
using SuperHero.UnitTest.Core;

namespace SuperHero.UnitTest.SetupStepTests
{
    public class BaseHeroServiceUnitTest : TestBase
    {
        public BaseHeroServiceUnitTest()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public async Task CreateBaseHero_Success()
        {
            // Arrange
            _mocker.GetMock<IBaseHeroPersister>()
                   .Setup(bhp => bhp.CreateBaseHero(It.IsAny<IEnumerable<BaseHero>>()))
                   .Verifiable();

            var baseHeroService = _mocker.CreateInstance<BaseHeroService>();

            // Act
            await baseHeroService.CreateBaseHero(It.IsAny<IEnumerable<BaseHero>>());


            // Assert
            _mocker.Verify<IBaseHeroPersister>(x => x.CreateBaseHero(It.IsAny<IEnumerable<BaseHero>>()), Times.AtLeastOnce());
        }
    }
}
