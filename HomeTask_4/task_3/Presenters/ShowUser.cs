internal class ShowUser : IPresenter
    {
        public IPresenter Action()
        {
            Console.ReadKey();
            return new MainMenuPresenter();
        }
        public void Show()
        {
            Console.Clear();

            try
            {
                Console.Write("Please, enter number of apartment: ");
                string apartmentToFind = Console.ReadLine() ?? "";

                var users = File.ReadAllLines(@"C:\Users\Виталий\source\repos\task4.3(sigma)\task4.3(sigma)\Info.txt");
                var apartments = users.Select(n => n.Substring(0, n.IndexOf(' '))).ToArray();

                bool printed = false;
                for (int i = 1; i < apartments.Length; i++)
                {
                    if (apartments[i].IndexOf(apartmentToFind) != -1)
                    {
                        Console.WriteLine(ShowAllUsers.CreateFormat(users, ShowAllUsers.MaxLength(users)), 
                            "Appartment", "Address", "Surname",
                            "InputDisplay", "OutputDisplay", "DateOfTheReading" + "\n");

                        string[] userInfo = users[i].Split(' ');

                        User user = new User(Int32.Parse(userInfo[0]), userInfo[1], userInfo[2], Int32.Parse(userInfo[3]),
                        Int32.Parse(userInfo[4]), DateTime.Parse(userInfo[5]));

                        string format = ShowAllUsers.CreateFormat(users, ShowAllUsers.MaxLength(userInfo));

                        Console.WriteLine(format,
                            user.ApartmentNumber,
                            user.Address,
                            user.Surname,
                            user.InputDisplayOfTheElectricityMeter,
                            user.OutputDisplayOfTheElectricityMeter,
                            user.DateOfTheReading.ToString("d", CultureInfo.CreateSpecificCulture("uk-UA")));

                        printed = true;
                        break;
                    }
                }
                if (!printed)
                {
                    Console.WriteLine("User Not Found.");
                }

                Console.WriteLine("\n" + "Press any key to continue...");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
                return;
            }
        }
    }