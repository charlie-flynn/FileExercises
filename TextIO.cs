using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExercises
{
    internal class TextIO
    {
        public void Run()
        {
            string path = @"test.txt";

            // If the file this is about to make doesnt already exist, make a text file and write some text into it
            if (!File.Exists(path))
            {
                try
                {
                    StreamWriter writer = new StreamWriter(path, false);
                    writer.WriteLine("Hello");
                    writer.WriteLine("And");
                    writer.WriteLine("Welcome! (awesome)");
                    writer.Close();

                    // Dispose of the StreamWriter
                    try
                    {
                        writer.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

            // Read the file and print out every single line in it
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string str;

                    while ((str = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
