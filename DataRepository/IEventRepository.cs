using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository
{
    public interface IEventRepository
    {
        int SaveEvent(Event obj);
        IEnumerable<Event> GetAllEvents();
        Event GetEvent(long id);
        long DeleteEvent(long id);
        int UpdateEvent(Event obj);
    }
}
