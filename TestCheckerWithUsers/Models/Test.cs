using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Models
{
    internal class Test
    {
        public string Title { get; set; }
        public int Amount { get; set; }
        public List<Question> Questions { get; set; }
    }
}
