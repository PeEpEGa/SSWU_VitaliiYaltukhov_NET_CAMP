using System.Text;
using System.Globalization;
internal class ShowAllUsers : IPresenter
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
                var users = File.ReadAllLines(@"C:\Users\Виталий\source\repos\task4.3(sigma)\task4.3(sigma)\Info.txt");
                if (users.Length <= 0)
                {
                    return;
                }

                Console.WriteLine(users[0] + "\n");
                Console.WriteLine(CreateFormat(users, MaxLength(users)), "Appartment", "Address", "Surname",
                    "InputDisplay", "OutputDisplay", "DateOfTheReading" + "\n");


                for (int i = 1; i < users.Length; i++)
                {
                    var tempInfo = users[i].Split(" ");
                    User user = new User(Int32.Parse(tempInfo[0]), tempInfo[1], tempInfo[2], Int32.Parse(tempInfo[3]),
                        Int32.Parse(tempInfo[4]), DateTime.Parse(tempInfo[5]));


                    Console.WriteLine(CreateFormat(users, MaxLength(users)).ToString(),
                        user.ApartmentNumber,
                        user.Address,
                        user.Surname,
                        user.InputDisplayOfTheElectricityMeter,
                        user.OutputDisplayOfTheElectricityMeter,
                        user.DateOfTheReading.ToString("d", CultureInfo.CreateSpecificCulture("uk-UA")));
                }

                Console.WriteLine("\n" + "Press any key to continue...");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
                return;
            }
        }

        public static int MaxLength(string[] users)
        {
            int length = -1;
            StringBuilder temp = new StringBuilder();
            for (int i = 1; i < users.Length; i++)
            {
                temp.Append(users[i]);
                int max = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] == ' ')
                    {
                        if (max > length)
                        {
                            length = max;
                        }
                        max = 0;
                        continue;
                    }
                    max++;
                }
                if (max > length)
                {
                    length = max;
                }
                temp = new StringBuilder();
            }
            return length;
        }

        public static string CreateFormat(string[] users, int length)
        {
            StringBuilder format = new StringBuilder();
            int len = users[1].Split(' ').Length;
            for (int i = 0; i < len; i++)
            {
                format.Append("{" + i + ",-" + (length + 10) + "}");
            }
            return format.ToString();
        }
    }