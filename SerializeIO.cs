using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExercises
{
    struct Contact
    {
        public string name;
        public string email;
        public int id;
        public Contact(string name, string email, int id)
        {
            this.name = name;
            this.email = email;
            this.id = id;
        }
        public void Print()
        {
            Console.WriteLine(name + " | " + email + " | " + id);
        }
        public void Serialize(string path)
        {
            // write the values of name, email, and id into a file
            try
            {
                // create the folder named contacts if it doesnt exist
                if (!File.Exists(@"contacts"))
                {
                    Directory.CreateDirectory(@"contacts");
                }

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(name);
                    writer.WriteLine(email);
                    writer.WriteLine(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeSerialize(string path)
        {
            // get the values from the file and put them into the contact object
            // convert the id from a string into an int before putting it back
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string str;

                    name = reader.ReadLine();
                    email = reader.ReadLine();
                    int.TryParse(reader.ReadLine(), out int result);
                    id = result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    internal class SerializeIO
    {
        public void Run()
        {
            // make 3 contacts
            Contact bob = new Contact("Bob", "bobrobloxgaming@gmail.com", 1234);
            Contact jane = new Contact("Jane", "janessica.jove.business@gmail.com", 2345);
            Contact fred = new Contact("Fred", "freddyfivebears@gmail.com", 5555);

            // write each contact to a file
            bob.Serialize(@"contacts\bob.txt");
            fred.Serialize(@"contacts\fred.txt");
            jane.Serialize(@"contacts\jane.txt");

            // clear out contacts
            bob = new Contact();
            jane = new Contact();
            fred = new Contact();

            // load contacts from file
            bob.DeSerialize(@"contacts\bob.txt");
            fred.DeSerialize(@"contacts\fred.txt");
            jane.DeSerialize(@"contacts\jane.txt");

            // print contacts
            bob.Print();
            fred.Print();
            jane.Print();
            Console.ReadKey();
        }
    }
}
