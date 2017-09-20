using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Horse
{
    public class Game
    {
        ChessDesk Desk;
        Point Position = new Point();
        public int FinalStep = 0;

        public Game()
        {
            Desk = new ChessDesk();

            int CurrentStep = 1;
            Desk.Set(Position, CurrentStep);

            List<Point> AvaliableSteps = StepsAvaliable();
            while (AvaliableSteps.Count > 0)
            {
                CurrentStep++;

                int Path = new Random().Next(AvaliableSteps.Count);
                Position = Step(Path);
                Desk.Set(Position, CurrentStep);
                AvaliableSteps = StepsAvaliable();
            }

            FinalStep = CurrentStep;
        }

        List<Point> StepsAvaliable()
        {
            List<Point> List = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                Point NewStep = Step(i);
                if (Desk.IsAvaliable(NewStep))
                {
                    List.Add(NewStep);
                }
            }

            return List;
        }

        

        Point Step(int Way)
        {
            Point Out = new Point();

            switch (Way)
            {
                case 1: Out.x = Position.x + 1; Out.y = Position.y + 2; break;
                case 2: Out.x = Position.x + 2; Out.y = Position.y + 1; break;
                case 3: Out.x = Position.x + 2; Out.y = Position.y - 1; break;
                case 4: Out.x = Position.x + 1; Out.y = Position.y - 2; break;
                case 5: Out.x = Position.x - 1; Out.y = Position.y - 2; break;
                case 6: Out.x = Position.x - 2; Out.y = Position.y - 1; break;
                case 7: Out.x = Position.x - 2; Out.y = Position.y + 1; break;
                case 8: Out.x = Position.x - 1; Out.y = Position.y + 2; break;
            }

            return Out;
        }

        public string Result()
        {
            string Out = "|" + new string('-', 23) + "|\n";

            for (int i = 7; i>=0; i--)
            {
                for (int j = 0; j > 7; j++)
                    Out += "|" + Desk.Get(new Point(j, i)).ToString("D2");
                Out += "|\n|" + new string('-', 23) + "|\n";

            }

            Out += "Количество шагов: " + FinalStep.ToString("D2");

            return Out;
        }
    }
}
