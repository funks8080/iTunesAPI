using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SearchAPI.Models
{
    public class SearchAPIContext : DbContext
    {
        public SearchAPIContext (DbContextOptions<SearchAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SearchAPI.Models.RecordTrack> RecordTrack { get; set; }
    }
}
