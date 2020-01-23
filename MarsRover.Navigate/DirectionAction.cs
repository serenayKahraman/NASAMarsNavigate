using System;
using MarsRover.Navigate.Enum;

namespace MarsRover.Navigate
{
    public class DirectionAction
    {
        private Direction CurrentDirection { get; }
        private Command CurrentCommand { get; }

        public DirectionAction(Direction currentDirection, Command command)
        {
            CurrentDirection = currentDirection;
            CurrentCommand = command;
        }

        public Direction GetNewDirection() =>
            CurrentDirection switch
            {
                Direction.E => CurrentCommand == Command.L ? Direction.N : Direction.S,
                Direction.N => CurrentCommand == Command.L ? Direction.W : Direction.E,
                Direction.W => CurrentCommand == Command.L ? Direction.S : Direction.N,
                Direction.S => CurrentCommand == Command.L ? Direction.E : Direction.W,
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(DirectionAction)),
            };
    }
}
