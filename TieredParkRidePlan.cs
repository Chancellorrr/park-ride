namespace ParkRide
{
    public class TieredParkRidePlan : ParkRidePlan
    {
        public TieredParkRidePlan()
        {
            Name = "Tiered";
            RemainingPrepaid = 5;
            _planCost = 100.00M;
            _rideCost = 10.00M;
            _tierLimit = 5;
            _tierCost = 5.50M;
        }

        public TieredParkRidePlan(string name, int prepaid, decimal planCost, decimal rideCost, int tierLimit, decimal tierCost) : base(name, prepaid, planCost, rideCost)
        {
            _planCost = planCost;
            _rideCost = rideCost;
            _tierCost = tierCost;
            _tierLimit = tierLimit;
        }

        private int _tierLimit;
        private decimal _tierCost;
        private decimal _rideCost;
        private decimal _planCost;

        protected override decimal CostOfPurchasedRide()
        {
            if (NumberPurchased > _tierLimit)
            {
                return base.CostOfPurchasedRide();

            }
            else
            {
                return _tierCost;

            }
        }
    }
}