using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChittieAPI.Models
{
    public class ChitDateTime
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationID { get; set; }

        public List<ChitDateTime> ListofDateofTime(int TotalDuration, int DurationGap, DateTime StartDate)
        {
            List<ChitDateTime> _newItem = new List<ChitDateTime>();

            DateTime TempStartDate = StartDate;
            for (int i = 1; i <= TotalDuration; i++)
            {
                ChitDateTime Items = new ChitDateTime();
                Items.DurationID = i;
                Items.StartDate = TempStartDate;
                Items.EndDate = TempStartDate.AddDays(DurationGap).Date;
                _newItem.Add(Items);
                TempStartDate = TempStartDate.AddDays(DurationGap).Date;
            }
            return _newItem;
        }
    }
    public class BidDateTime
    {
        public int BidAmount { get; set; }
        public int DurationID { get; set; }
    }


    }