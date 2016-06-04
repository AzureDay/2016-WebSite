using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
    public class QuizScore
    {
        public string Email { get; set; }
        public int Score { get; set; }

        public DateTime Date { get; set; }
    }
}

