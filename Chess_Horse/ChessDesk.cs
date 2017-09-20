using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Horse
{
    class ChessDesk
    {
        int[,] Data = new int[8,8];

        public ChessDesk()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Data[i, j] = 0;
        }

        public void Set(Point position, int Value)
        {
            if (position.x < 0 || position.x > 7) return;
            if (position.y < 0 || position.y > 7) return;
            Data[position.x, position.y] = Value;
        }

        public int Get(Point position)
        {
            if (position.x < 0 || position.x > 7) return 0;
            if (position.y < 0 || position.y > 7) return 0;
            return Data[position.x, position.y];
        }

        public bool IsAvaliable(Point Pos)
        {
            if (Pos.x < 0 || Pos.x > 7) return false;
            if (Pos.y < 0 || Pos.y > 7) return false;
            if (Get(Pos) > 0) return false;
            return true;
        }
    }
}
