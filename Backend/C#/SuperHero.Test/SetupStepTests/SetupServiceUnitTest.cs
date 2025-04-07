using Moq;
using Moq.AutoMock;
using SuperHero.Domain.Behavior.Service;
using SuperHero.Domain.Model;
using SuperHero.Service;

namespace SuperHero.UnitTest.SetupStepTests
{
    public class SetupServiceUnitTest
    {
        readonly AutoMocker _mocker;


        public SetupServiceUnitTest()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public async Task Setup_Success()
        {
            // Arrange
            _mocker.GetMock<IBaseHeroService>()
                   .Setup(bhs => bhs.CreateBaseHero(It.IsAny<IEnumerable<BaseHero>>()))
                   .Verifiable();

            var setup = _mocker.CreateInstance<Setup>();

            // Act
            setup.InitializeDb();


            // Assert
            _mocker.Verify<IBaseHeroService>(x => x.CreateBaseHero(It.IsAny<IEnumerable<BaseHero>>()), Times.AtLeastOnce());
        }
    }
}
