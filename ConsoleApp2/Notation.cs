namespace ConsoleApp2
{
    public class Notations
    {
        private char _aliveNotation;
        private char _deadNotation;

        public char AliveCellNotation { get => _aliveNotation; set => _aliveNotation = value; }
        public char DeadCellNotation { get => _deadNotation; set => _deadNotation = value; }


        public Notations()
        {
            AliveCellNotation = GetNotationForAliveCell();
            DeadCellNotation = GetNotationForDeadCell();
        }


        private char GetNotationForAliveCell()
        {
            var appConfigPath = System.Configuration.ConfigurationManager.AppSettings["AliveCell"];
            if (string.IsNullOrEmpty(appConfigPath))
            {
                return ' ';
            }
            else return appConfigPath.ToCharArray()[0];
        }

        private char GetNotationForDeadCell()
        {
            var appConfigPath = System.Configuration.ConfigurationManager.AppSettings["DeadCell"];
            if (string.IsNullOrEmpty(appConfigPath))
            {
                return ' ';
            }
            else return appConfigPath.ToCharArray()[0];
        }



    }
}