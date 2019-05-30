using System;

namespace ParkRide
{
    public static class ParkRidePlanAnalyzer
    {
        public static ParkRidePlan FindBestPlan(params ParkRidePlan[] args)
        {
            decimal minCost = 100000.00M;
            string cheapestPlan = null;

            foreach (var plan in args)
            {
                if (plan.GetCostPerRide() < minCost)
                {
                    minCost = plan.GetCostPerRide();
                    cheapestPlan = plan.Name;
                }
            }
            return (cheapestPlan != null) ? Array.Find(args, e => e.Name == cheapestPlan) : null;
        }
    }
}