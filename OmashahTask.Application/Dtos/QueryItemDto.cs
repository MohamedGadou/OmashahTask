using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmashahTask.Application.Dtos
{
    public class QueryItemDto
    {
        public string Name { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool ShowPublishedOnly { get; set; }
        public string Order { get; set; }

    }
}
