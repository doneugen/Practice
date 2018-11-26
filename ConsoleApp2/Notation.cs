namespace ConsoleApp2
{
    public class Notations
    {
        private char _aliveNotation;
        private char _deadNotation;

        public char AliveNotation { get => _aliveNotation; set => _aliveNotation = value; }
        public char DeadNotation { get => _deadNotation; set => _deadNotation = value; }


        public Notations()
        {
            AliveNotation = System.Configuration.ConfigurationManager.AppSettings["AliveCell"].ToCharArray()[0];
            DeadNotation = System.Configuration.ConfigurationSettings.AppSettings["DeadCell"].ToCharArray()[0];
        }
    }
}