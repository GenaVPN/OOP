using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA8_1
{
    internal class Program
    {

        Program()
        {
            ExDelPer = Ignor;
        }

        public void Ignor(Exception ex)
        {

        }

        public void SendMessage(Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        public void LogFile(Exception ex)
        {
            using (StreamWriter file = new StreamWriter("Log.txt", true))
            {
                file.WriteLine(ex.Message);
                Console.WriteLine("Ошибка записана");
            }
        }

        public enum strategy { Ignor, Message, Logging }

        public void ChangeStrategy(strategy s)
        {
            if (s == strategy.Logging)
            {
                ExDelPer = LogFile;
            }
            if (s == strategy.Message)
            {
                ExDelPer = SendMessage;
            }
            if (s == strategy.Ignor)
            {
                ExDelPer = Ignor;
            }
        }

        public delegate void ExDel(Exception ex);
        ExDel ExDelPer;

        public void SendEx(int a, int b)
        {
            try
            {
                int ret = a / b;
                Console.WriteLine($"Код выполнен: {a}/{b} = {ret}");
            }
            catch (Exception ex)
            {

                ExDelPer(ex);
            }


        }
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.SendEx(5, 0);

            pr.ChangeStrategy(strategy.Logging);
            pr.SendEx(5, 0);

            pr.ChangeStrategy(strategy.Message);
            pr.SendEx(5, 0);



        }




    }
}
