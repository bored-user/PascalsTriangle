using System.Collections.Generic;
using System.Linq;
using System;

namespace PascalsTriangle
{
    public class PascalsTriangle
    {
        private int[,] _triangle;
        private Dictionary<string, int> _style = new Dictionary<string, int>() { ["identation"] = 1 };
        public int _rows;

        public PascalsTriangle(int rows)
        {
            this._rows = rows;
            this._triangle = new int[rows, rows];
            this._triangle[0, 0] = 1;

            for (int row = 1; row < rows; row++)
                for (int col = 0; col < rows; col++)
                    this._triangle[row, col] = this._triangle[row - 1, col] + (col - 1 < 0 || col + 1 > rows ? 0 : this._triangle[row - 1, col - 1]);


            /*
                             1
                            1 1
                           1 2 1
                          1 3 3 1
                         1 4 6 4 1
                       1 5 10 10 5 1
                      1 6 15 20 15 6 1
                    1 7 21 35 35 21 7 1
                    
                    numberOfSpaces = 
            */
        }

        private int Padding(int row)
        {
            
            return 0;
        }

        public override string ToString()
        {
            string res = "";

            for (int row = 0; row < this._rows; row++)
            {
                res += "".PadLeft(this.Padding(row),' ');

                for (int col = 0; col < this._rows; col++)
                    if (this._triangle[row, col] == 0) continue; else res += $"{this._triangle[row, col]} ";

                res += "\n";
            }

            return res.Substring(0, res.Length - 1);
        }
    }
}