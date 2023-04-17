public class User
    {
        public User(int apartmentNumber, string? address, string? surname, int inputDisplayOfTheElectricityMeter, 
            int outputDisplayOfTheElectricityMeter, DateTime dateOfTheReading)
        {
            ApartmentNumber = apartmentNumber;
            Address = address;
            Surname = surname;
            InputDisplayOfTheElectricityMeter = inputDisplayOfTheElectricityMeter;
            OutputDisplayOfTheElectricityMeter = outputDisplayOfTheElectricityMeter;
            DateOfTheReading = dateOfTheReading;
        }

        public int ApartmentNumber { get; set; }
        public string? Address { get; set; }
        public string? Surname { get; set; }
        public int InputDisplayOfTheElectricityMeter { get; set; }
        public int OutputDisplayOfTheElectricityMeter { get; set; }
        public DateTime DateOfTheReading { get; set; }
    }