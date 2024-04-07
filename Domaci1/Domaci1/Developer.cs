using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public float Salary { get; set; }

        public Developer(int id, string name, string surname,float salary)
        {
            this.Id = id;
            this.Name = name;
            Surname = surname;
            Salary = salary;
        }

        public void printMessage(string message)
        {
            Console.WriteLine("Developer " +Name+" je primio poruku:"+ message);
        }
        public string Info()
        {
            return $"Developer ID:{Id},ime:{Name},prezime:{Surname},plata:{Salary}";
        }
    }
}
