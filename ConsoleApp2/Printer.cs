using System;
using System.Collections.Generic;


namespace ConsoleApp2
{
    public class Printer
    {
        private Dictionary<CellStatuses, char> _notationRepository;

        public Printer()
        {            
            InitNotationRepository();
        }

        public void InitNotationRepository()
        {
            //TODO: Think where is the best location to initiate the notationRepository and implement it.
            _notationRepository = new Dictionary<CellStatuses, char>
            {
                { CellStatuses.Alive, GetAliveCellNotationFromAppConfig() },
                { CellStatuses.Dead, GetDeadCellNotationFromAppConfig() }
            };

        }

        private char GetAliveCellNotationFromAppConfig()
        {

            string _appConfigValue = System.Configuration.ConfigurationManager.AppSettings["AliveCellNotation"];

            if (string.IsNullOrEmpty(_appConfigValue))
            {
                return ' ';
            }
            else
            {
                //convert string to char
                return _appConfigValue.ToCharArray()[0];
            }
        }

        private char GetDeadCellNotationFromAppConfig()
        {

            string _appConfigValue = System.Configuration.ConfigurationManager.AppSettings["DeadCellNotation"];

            if (string.IsNullOrEmpty(_appConfigValue))
            {
                return ' ';
            }
            else
            {
                //convert string to char
                return _appConfigValue.ToCharArray()[0];
            }
        }


        public void PrintPattern(Pattern pattern)
        {
            //TODO: Simplify this method and make it shorter. Splitting it into smaller methods in an option. 
            //ALso, think about responsibility of each method.

            foreach (List<Cell> sublist in pattern.matrix)
            {
                foreach (Cell cell in sublist)
                {
                    PrintCell(cell);
                }

                PrintNewLine();
            }
        }

        private void PrintCell(Cell cell)
        {
            Console.Write(GetCellNotation(cell).ToString());// + ' ');
        }

        private void PrintNewLine()
        {
            Console.WriteLine();
        }

        private char GetCellNotation(Cell cell)
        {
            return _notationRepository[cell.Status];
        }
    }
}