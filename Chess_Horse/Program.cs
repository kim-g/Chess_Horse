using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Horse
{
    class Program
    {
        static string FileName;

        static void Main(string[] args)
        {
            Create_Out_File();
            Head();
            int MaxStep = 1;
            int Record = 0;
            const int Steps = 100000;

            for (int Step = 1; Step <= Steps; Step ++)
            {
                WriteLine("================================================================");
                WriteLine("Шаг " + Step.ToString());
                WriteLine("");

                Game NewGame = new Game();
                Write(NewGame.Result());
                WriteLine("Результат: ");
                if (NewGame.FinalStep > MaxStep)
                {
                    WriteLine("!!! Новый рекорд: " + NewGame.FinalStep + " шагов !!!");
                    MaxStep = NewGame.FinalStep;
                    Record = Step;
                }
                if (NewGame.FinalStep == 64)
                {
                    WriteLine("!!! ПОБЕДА !!! Вся доска пройдена !!!");
                    MaxStep = NewGame.FinalStep;
                    Console.WriteLine("!!! ПОБЕДА !!! Вся доска пройдена !!!");
                    Console.ReadKey();
                    return;
                }
                WriteLine("Цель не достигнута");
                WriteLine("");
                WriteLine("");
            }

            WriteLine("================================================================");
            WriteLine("Всего шагов: " + Steps.ToString());
            WriteLine("Рекорд: " + MaxStep.ToString() + " из 64 (Шаг " + Record.ToString() + ").");
            Console.ReadKey();
        }

        static void Create_Out_File()
        {
            FileName = "Out " + DateTime.Now.ToString().Replace('.', '-').Replace(':', '-') + ".txt";
        }

        static void WriteLine(string Text)
        {
            StreamWriter Out = new StreamWriter(FileName, true);
            Out.WriteLine(Text);
            Out.Close();
        }

        static void Write(string Text)
        {
            StreamWriter Out = new StreamWriter(FileName, true);
            Out.Write(Text);
            Out.Close();
        }

        static void Head()
        {
            WriteLine("****************************************************************");
            WriteLine("*                      Обойди конём доску                      *");
            WriteLine("*                         Автор Г. Ким                         *");
            int SpaceAfter = (62 - DateTime.Now.Date.ToLongDateString().Length) / 2;
            int SpaceBefore = 62 - DateTime.Now.Date.ToLongDateString().Length - SpaceAfter;
            string s = "*" + new string(' ', SpaceBefore) +
                DateTime.Now.Date.ToLongDateString() + new string(' ', SpaceAfter) + "*";
            WriteLine(s);
            WriteLine("****************************************************************");
            WriteLine("");
        }
    }
}
