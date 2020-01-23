using System.Collections.Generic;
using MarsRover.Navigate.Enum;

namespace MarsRover.Navigate
{
    public class CoordinateDirection
    {
        public Coordinate InitCoordinate { get; private set; }
        public Direction InitDirection { get; private set; }
        public IList<char> Commands { get; private set; }

        public CoordinateDirection(string oddInputLine, string evenInputLine)
        {
            SetMarsRoverAction(oddInputLine, evenInputLine);
        }

        private void SetMarsRoverAction(string oddInputLine, string evenInputLine)
        {
            InitDirection = oddInputLine[2].ToString().GetValueFromDescription<Direction>();

            InitCoordinate = new Coordinate
            {
                X = int.Parse(oddInputLine[0].ToString()),
                Y = int.Parse(oddInputLine[1].ToString())
        };
            Commands = evenInputLine.ToCharArray();
        }

    }

}
