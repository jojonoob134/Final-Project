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




        public CalcVal GetCalc(int id)
        {
            return _conn.QuerySingle<CalcVal>("SELECT * FROM calculating_chart WHERE monthID = @id", new { id = id });
        }

        public void UpdateCalc(CalcVal calc)
        {
            _conn.Execute("UPDATE calculating_chart totalCost = (SELECT SUM)")
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
            _conn.Execute("UPDATE cost_chart SET purchesName = @purchesName, cost = @cost WHERE purchesID = @id",
                new { purchesName = cost.purchesName, cost = cost.cost, id = cost.purchesID });
        }
        //public void InsertMonth(Month monthToInsert)
        //{
        //    _conn.Execute("INSERT INTO cost_chart (PURCHESNAME, COST, MONTH) VALUES (@name, @price, @month);",
        //        new { name = monthToInsert.purchesName, price = monthToInsert.cost, month = monthToInsert.month });
        //}
        //public IEnumerable<Month> GetMonths()
        //{
        //    return _conn.Query<Month>("SELECT * FROM month;");
        //}
        //public CostVal AssignMonths()
        //{
        //    var monthList = GetMonths();
        //    var acountant = new CostVal();
        //    acountant.Months = monthList;
        //    return acountant;
        //}

    }
}
