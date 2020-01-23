using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Navigate
{
    public class NavigationInputs
    {
        private string _input;
        private List<string> _inputLines;
        private const string separator = "\n";
        private const int minInputLine = 3;

        public NavigationInputs(string input)
        {
            _input = input;
            MarsRoverActions = new List<CoordinateDirection>();
            ToNavigationInputs();
        }
        public Coordinate MaxCoordinate { get; private set; }
        public IList<CoordinateDirection> MarsRoverActions { get; }


        private void ToNavigationInputs()
        {
            InputValidatedAndSet();
            SetMaxCoordinate();
            SetMarsRoverActions();
        }

        private void SetMarsRoverActions()
        {
            var oddLine = "";

            foreach (var inputLine in _inputLines)
            {
                if (_inputLines.IndexOf(inputLine) == 0)
                    continue;
                if (IsOdd(_inputLines.IndexOf(inputLine))) oddLine = inputLine;
                else
                    MarsRoverActions.Add(new CoordinateDirection(oddLine, inputLine));
            }
        }

        private void SetMaxCoordinate()
        {
            var firstLine = _inputLines.First();

            if (firstLine.Length < 2)
                throw new CustomException("There is a lack of max coordinate.");

            MaxCoordinate = new Coordinate { X = int.Parse(firstLine[0].ToString()), Y = int.Parse(firstLine[1].ToString()) };
        }

        private void InputValidatedAndSet()
        {

            if (string.IsNullOrEmpty(_input)) throw new CustomException("Input can't be empty");

            if (_input.Split(separator).Length < minInputLine) throw new CustomException("Missing input number");

            _input = _input.Replace(" ", "");
            _inputLines = _input.Split(separator).ToList();
        }

        private bool IsOdd(int index) => index % 2 != 0;

    }

}
