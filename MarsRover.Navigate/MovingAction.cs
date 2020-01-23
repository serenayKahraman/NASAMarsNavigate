using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MarsRover.Navigate.Enum;

namespace MarsRover.Navigate
{
    public class MovingAction
    {

        private NavigationInputs Inputs { get; }
        private Coordinate CurrentCoordinate { get; set; }
        private Direction CurrentDirection { get; set; }
        public IList<string> FinalDirectAndCoordinates { get; }

        public MovingAction(NavigationInputs inputs)
        {
            FinalDirectAndCoordinates = new List<string>();
            Inputs = inputs;
        }

        public void ExecuteMoving()
        {

            foreach (var inputsMarsRoverAction in Inputs.MarsRoverActions)
            {
                CurrentCoordinate = inputsMarsRoverAction.InitCoordinate;
                CurrentDirection = inputsMarsRoverAction.InitDirection;
                foreach (var command in inputsMarsRoverAction.Commands)
                {
                    var commandEnum = command.ToString().GetValueFromDescription<Command>();
                    if (commandEnum == Command.M) CurrentCoordinate = Moving();
                    else
                    {
                        var directionAction = new DirectionAction(CurrentDirection, commandEnum);
                        CurrentDirection = directionAction.GetNewDirection();
                    }
                    if (CurrentCoordinate.X > Inputs.MaxCoordinate.X || CurrentCoordinate.Y > Inputs.MaxCoordinate.Y || CurrentCoordinate.Y < 0 || CurrentCoordinate.X < 0)
                        throw new CustomException("Out of coordinates");
                }
                FinalDirectAndCoordinates.Add($"{CurrentCoordinate.X}{CurrentCoordinate.Y}{CurrentDirection.ToDescription()}");
            }

        }
        [ExcludeFromCodeCoverage]
        public void Print() => Console.WriteLine(string.Join("\n", FinalDirectAndCoordinates));

        private Coordinate Moving() =>
            CurrentDirection switch
            {
                Direction.E => new Coordinate { X = CurrentCoordinate.X + 1, Y = CurrentCoordinate.Y },
                Direction.N => new Coordinate { X = CurrentCoordinate.X, Y = CurrentCoordinate.Y + 1 },
                Direction.W => new Coordinate { X = CurrentCoordinate.X - 1, Y = CurrentCoordinate.Y },
                Direction.S => new Coordinate { X = CurrentCoordinate.X, Y = CurrentCoordinate.Y - 1 },
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(DirectionAction)),
            };

    }
}
