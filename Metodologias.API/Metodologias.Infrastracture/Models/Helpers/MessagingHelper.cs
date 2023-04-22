using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.Infrastracture.Models.Helpers
{
    public class MessagingHelper
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;
    }

    public class MessagingHelper<T> : MessagingHelper
    {
        public T obj { get; set; }
    }
}
