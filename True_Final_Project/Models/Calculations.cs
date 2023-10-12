using Dapper;
using System.Data;

namespace True_Final_Project.Models
{
    public class Calculations : ICalculations
    {
        private readonly IDbConnection _conn;
        public Calculations(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<CalcVal> GetAllCalc()
        {
            return _conn.Query<CalcVal>("SELECT * FROM calculating_chart;");
        }

        public IEnumerable<CostVal> GetAllCost()
        {
            return _conn.Query<CostVal>("SELECT * FROM cost_chart;");
        }

        public CostVal GetCost(int id)
        {
            return _conn.QuerySingle<CostVal>("SELECT * FROM cost_chart WHERE purchesID = @id", new { id = id });
        }
        public void UpdateCost(CostVal cost)
        {
            _conn.Execute("UPDATE cost_Chart SET purchesName = @purchesName, cost = @cost WHERE purchesID = @id",
                new { purchesName = cost.purchesName, cost = cost.cost, id = cost.purchesID });
        }
    }
}
