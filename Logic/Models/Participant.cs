using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models {
    class Participant {

        public string Name { get; set; }
        public string Email { get; set; }
        public Participant GiveTo { get; set; }
    }
}
