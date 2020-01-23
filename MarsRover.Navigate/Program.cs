using System;

namespace MarsRover.Navigate
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
            var navigationInput = new NavigationInputs(input);
            var movingAction = new MovingAction(navigationInput);
            movingAction.ExecuteMoving();
            movingAction.Print();
        }
    }
}
