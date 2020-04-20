using System;
namespace DevBuild2020_ConsumingAnAPI.Models
{
    public class Hand
    {
        public Card[] Cards { get; set; }
        public string Deck_id;
        public int remaining;
    }
    public class Card
    {
        public string code { get; set; }
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }
    
}
