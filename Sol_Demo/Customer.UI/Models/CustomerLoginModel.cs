using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.UI.Models
{
    public class CustomerLoginModel
    {
        public String UserName { get; set; }

        public String Password { get; set; }
    }
}