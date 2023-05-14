﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Entities
{
    public class Signal
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public int Value { get; set; }
        public ICollection<TemporalInformation> TemporalInformation { get; set; }

    }
}
