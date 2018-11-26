namespace ConsoleApp2
{
    public partial class Pattern
    {
        public class PatternSize
        {
            private int _width;
            private int _lenght;

            public int Width
            {
                get => _width;
                set => _width = value;
            }

            public int Lenght
            {
                get => _lenght;
                set => _lenght = value;
            }

            public PatternSize(int width = 20, int lenght = 20)
            {
                _width = width;
                _lenght = lenght;
            }
        }
    }
}