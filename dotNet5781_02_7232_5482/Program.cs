﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_7232_5482
{

    //  enum Options { InsertBus, InsertStation, RemoveBus, RemoveStation, LinesPassStation, LinesPassRoute, PrintAllLines, PrintStations, Exit };
    class Program
    {


        static void Main(string[] args)
        {
            List<BusStation> AllStations = new List<BusStation>();
            BusCollection b = new BusCollection();
            //initialize();
            CHOICE choice;
            do
            {
                Console.WriteLine("Make your mind:");
                Console.WriteLine("ADD,DELETE,FIND,PRINT,EXIT= -1");
                bool success = Enum.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case CHOICE.ADD:
                        break;
                    case CHOICE.DELETE:
                        break;
                    case CHOICE.FIND:
                        break;
                    case CHOICE.PRINT:
                        break;
                    case CHOICE.EXIT:
                        break;
                    default:
                        break;
                }

            } while (choice != CHOICE.EXIT);
        }

        static public void AddNew()
        {
            try
            {
                Console.WriteLine("Enter 1 if you want to add bus line,Enter 2 if you want to add station);



            int choice = int.Parse(Console.ReadLine();
                if (choice != 1 || choice != 2)
                    throw new BusException("your choice is incorrect");
                else if (choice == 1)
                    AddNewBus();


            }
            catch (FormatException)
            {
                Console.WriteLine("The value must be numeric");
            }



        }
        static public void AddNewBus()
        {
        }
        static public string GetNumBus()
        {
            int numbus = int.Parse(Console.ReadLine());
            if (numbus >= 1000000)
                throw new BusException(The bus number you entered is incorrect);
            else
                returm numbus.Tostring();
        }
        static int

    }





    }
