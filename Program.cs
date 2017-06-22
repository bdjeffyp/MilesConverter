using System;

namespace MilesConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            double miles = 4.5;
            double feet = 0.0;
            double inches = 0.0;
            double totalInches = 0.0;
            const double FEET_PER_MILE = 5280.0;
            const double INCHES_PER_FOOT = 12.0;
            const double MILE_PER_KM = 1.60934;
            double kilometers = 0.0;
            const int KM_FLAG = 1;
            const int FEET_FLAG = 2;
            int option = FEET_FLAG;

            // Title and purpose
            Console.WriteLine("Miles Conversion");
            Console.WriteLine("By Jeff Peterson");

            Console.WriteLine("\nProvide the number of miles and");
            Console.WriteLine("it will be converted to you choice of");
            Console.WriteLine("kilometers or feet and inches.");

            // Receive the input from the user.
            // TODO: At some point, I need to make this input test into a function...!
            while (true)
            {
                Console.Write("\nHow many miles to convert? ");
                
                // Did we get a valid input from the user?  If not, try again.
                if (double.TryParse(Console.ReadLine(), out miles) == false)
                {
                    Console.WriteLine("\nThat is not a valid input for miles.  Try again.");
                    continue;
                }

                // We got a number at least, now let's check that it is positive.
                if (miles < 0.0)
                {
                    Console.WriteLine("\nThat is not a valid input for miles.  It must be positive.");
                    continue;
                }
                // We also need to limit the maximum number of miles to be converted to avoid problems.
                else if (miles > 10000000)
                {
                    Console.WriteLine("\nThat is too many miles to convert.  It must be smaller than 10 billion miles.");
                    continue;
                }
                else        // miles >= 0.0
                {
                    break;
                }
            }

            // Now check if we are converting to feet and inches or to kilometers.
            while (true)
            {
                Console.WriteLine("\nDo you want to convert to");
                Console.WriteLine("1) kilometers");
                Console.WriteLine("2) feet /inches");
                Console.Write("Choice: ");

                // Did we get a valid input from the user?  If not, try again.
                if (int.TryParse(Console.ReadLine(), out option) == false)
                {
                    Console.WriteLine("\nThat is not a valid input.  Try again.");
                    continue;
                }

                // We got a number at least, now let's check if it is one of our options.
                if (option < KM_FLAG || option > FEET_FLAG)       // Invalid choice!
                {
                    Console.WriteLine("\nThat is not a valid choice.  Try again.\n");
                    continue;

                }
                else        // Valid
                {
                    break;
                }
            }

            // Now for some converting based on the user's choice!
            Console.WriteLine("\nOkay, the number of miles being converted is {0:f2}...", miles);

            switch (option)
            {
                case FEET_FLAG:
                    feet = FEET_PER_MILE * miles;
                    inches = (feet - (long)feet) * INCHES_PER_FOOT;
                    totalInches = INCHES_PER_FOOT * feet;
                    // Cast the feet and inches so that they don't round up the values.
                    Console.WriteLine("There are {0:f0}' {1:f0}\" in {2:f2} miles", (long)feet, (long)inches, miles);
                    Console.WriteLine("There are {0:f0}\" total in {1:f2} miles", totalInches, miles);
                    break;

                case KM_FLAG:
                    kilometers = MILE_PER_KM * miles;
                    Console.WriteLine("There are {0:f2} km in {1:f2} miles", kilometers, miles);
                    break;

                default:
                    Console.WriteLine("I don't know how you got here... Time for some troubleshooting!");
                    break;
            }
        }
    }
}
