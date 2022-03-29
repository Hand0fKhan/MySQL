﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQL.Models
{
    public class BowlingContext: DbContext
    {
        public BowlingContext (DbContextOptions<BowlingContext> options) : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }
    }
}
