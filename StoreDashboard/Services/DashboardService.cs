using StoreDashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDashboard.Data
{
    public class DashboardService
    {
        public Task<Pos[]> GetPosEntities(string storeId)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 7).Select(index => new Pos
            {
                Id = rng.Next(1, 55).ToString(),
                TransactionId = Guid.NewGuid().ToString().Substring(0, 8),
                Data = new PosData
                {
                    QuartersData = new System.Collections.Generic.List<QuarterData>
                      {
                          new QuarterData
                            {
                                Quarter = "Q1",
                                Revenue = 30000*rng.Next(1, 55)
                            },
                            new QuarterData
                            {
                                Quarter = "Q2",
                                Revenue = 40000*rng.Next(1, 55)
                            },
                            new QuarterData
                            {
                                Quarter = "Q3",
                                Revenue = 50000*rng.Next(1, 55)
                            },
                            new QuarterData
                            {
                                Quarter = "Q4",
                                Revenue = 80000*rng.Next(1, 55)
                            }
                    }
                }

            }).ToArray());
        }

        public Task<Store> GetStore(string storeId)
        {
            return Task.FromResult(new Store
            {
                Id = "4801",
                Data = new StoreData
                {
                    RevenueByYearsData = new Dictionary<string, List<RevenueByYearData>>
                       {
                           {"2019",new List<RevenueByYearData>
                               {
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-01-01"),
                                    Revenue = 234000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-02-01"),
                                    Revenue = 269000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-03-01"),
                                    Revenue = 233000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-04-01"),
                                    Revenue = 244000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-05-01"),
                                    Revenue = 214000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-06-01"),
                                    Revenue = 253000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-07-01"),
                                    Revenue = 274000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-08-01"),
                                    Revenue = 284000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-09-01"),
                                    Revenue = 273000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-10-01"),
                                    Revenue = 282000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-11-01"),
                                    Revenue = 289000
                                },
                                new RevenueByYearData
                                {
                                    Date = DateTime.Parse("2019-12-01"),
                                    Revenue = 294000
                                }
                               }
                        },
                        {"2020",new List<RevenueByYearData>
                               {
                                new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-01-01"),
                                        Revenue = 334000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-02-01"),
                                        Revenue = 369000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-03-01"),
                                        Revenue = 333000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-04-01"),
                                        Revenue = 344000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-05-01"),
                                        Revenue = 314000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-06-01"),
                                        Revenue = 353000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-07-01"),
                                        Revenue = 374000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-08-01"),
                                        Revenue = 384000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-09-01"),
                                        Revenue = 373000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-10-01"),
                                        Revenue = 382000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-11-01"),
                                        Revenue = 389000
                                    },
                                    new RevenueByYearData
                                    {
                                        Date = DateTime.Parse("2019-12-01"),
                                        Revenue = 394000
                                    }
                        }
                        }
                    }
                }
            });
        }
    }
}
