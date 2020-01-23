using System.ComponentModel;

namespace MarsRover.Navigate.Enum
{
    public enum Direction
    {
        [Description("N")]
        N,
        [Description("W")]
        W,
        [Description("S")]
        S,
        [Description("E")]
        E
    }

    public enum Command
    {
        [Description("L")]
        L,
        [Description("R")]
        R,
        [Description("M")]
        M
    }
}
