using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prezentacije
{
    internal class Program
    {

        class Student:IComparable<Student>
        {

            private static int lastId=0;

            
            public string Ime { get; set; }
            public int Id { get; set; }

            public int Ocena { get; set; }

            public Student(string ime, int ocena)
            {
                Ime = ime;
                Id = ++lastId;
                Ocena = ocena;
            }
    
            public int CompareTo(Student other)
            {
                if(this.Ocena < other.Ocena) return -1;
                if(this.Ocena > other.Ocena) return 1;
                return 0;
            }
        }
        static void Main(string[] args)
        {
            int buffSize = 4096;
            Stream inStream = File.OpenRead(@"C:\Users\gorce\copyme\copymefile.txt");

            Stream outStream = File.Open(@"C:\Users\gorce\copyme\copyme1.txt", FileMode.OpenOrCreate);

            Byte[] buffer = new Byte[buffSize]; // buffer size

            int numBytesRead;


            while ((numBytesRead = inStream.Read(buffer, 0, buffSize)) > 0)
            {
                outStream.Write(buffer, 0, numBytesRead);
            }
            inStream.Close();
            outStream.Close();



            // ICompareTo

            Student hamza = new Student("hamza", 10);
            Student haris = new Student("haris", 10);
            Student semra = new Student("semra", 11);




            List<Student> ListaStudenata = new List<Student>();

            ListaStudenata.Add(hamza);
            ListaStudenata.Add(haris);
            ListaStudenata.Add(semra);
            ListaStudenata.Sort();

            var enumer = ListaStudenata.GetEnumerator();

            while (enumer.MoveNext())
            {
                var student = enumer.Current;
                Console.WriteLine($"Ocena studenta: {student.Ocena}");
            }





            // hash tabeles

            HashSet<Student> hashStudents = new HashSet<Student>();

            Hashtable hashtable = new Hashtable();

            hashtable.Add(hamza.Id, hamza);
            hashtable.Add(semra.Id, semra);
            hashtable.Add(haris.Ocena, haris);

            foreach (DictionaryEntry entry in hashtable) {
                var temp = (Student)entry.Value;

                Console.WriteLine($"{temp.Ime} Ocena:{temp.Ocena}");

            }

            hashStudents.Add(hamza);



            // upis u fajlove iz studens liste




          

           

                Console.WriteLine("should read");
                
            using(Stream openToWrite = File.Open(@"C:\Users\gorce\studentFile.txt", FileMode.OpenOrCreate))
            {
                foreach (Student obj in ListaStudenata)
                {
                    StreamWriter writer = new StreamWriter(openToWrite);
                    string line = $"{obj.Ime} Ocena:{obj.Ocena} ID:{obj.Id}\n";

                    writer.Write(line);
                   

                    Console.WriteLine("added");

                }
            }
                using (Stream opentToRead = File.OpenRead(@"C:\Users\gorce\studentFile.txt"))
                {
                    StreamReader sr = new StreamReader(opentToRead);

                    string content = sr.ReadToEnd();
                    Console.WriteLine(content);
                }
           

                    





            Console.ReadLine();
    }
}
}
