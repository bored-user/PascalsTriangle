using System.Collections.Generic;
using System.Linq;
using System;

namespace PascalsTriangle
{
    public class PascalTriangle
    {
        private int[,] _triangle;
        private int _rows;
        private bool _easterEgg;

        public PascalTriangle(int rows, bool easterEgg = false)
        {
            if (rows == 0) throw new NotSupportedException(EasterEgg());
            else if (rows < 1) throw new FormatException("Row number must be greater or equal to one");

            this._easterEgg = easterEgg;
            this._rows = rows;
            this._triangle = new int[rows, rows];
            this._triangle[0, 0] = 1;

            for (int row = 1; row < rows; row++)
                for (int col = 0; col < rows; col++)
                    this._triangle[row, col] = this._triangle[row - 1, col] + (col - 1 < 0 || col + 1 > rows ? 0 : this._triangle[row - 1, col - 1]);
        }

        static string EasterEgg()
        {
            PascalTriangle pt1 = new PascalTriangle(20),
                pt2 = new PascalTriangle(20, true);

            return $"{pt1.ToString()}\n{pt2.ToString()}";
        }

        public override string ToString()
        {
            string res = "";
            int lastRowLength = GetRowLength(this._rows - 1),
                lastCurrRowDiff,
                halfDiff;
            bool isEven;

            int GetRowLength(int row)
            {
                if (this._rows < row) return 0;
                var len = new List<int>();

                for (int col = 0; col < this._rows; col++)
                    if (this._triangle[row, col] != 0)
                        len.Add(this._triangle[row, col]);

                return string.Join(' ', len.ToArray()).Length;
            }

            string ForLoopWrapper(int row)
            {
                lastCurrRowDiff = lastRowLength - GetRowLength(row);
                isEven = lastCurrRowDiff % 2 == 0;
                halfDiff = lastCurrRowDiff / 2;

                res += "".PadLeft(isEven ? halfDiff : (int)((lastCurrRowDiff - 1) / 2), ' ');

                for (int col = 0; col < this._rows; col++)
                    if (this._triangle[row, col] != 0) res += $"{this._triangle[row, col]} ";

                return $"{res.Substring(0, res.Length - 1)}{"".PadLeft(isEven ? halfDiff : (int)((lastCurrRowDiff + 1.5) / 2), ' ')}\n";
            }


            if (!this._easterEgg)
                for (int row = 0; row < this._rows; row++)
                    res = ForLoopWrapper(row);
            else
                for (int row = this._rows - 1; row >= 0; row--)
                    res = ForLoopWrapper(row);

            return res.Substring(0, res.Length - 1);
        }
    }
}