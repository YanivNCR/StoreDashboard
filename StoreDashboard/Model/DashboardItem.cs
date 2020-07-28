using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDashboard.Model
{
    public class DashboardItem
    {
        public Pos Pos  { get; set; }
        public List<Alert> Alerts { get; set; }
        public Status Status { get; set; }

    }
}
