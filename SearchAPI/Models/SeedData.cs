﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SearchAPIContext(
                serviceProvider.GetRequiredService<DbContextOptions<SearchAPIContext>>()))
            {
                    return; // DB has been seeded
            }
        }
    }
}
