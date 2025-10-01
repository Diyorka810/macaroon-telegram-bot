using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacaroonBot.Model
{
    public class OwnerReport
    {
        public int Id { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public decimal Revenue { get; set; }

        public decimal Expenses { get; set; }

        public decimal Salaries { get; set; }

        public decimal NetProfit { get; set; }
    }
}
