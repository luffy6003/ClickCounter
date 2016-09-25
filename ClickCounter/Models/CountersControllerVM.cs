using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClickCounter.DAL;
namespace ClickCounter.Models
{
    public class CountersControllerVM
    {
        public CountersControllerVM()
        {
            Counter = new Counter();
        }
        public const int COUNTER_LIMIT = 10;
        private Counter Counter = null;
        private static CountersControllerVM instance;
        public static CountersControllerVM Instance
        {
            get
            {
                if (instance == null)
                {
                    
                    instance = new CountersControllerVM();
                }
                return instance;
            }
        }

        public int CounterId
        {
            get
            {
                return Counter.CounterId;
            }
        }

        public int ClickCounter
        {
            get
            {
                return Counter.ClickCounter;
            }
            private set
            {
                Counter.ClickCounter = value;
            }
        }

        public CountersControllerVM SelectCounter()
        {
            using (CCDbContext db = new CCDbContext())
            {
                var query =
                    db.Counters.FirstOrDefault();
                if (query != null)
                {
                    this.Counter = query;
                }
            }
            return this;
        }

        public void IterateCounter(int counterId)
        {
            using (CCDbContext db = new CCDbContext())
            {
                int numberOfRows = db.Counters.Count();
                if (numberOfRows == 0)
                {
                    this.ClickCounter = 1;
                    db.Counters.Add(this.Counter);
                    db.SaveChanges();
                    var counterInstance =
                        db.Counters
                        .FirstOrDefault();

                    if (counterInstance != null)
                    {
                        this.Counter = counterInstance;
                    }
                }
                else
                {
                    var query =
                        db.Counters
                        .Where(x => x.CounterId == counterId)
                        .FirstOrDefault();

                    if (query != null)
                    {
                        query.ClickCounter += 1;
                        db.SaveChanges();
                        this.Counter = query;
                    }
                }
            }
        }
    }
}