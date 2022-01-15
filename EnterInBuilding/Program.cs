using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnterInBuilding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This is Simply File Creator with Doctionary, Who Check that
            // Who is in Building.
            // We made Dictonary for take Two Argument Person Name and Boolean 
            // We use Boolean to say that Person is  In BUilding or Not
            Dictionary<string, bool> Person = new Dictionary<string, bool>();
            Console.Write("Please Enter a Number of Person You Will Add :");
            int n = int.Parse(Console.ReadLine());
            string[] name = new string[n];
            bool[] door = new bool[n];

            
            //Creating file txt
            string Build = @"C:\Users\Windows10\source\repos\EnterInBuilding\EnterInBuilding\Building.txt";

            FileInfo fi = new FileInfo(Build);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (fi.Exists)
                {
                    fi.Delete();
                }

                // Create a new file     
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Please Enter a Name of Person :");
                        sw.Write(name[i] = Console.ReadLine());
                        //You Must Write True or False if is True He is in Building
                        // OR
                        // False he is out of Building

                        sw.Write(" ");
                        Console.Write("Please Enter a True or False :");
                        sw.WriteLine(door[i] = bool.Parse(Console.ReadLine()));
                    }
                    for (int i = 0; i < n; i++)
                    {
                        // Here add person in Dictonary 
                        Person.Add(name[i], door[i]);
                    }
                    
                    
                   
                }

                // Write file contents on console.     
                using (StreamReader sr = File.OpenText(Build))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                for(int i = 0; i < n;i++)
                {
                    if(door[i] ==false)
                    {
                        Console.WriteLine(name[i] + " Is not in Building = " + door[i]);
                    }
                            

                }
            }
            //Some Exception
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }
    }
}
