﻿namespace AuctionManagement
{
    public class Bid
    {
        public int Amount { get; private set; }
        public int BidderId { get; }
        
        public Bid(int amount, int bidderId)
        {
            Amount = amount;
            BidderId = bidderId;
        }
    }
}