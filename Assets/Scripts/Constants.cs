namespace Rubiks.Constants
{
    public enum SideId
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
        FRONT,
        BACK
    }

    public enum Direction
    {
        CW, CCW
    }

    public enum Axis{
        X,Y,Z
    }

    public enum Color
    {
        NONE,
        WHITE,
        YELLOW,
        RED,
        ORANGE,
        BLUE,
        GREEN
    }

    public class Utils
    {
        public static string ColorToChar(Color color)
        {
            switch (color)
            {
                case Color.WHITE: return "W";
                case Color.YELLOW: return "Y";
                case Color.RED: return "R";
                case Color.ORANGE: return "O";
                case Color.BLUE: return "B";
                case Color.GREEN: return "G";
                default: return "-";
            }
        }

        public static Direction CharToDirection(char cmd2)
        {
            if (cmd2 == 'U' || cmd2 == 'u')
            {
                return Direction.CCW;
            }
            else
            {
                return Direction.CW;
            }
        }

        public static SideId CharToSideId(char cmd)
        {
            switch(cmd)
            {
                case 'l':
                case 'L': return SideId.LEFT;
                case 'r':
                case 'R': return SideId.RIGHT;
                case 'u':
                case 'U': return SideId.UP;
                case 'd':
                case 'D': return SideId.DOWN;
                case 'f':
                case 'F': return SideId.FRONT;
                case 'b':
                case 'B': return SideId.BACK;
                default: return SideId.LEFT;
            }
        }

        public static Color CharToColor(char colorName)
        {
            switch(colorName)
            {
                case 'w':
                case 'W': return Color.WHITE;
                case 'y':
                case 'Y': return Color.YELLOW;
                case 'r':
                case 'R': return Color.RED;
                case 'o':
                case 'O': return Color.ORANGE;
                case 'b':
                case 'B': return Color.BLUE;
                case 'g':
                case 'G': return Color.GREEN;
                default: return Color.NONE;;
            }
        }
    }
}