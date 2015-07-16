using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public sealed class ActivationRequest
    {
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
    }

    public sealed class ActivationResponse
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string MachineName { get; set; }
        public string MachineCode { get; set; }

        public ApplicationVersion Version { get; set; }
        public int OnLineLimit { get; set; }
        public DateTime RegsterationDate { get; set; }
        public DateTime ExpiredDate { get; set; }

    }
}
