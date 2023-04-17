internal class MainMenuPresenter : IPresenter
    {
        public IPresenter Action()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new ShowAllUsers();
                case ConsoleKey.D2:
                    return new ShowUser();
                case ConsoleKey.D0:
                    return null;
                default:
                    return this;
            }
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine("Accounting Of Consumed Electricity");
            Console.WriteLine();
            Console.WriteLine("1 - Show All Users");
            Console.WriteLine("2 - Show User Info");
            Console.WriteLine("3 - Find Debtor");
            Console.WriteLine("0 - Exit");
        }
    }