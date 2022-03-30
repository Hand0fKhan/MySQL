using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQL.Models.ViewModels
{
    public class Bowling
    {
        public Team team { get; set; }
        public List<Bowler> bowlers { get; set; }
    }
}
