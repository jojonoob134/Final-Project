namespace True_Final_Project.Models
{
    public interface ICalculations
    {
        public IEnumerable<CostVal> GetAllCost();
        public IEnumerable<CalcVal> GetAllCalc();
        public CostVal GetCost(int ID);
        public void UpdateCost(CostVal cost);
    }

}
