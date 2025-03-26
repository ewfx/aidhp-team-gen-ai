// Models/CustomerProfile.cs
using System;
using System.Collections.Generic;

namespace Hyper_Personalization.Models
{
    public class CustomerProfile
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PurchaseHistory { get; set; }
        public List<string> Interests { get; set; }
        public double EngagementScore { get; set; }
        public double SentimentScore { get; set; }
        public string SocialMediaActivity { get; set; }
    }
}
