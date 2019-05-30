using System;

namespace ParkRide
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkRidePlan[] plans = new ParkRidePlan[]
            {
                new LimitedParkRidePlan("Punch", 15, 150.00m),
                new ParkRidePlan(),
                new TieredParkRidePlan(),
                new ParkRidePlan("Credit", 0, 0.00m, 16.50m)
            };

            Console.WriteLine("Rides\tBest Plan\tCost Per");

            for (int i = 1; i <= 20; i++)
            {
                for (int p = 0; p < plans.Length; p++)
                {
                    if (plans[p] != null)
                    {
                        if (!plans[p].Use())
                            plans[p] = null;
                    }
                }

                ParkRidePlan bestPlan = ParkRidePlanAnalyzer.FindBestPlan(plans);

                Console.WriteLine($"{i}\t{bestPlan.Name}\t{bestPlan.GetCostPerRide().ToString("C2")}");
            }
            Console.ReadLine();
        }
    }
}
