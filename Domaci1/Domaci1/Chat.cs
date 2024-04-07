using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Domaci1
{
    internal class Chat
    {
        public List<Developer> developerList;
        public List<QA> qaList;

        public delegate void HandleMsg(string message);

        event HandleMsg EvenetMsgHandler;


        public Chat()
        {
            developerList = new List<Developer>();
            qaList = new List<QA>();
        }



        // data bilo kog programera da ne bih morao da ponavaljam isti kod
        internal class DeveloperData
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public float Salary { get; set; }
            public int Id { get; set; }
        }
        internal enum UserType
        {
            Developer = 1,
            QA = 2
        }

        private T ValidateHelper<T>(string msg, UserType programmerType = UserType.Developer)
        {
            T option;
            bool isValidInput = false;
            bool checkIfExists = false;
            bool checkSalary = false;

            do
            {
                Console.WriteLine($"{msg}:");
                string input = Console.ReadLine();

                if (typeof(T) == typeof(int))
                {
                    isValidInput = int.TryParse(input, out int result);

                    if (!isValidInput)
                    {
                        option = (T)(object)0;
                        continue;
                    }
                    else if (programmerType == UserType.Developer)
                    {
                        checkIfExists = developerList.TrueForAll(obj => obj.Id != result);

                        if (!checkIfExists)
                        {
                            isValidInput = false;
                        }
                        else
                        {
                            isValidInput = true;
                        }
                    }
                    else
                    {
                        checkIfExists = qaList.TrueForAll(obj => obj.Id != result);
                        if (!checkIfExists)
                        {
                            isValidInput = false;
                        }
                        else
                        {
                            isValidInput = true;

                        }
                    }


                    option = (T)(object)result;
                }
                else if (typeof(T) == typeof(float))
                {
                    isValidInput = float.TryParse(input, out float result);

                    if (result < 1000)
                    {
                        checkSalary = true;
                        isValidInput = false;

                    }
                    else
                    {
                        checkSalary = false;
                    }

                    option = (T)(object)result;
                }
                else if (typeof(T) == typeof(string))
                {
                    isValidInput = !string.IsNullOrWhiteSpace(input);
                    option = (T)(object)input;
                }
                else
                {
                    throw new NotSupportedException($"Type '{typeof(T)}' is not supported for validation.");
                }

                if (!isValidInput)
                {
                    if (checkIfExists)
                    {
                        Console.WriteLine("Programer sa tim id-jem vec postoji\n");
                    }
                    else if (checkSalary)
                    {
                        Console.WriteLine("Uneli ste neispravnu platu \n");

                    }
                    else
                    {
                        Console.WriteLine("Neispravan unos\n");

                    }
                }

            } while (!isValidInput);

            return option;
        }

        private DeveloperData ValidateDeveloperData(UserType programmerType)
        {
            DeveloperData developerData = new DeveloperData();

            Console.WriteLine("Unesite podatke novog programera:");
            developerData.Name = ValidateHelper<string>("Ime");
            developerData.Surname = ValidateHelper<string>("Prezime");
            developerData.Salary = ValidateHelper<float>("Unesite platu programera (ne sme biti manja od 1000$)");

            // potrebno je da znamo koji prgrammer (developer ili QA) da bi smo proverili da li u taj niz ima mesta
            developerData.Id = ValidateHelper<int>("Id", programmerType);
            return developerData;
        }

        private void unesiNovogProgramera(UserType programmerType)

        {
            if (programmerType == UserType.Developer)
            {
                DeveloperData devData = ValidateDeveloperData(programmerType);

                Developer newDev = new Developer(devData.Id, devData.Name, devData.Surname, devData.Salary);
                developerList.Add(newDev);
                OpenSettings();


            }
            else
            {
                DeveloperData devData = ValidateDeveloperData(programmerType);
                QA newQA = new QA(devData.Id, devData.Name, devData.Surname, devData.Salary);
                qaList.Add(newQA);
                OpenSettings();


            }


        }

        public void printProgrammers()
        {
            Console.WriteLine("Developers:\n");
            foreach (var item in developerList)
            {
                Console.WriteLine(item.Info());

            }
            Console.WriteLine("\n QA testers:\n");
            foreach (var item in qaList)
            {
                Console.WriteLine(item.Info());

            }
            Console.WriteLine("\n");

            OpenSettings();
            
        }


        private void IzbrisiProgramera(UserType programmerType)
        {
            Console.WriteLine("Unosom 'kraj' izlazite iz programa:");
            Console.WriteLine("Unesite id programera kojeg zelite izbrisati:");
            string idInput = Console.ReadLine();
            if (idInput.ToLower() == "kraj")
            {
                return;

            }
            int id;
            if (int.TryParse(idInput, out id))
            {
                if (programmerType == UserType.Developer)
                {
                    Developer developerToDelete = developerList.FirstOrDefault(obj => obj.Id == id);

                    if (developerToDelete != null)
                    {
                        developerList.Remove(developerToDelete);
                        Console.WriteLine("uspesno ste izbrisali developera \n");

                        OpenSettings();


                    }
                    else
                    {
                        Console.WriteLine("Developer sa tim id-jem ne postoji\n");
                        IzbrisiProgramera(programmerType);
                    }
                }
                else
                {
                    QA developerToDelete = qaList.FirstOrDefault(obj => obj.Id == id);
                    if (developerToDelete != null)
                    {
                        qaList.Remove(developerToDelete);
                        Console.WriteLine("uspesno ste izbrisali QA testera \n");

                        OpenSettings();


                    }
                    else
                    {
                        Console.WriteLine("Pogrammer sa tim id-jem ne postoji\n");


                    }
                }

            }
            else
            {
                Console.WriteLine("Neispravan unos:\n");
                IzbrisiProgramera(programmerType);
            }

        }

        private void izmeniProgramera(UserType programmerType)
        {

            Console.WriteLine("Unesite id programera kojeg zelite menjati:\n");
            Console.WriteLine("Unosom 'kraj' izlazite iz programa:");



            string idInput = Console.ReadLine();
            if (idInput.ToLower() == "kraj")
            {
                return;

            }
            int id;
            if (int.TryParse(idInput, out id))
            {
                if (programmerType == UserType.Developer)
                {
                    Developer developerToUpdate = developerList.FirstOrDefault(obj => obj.Id == id);

                    if (developerToUpdate != null)
                    {


                        developerToUpdate.Name = ValidateHelper<string>("Ime");
                        developerToUpdate.Surname = ValidateHelper<string>("Prezime");
                        developerToUpdate.Salary = ValidateHelper<float>("Unesite platu programera (ne sme biti manja od 1000$)");
                        OpenSettings();

                    }
                    else
                    {
                        Console.WriteLine("Developer sa tim id-jem ne postoji\n");
                        izmeniProgramera(programmerType);
                    }


                }
                else
                {
                    QA developerToUpdate = qaList.FirstOrDefault(obj => obj.Id == id);
                    if (developerToUpdate != null)
                    {
                        developerToUpdate.Name = ValidateHelper<string>("Ime");
                        developerToUpdate.Surname = ValidateHelper<string>("Prezime");
                        developerToUpdate.Salary = ValidateHelper<float>("Unesite platu programera (ne sme biti manja od 1000$)");
                        OpenSettings();
                    }
                    else
                    {
                        Console.WriteLine("Pogrammer sa tim id-jem ne postoji\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Neispravan unos:\n");
                izmeniProgramera(programmerType);
            }
        }
        public bool firstModal()
        {
            Console.WriteLine("\n PODESAVANJA \n");


            Console.WriteLine("1- Unos,izmena i brisanje podataka o programerima\n2- Posalji poruku\n3-Exit");


            string enterInput;
            int enterOption;

            do
            {

                Console.WriteLine("Unesite opciju:");
                enterInput = Console.ReadLine();

            } while ((!int.TryParse(enterInput, out enterOption)) ||( enterOption > 3 || enterOption <0));

            if (enterOption == 1)
            {
                return true;
            }else if(enterOption == 2)
            {
                Console.WriteLine("Unesite id Developera koji salje poruku:");
                string input = Console.ReadLine();
                if(int.TryParse(input, out int id))
                {
                    var findDev = developerList.FirstOrDefault(obj => obj.Id == id);
                    if(findDev == null)
                    {
                        Console.WriteLine("Takav id ne postoji\n");
                    }
                    else
                    {
                        Console.WriteLine("Unesi te poruku");
                        string msg = Console.ReadLine();
                        Developer sender = developerList.FirstOrDefault(obj=>obj.Id==id);
                        msg += $"\nPoruka je od developera {sender.Name}";

                        if (msg.StartsWith("feature/"))
                        {
                            foreach (var item in developerList)
                            {
                                EvenetMsgHandler += item.printMessage;

                                
                            }
                        }else if (msg.StartsWith("testing/"))
                        {
                            Console.WriteLine("poruke je pocela sa testing\n");
                            foreach (var item in qaList)
                            {
                                EvenetMsgHandler += item.printMessage;
                            }
                        }
                        else
                        {
                            foreach (var item in qaList)
                            {
                                EvenetMsgHandler += item.printMessage;
                            }

                            foreach (var item in developerList)
                            {
                                EvenetMsgHandler += item.printMessage;

                            }

                        }

                        EvenetMsgHandler(msg);
                        EvenetMsgHandler = null;


                    }

                }
                else
                {

                    Console.WriteLine("Uneli ste neispravan unos\n");
                }




            }
            else if(enterOption == 3)
            {
                return false;
            }
            return true;

        }

        public bool secondModal()
        {
            Console.WriteLine("\n UPRAVLJAJ PROGRAMERIMA \n");
            Console.WriteLine("1-unos novog Developera\r\n2-izmena Developera\r\n3-brisanje Developera\r\n4-unos novog QA\r\n5-izmena QA\r\n6-brisanje QA\r\n7-Ispis\r\n0-nazad\\");
            string input;
            int option;
            do
            {
                Console.WriteLine("Unesite opciju:");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out option) || (option > 7 || option < 0));

            switch (option)
            {
                case 1:
                    unesiNovogProgramera(UserType.Developer);
                    break;
                case 2:
                    izmeniProgramera(UserType.Developer);
                    break;
                case 3:
                    IzbrisiProgramera(UserType.Developer);
                    break;
                case 4:
                    unesiNovogProgramera(UserType.QA);
                    break;
                case 5:
                    izmeniProgramera(UserType.QA);
                    break;
                case 6:
                    IzbrisiProgramera(UserType.QA);
                    break;
                case 7:
                    printProgrammers();
                    break;
                case 0:
                    OpenSettings();
                    break;

            }
            return true;


        }
        public void OpenSettings()
        {


            bool checkFirstModal = firstModal();

            if (!checkFirstModal)
            {
                return;
            }
            else
            {
                secondModal();
            }


        }
    }
}
