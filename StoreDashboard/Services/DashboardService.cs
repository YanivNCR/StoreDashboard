using StoreDashboard.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDashboard.Data
{
    public class DashboardService
    {
        public Task<Pos[]> GetPosEntities(string storeId)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Pos
            {
                Id = rng.Next(1, 55).ToString(),
                TransactionId = Guid.NewGuid().ToString().Substring(0,8)
            }).ToArray());
        }
    }
}
