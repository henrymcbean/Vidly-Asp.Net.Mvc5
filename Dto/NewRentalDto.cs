using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly_Asp.Net.Mvc5.Dto
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieId { get; set; }
    }
}