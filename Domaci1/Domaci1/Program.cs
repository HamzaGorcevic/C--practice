using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Developer newDev = new Developer(2, "hamza", "gorcevic", 3222);
            Developer newDev1 = new Developer(3, "haris", "gorcevic", 3222);
            Developer newDev2 = new Developer(3, "semra", "gorcevic", 3222);
            QA newQA = new QA(1, "semra", "gorcevic", 3222);


            List<QA> newQAList = new List<QA>();
            newQAList.Add(newQA);


            List<Developer> listDev = new List<Developer>();
            listDev.Add(newDev1);
            listDev.Add(newDev2);
            listDev.Add(newDev);

            Chat chat1 = new Chat();

            chat1.developerList = listDev;
            chat1.qaList = newQAList;

            chat1.OpenSettings();

        }
    }
}
