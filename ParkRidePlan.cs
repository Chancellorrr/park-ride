using System;

namespace ParkRide
{
    public class ParkRidePlan
    {
        public ParkRidePlan(string name, int prepaid, decimal planCost, decimal rideCost)
        {
            Name = name;
            RemainingPrepaid = prepaid;
            _planCost = planCost;
            _rideCost = rideCost;

        }

        public ParkRidePlan()
        {
            Name = "Basic";
            RemainingPrepaid = 5;
            _planCost = 50.00M;
            _rideCost = 15.00M;
        }

        private decimal _planCost;
        private decimal _rideCost;
        public string Name { get; set; }
        protected int NumberPurchased { get; set; }
        protected int NumberRode { get; set; }
        protected int RemainingPrepaid { get; set; }
        protected decimal Spent { get; set; }

        public virtual string GetCostOfNextRide()
        {
            if (RemainingPrepaid > 0)
            {
                return "Free";
            }
            return String.Format("{0:C}", _rideCost); ;
        }
        public decimal GetCostPerRide()
        {
            if (NumberRode == 0)
            {
                throw new InvalidOperationException();
            }
            return CostToDate() / NumberRode;
        }
        public virtual bool Use()
        {
            if (RemainingPrepaid > 0)
            {
                RemainingPrepaid--;
            }
            else
            {
                Spent += CostOfPurchasedRide();
                NumberPurchased++;
            }
            NumberRode++;
            return true;
        }
        protected virtual decimal CostOfPurchasedRide()
        {
            return _rideCost;
        }

        protected decimal CostToDate()
        {
            return _planCost + Spent;
        }


    }
}
