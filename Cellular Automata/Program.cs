using System;
using System.Collections;

namespace CellularAutomata
{
    class CellularAutomata
    {
        BitArray cells, ncells;
        const int cellnumbers = 41; 
        public void run()
        {
            while (true)
            {
                cells = new BitArray(cellnumbers);
                ncells = new BitArray(cellnumbers);
                Console.WriteLine("What Rule do you want to use?");
                doRule(int.Parse(Console.ReadLine()));
            }
        }
        private byte getCells(int index)
        {
            byte b;
            int i1 = index - 1, i2 = index, i3 = index + 1;
            if (i1 < 0) i1 = cellnumbers - 1;
            if (i3 >= cellnumbers) i3 -= cellnumbers;
            b = Convert.ToByte(4 * Convert.ToByte(cells.Get(i1)) + 2 * Convert.ToByte(cells.Get(i2)) + Convert.ToByte(cells.Get(i3)));
            return b;
        }
        private string getBase (int i)
        {
            string s = Convert.ToString(i, 2);
            while (s.Length < 8)
            { s = "0" + s; }
            return s;        
        }
        private void doRule(int rule)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            ncells.SetAll(false);
            cells.SetAll(false);
            string r1 = getBase(rule);
            Console.WriteLine("Do you want to continue manual or random? m/r");
            string choice = Console.ReadLine();
            if (choice == "r")
            {
                cells.Set(cellnumbers / 2, true);
            }
            //manual input can be done here for the first line
            if (choice== "m")
            {
                cells[0] = false; cells[1] = false; cells[2] = false; cells[3] = false; cells[4] = false; cells[5] = false; cells[6] = false; cells[7] = false; cells[8] = false; cells[9] = false;
                cells[10] = false; cells[11] = false; cells[12] = false; cells[13] = false; cells[14] = false; cells[15] = false; cells[16] = false; cells[17] = false; cells[18] = false; cells[19] = false;
                cells[20] = false; cells[21] = false; cells[22] = false; cells[23] = false; cells[24] = false; cells[25] = false; cells[26] = false; cells[27] = false; cells[28] = false; cells[29] = false;
                cells[30] = false; cells[31] = false; cells[32] = false; cells[33] = false; cells[34] = false; cells[35] = false; cells[36] = false; cells[37] = false; cells[38] = false; cells[39] = false;
                cells[40] = false;
            }
            for (int gen = 0; gen <50; gen++)
            {
                Console.Write("{0, 4}", gen +1 + ": ");

                foreach (bool b in cells)
                    Console.Write(b ? "X" : ".");

                Console.WriteLine("");

                int i = 0;
                while (true)
                {
                    byte b = getCells(i);
                    ncells[i] = '1' == r1[7 - b] ? true : false;
                    if (++i == cellnumbers) break;
                }

                i = 0;
                foreach (bool b in ncells)
                    cells[i++] = b;
            }
            Console.WriteLine("");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CellularAutomata t = new CellularAutomata();
            t.run();
        }
    }
}
