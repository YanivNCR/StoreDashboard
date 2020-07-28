using StoreDashboard.Config;
using StoreDashboard.Controllers;
using StoreDashboard.Data;
using StoreDashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDashboard.BusinessComponents
{
    public class DashboardBusinessComponent
    {
        private DashboardController _dashboardController;

        public DashboardBusinessComponent()
        {
            _dashboardController = new DashboardController();
        }

        public List<DashboardItem> GetDashboardItems()
        {
            var dashboardItems = CreateDashboardItemsAsync();
            return dashboardItems.Result;
            
        }

        private async Task<List<DashboardItem>> CreateDashboardItemsAsync()
        {
            
            var storeId = DashboardConfig.StoreId;
            var dashboardService = new DashboardService();
            var posEntities = await dashboardService.GetPosEntities(storeId);
            var dashboardItems = new List<DashboardItem>();

            foreach (var posEntity in posEntities)
            {
                dashboardItems.Add(new DashboardItem
                {
                    Pos = posEntity,
                    Status = GetPosStatus(posEntity.Id)
                });
            }


            return dashboardItems;
        }

        private Status GetPosStatus(string id)
        {
            return Status.OK;
            //return _dashboardController.GetPosStatus(id);
        }
    }
}
