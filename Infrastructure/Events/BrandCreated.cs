using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Events;

public class BrandCreated:Entity<Guid>
{
    public string Name { get; set; }
}
