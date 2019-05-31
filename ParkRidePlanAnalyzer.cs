using System;

namespace ParkRide
{
    public static class ParkRidePlanAnalyzer
    {
        public static ParkRidePlan FindBestPlan(ParkRidePlan[] plans)
        {
            ParkRidePlan cheapestPlan = new ParkRidePlan();
            cheapestPlan.Use();

            foreach (var plan in plans)
            {
                try
                {
                    if (plan.GetCostPerRide() < cheapestPlan.GetCostPerRide())
                    {
                        cheapestPlan = plan;
                    }
                }
                catch (Exception ex)
                {
                }

            }
            return cheapestPlan;
        }
    }
}