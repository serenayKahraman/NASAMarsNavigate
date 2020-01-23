using System.Linq;
using NUnit.Framework;
using Xunit;

namespace MarsRover.Navigate.Test
{
    public class NavigateTests
    {
        [Fact]
        [TestCase("5 5\n4 4N\nMMM")]
        public void ShouldReturnExceptionOutOfCoordinates(string input)
        {
            var navigationInput = new NavigationInputs(input);
            var movingAction = new MovingAction(navigationInput);

            Assert.Throws<CustomException>(() => movingAction.ExecuteMoving());
        }
        [Fact]
        [TestCase("5 5\n0 0 N\nL", "0 0 W")]
        [TestCase("5 5\n0 0 N\nR", "0 0 E")]
        [TestCase("5 5\n0 0 W\nL", "0 0 S")]
        [TestCase("5 5\n0 0 W\nR", "0 0 N")]
        [TestCase("5 5\n0 0 S\nL", "0 0 E")]
        [TestCase("5 5\n0 0 S\nR", "0 0 W")]
        [TestCase("5 5\n0 0 E\nL", "0 0 N")]
        [TestCase("5 5\n0 0 E\nR", "0 0 S")]
        [TestCase("5 5\n1 1 N\nM", "1 2 N")]
        [TestCase("5 5\n1 1 W\nM", "0 1 W")]
        [TestCase("5 5\n1 1 S\nM", "1 0 S")]
        [TestCase("5 5\n1 1 E\nM", "2 1 E")]
        public void ShouldCorrectFinalDirect(string input, string correctResult)
        {
            var navigationInput = new NavigationInputs(input);
            var movingAction = new MovingAction(navigationInput);
            movingAction.ExecuteMoving();
            Assert.True(movingAction.FinalDirectAndCoordinates.First().Equals(correctResult));
        }

        [Fact]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM", "13N")]
        [TestCase("5 5\n3 3 E\nMMRMMRMRRM", "51E")]
        public void ShouldCorrectFinalPosition(string input, string correctResult)
        {
            var navigationInput = new NavigationInputs(input);
            var movingAction = new MovingAction(navigationInput);
            movingAction.ExecuteMoving();
            Assert.True(movingAction.FinalDirectAndCoordinates.First().Equals(correctResult));
        }

        [Fact]
        [TestCase("5 5\n4 4N")]
        [TestCase("5555\n1 2 N\nLMLMLMLMM")]
        public void ShouldExceptionWrongInput(string input)
        {
            
            Assert.Throws<CustomException>(() => new NavigationInputs(input));

        }
    }
}