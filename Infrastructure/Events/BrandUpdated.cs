﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Events;

public class BrandUpdated
{
    public string Id { get; set; }
    public string Name { get; set; }
}
