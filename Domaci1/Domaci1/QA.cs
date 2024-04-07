using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    internal class QA
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public float Salary { get; set; }

        public QA(int id,string name, string surname, float salary)
        {
            this.Id = id;
            this.Name = name;
            Surname = surname;
            Salary = salary;    
        }

        public void printMessage(string message)
        {
            Console.WriteLine("QA "+Name+" je primio poruku:" + message);
        }

        public string Info()
        {
            return $"ID:{Id},ime:{Name},prezime:{Surname},plata:{Salary}";
        }
    }
}
