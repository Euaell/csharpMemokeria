using System;
using System.Collections.Generic;

namespace memokeria
{
    class Grid
    {
        private int Row, Column;
        private Cell[,] ond;

        public Grid(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
            ond = new Cell[Row, Column];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    ond[i, j] = new Cell('*');
                }
            }
        }

        public int MulArr(List<int[]> arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Count - 1; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i][0]/arr[i][1] == arr[j][0]/arr[j][1])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public bool CheckRow(int ro)
        {
            //if return true its possible to place in that row
            bool r = true;
            for (int i = 0; i < Column; i++)
            {
                if (ond[ro, i].Value == 'S')
                {
                    return false;
                }
            }
            return r;
        }
        public bool CheckColumn(int co)
        {
            //if return true its possible to place in that row
            bool r = true;
            for (int i = 0; i < Row; i++)
            {
                if (ond[i, co].Value == 'S')
                {
                    return false;
                }
            }
            return r;
        }
        public bool CheckDiagonal(int ro, int co)
        {
            bool r = true;
            int upper1 = Row - ro > Column - co ? Column - co : Row - ro;
            int upper2 = ro > Column - co ? Column - co : ro;
            int upper3 = ro > co ? co : ro;
            int upper4 = co > Row - ro ? Row - ro : co;
            // to the right bottom
            for (int i = 1; i < upper1; i++)
            {
                if (ond[ro + i, co + i].Value == 'S' )
                {
                    return false;
                }
            }
            // to the right top
            for (int i = 1; i < upper2; i++)
            {
                if (ond[ro - i, co + i].Value == 'S' )
                {
                    return false;
                }
            }
            // to the left top
            for (int i = 1; i <= upper3; i++)
            {
                if (ond[ro - i, co - i].Value == 'S' )
                {
                    return false;
                }
            }
            // to the left bottom
            for (int i = 1; i < upper4; i++)
            {
                if (ond[ro + i, co - i].Value == 'S' )
                {
                    return false;
                }
            }
            
            return r;
        }
        public bool CheckStraightLine(int ro, int co)
        {
            bool r = true;
            List<int[]> angles = new List<int[]>();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (i == ro || j == co)
                        continue;

                    if (ond[i, j].Value == 'S')
                        angles.Add(new []{Math.Abs(ro - i), Math.Abs(co - j)});
                }
            }

            if (MulArr(angles) > 0)
            {
                return false;
            }
            return r;
        }
        public void Reset()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    ond[i, j] = new Cell('*');
                }
            }
        }
        
        public void JustRC()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (CheckRow(i) && CheckColumn(j))
                        ond[i, j] = new Cell('S');
                }
            }
            
        }
        public void RCandD()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (CheckRow(i) && CheckColumn(j) && CheckDiagonal(i, j))
                        ond[i, j] = new Cell('S');
                }
            }
            
        }
        public void StrLine()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (CheckRow(i) && CheckColumn(j) && CheckDiagonal(i, j) && CheckStraightLine(i, j))
                        ond[i, j] = new Cell('S');
                }
            }
        }
        private bool placeOnRow(int ro, int cs = 0)
        {
            bool r = false;
            for (int j = cs; j < Column; j++)
            {
                if (CheckRow(ro) && CheckColumn(j) && CheckDiagonal(ro, j) && CheckStraightLine(ro, j))
                {
                    ond[ro, j].Value = 'S';
                    r = true;
                }
            }
            return r;
        }
        public void FillGrid(int n)//Doesn't work
        {
            int rt = 0;
            int xi = 0;
            while (xi < n && rt < Row)
            {
                xi = 0;
                this.Reset();
                for (int i = 0; i < Row; i++)
                {
                    this.placeOnRow(i, rt);
                    xi++;
                    rt++;
                }
            }

            if (xi < n)
            {
               Console.WriteLine("Impossible to Fill!"); 
            }
        }
        public void EnterS(int n)
        {
            int c = 0;
            for (int i = 0; i < Column; i++)
            {
                c = 0;
                for (int k = 0; k < Row; k++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        if (k == 0)
                            j = k;
                        if (CheckRow(k) && CheckColumn(j) && CheckDiagonal(k, j) && CheckStraightLine(k, j))
                        {
                            ond[k, j] = new Cell('S');
                            c++;
                            break;
                        }
                    }
                }

                if (c >= n - 1)
                    break;
            }

            if (c < n)
                Console.WriteLine("Not Possible!");
        }
        public void DisplayGrid()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Console.Write($"{ond[i, j].Value}  ");
                }
                Console.WriteLine();
            }
        }
        
    }
}