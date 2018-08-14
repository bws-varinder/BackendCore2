using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataRepository
{
    public class EventRepository : IEventRepository
    {
        private ApplicationContext context;
        private DbSet<Event> eventEntity;

        public EventRepository(ApplicationContext context)
        {
            this.context = context;
            eventEntity = context.Set<Event>();
        }

        public int SaveEvent(Event obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return 100;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return eventEntity.AsEnumerable();
        }

        public Event GetEvent(long id)
        {
            return eventEntity.SingleOrDefault(s => s.EventId == id);
        }

        public long DeleteEvent(long id)
        {
            try
            {
                Event obj = GetEvent(id);
                eventEntity.Remove(obj);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return id;
        }

        public int UpdateEvent(Event obj)
        {
            try
            {
                eventEntity.Update(obj);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            return obj.EventId;
        }

    }
}