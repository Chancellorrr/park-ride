using System;

namespace ParkRide
{
    public class LimitedParkRidePlan : ParkRidePlan
    {
        // public LimitedParkRidePlan(string name = "Limited", int prepaid = 5, decimal planCost = 50.00M, decimal rideCost = 15.00M, decimal creditLimit = 100.00M) : base(name, prepaid, planCost, rideCost)
        // {
        //     _creditLimit = creditLimit;
        //     _rideCost = rideCost;
        // }
        private decimal _creditLimit;
        private decimal _rideCost;
        private decimal _planCost;
        public LimitedParkRidePlan()
        {
            Name = "Limited";
            RemainingPrepaid = 5;
            _planCost = 50.00M;
            _rideCost = 15.00M;
            _creditLimit = 100.00M;

        }



        public LimitedParkRidePlan(string name, int prepaid, decimal planCost, decimal rideCost = 1.00M, decimal creditLimit = 0) : base(name, prepaid, planCost, rideCost)
        {
            _planCost = planCost;
            _rideCost = rideCost;
            _creditLimit = creditLimit;

        }

        public override string GetCostOfNextRide()
        {
            if (_creditLimit <= 0M && RemainingPrepaid == 0)
            {
                return "N/A";
            }
            else if (RemainingPrepaid > 0)
            {
                return "Free";
            }
            else
            {

                return String.Format("{0:C}", _rideCost); ;
            }
        }

        public override bool Use()
        {
            if (_creditLimit <= 0M && RemainingPrepaid == 0)
            {
                return false;
            }
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
            _creditLimit -= _rideCost;
            return true;
        }
    }
}