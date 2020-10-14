using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPageTemplate.Shared.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Image { get; set; }
    }
}
