using System;
using System.Net;
using CMLTools;

namespace CMLTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================== Welcome to CML Tools ========================");
            while(true)
            {
                int meno = menuNo();
                switch (meno)
                {
                    case 1:
                        getInfo();
                        waitKey();
                    break;
                    case 0:
                        Console.WriteLine("Thank you for choosing Office IT - 063-116-7898");
                        waitKey();
                        Environment.Exit(1);
                    break;
                }
            }   
        }
        static void getInfo()
        {
            NetworkTools netTools = new NetworkTools();
            netTools.getIPInfo();
        }
        public static int  menuNo(){
            Console.WriteLine("===================== Select one option for excution =====================");
            Console.WriteLine("1.This computer info");
            Console.WriteLine("0.Exit program");

            try
            {
                int menu = 0;
                Console.Write("Choose program number : "); 
                menu = int.Parse(Console.ReadLine());
                return menu;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error :"+ e.Message);
                Console.ResetColor();

                return 1;
            }
          
        }
        static void waitKey()
        {
            Console.ReadLine();
        }
    }
}
