using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using DataRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackendCore.Controllers
{

    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private IEventRepository eventRepository;

        public EventsController(IEventRepository _eventRepository)
        {
            eventRepository = _eventRepository;
        }

        [HttpPost]
        [Route("CreateEvent/")]
        public IActionResult CreatEvent([FromBody] Event _obj)
        {
            int result = 0;
            EventReturn returnData = new EventReturn();

            if (_obj != null)
            {
                result = eventRepository.SaveEvent(_obj);
            }

            if (result > 0)
            {
                returnData.Message = "Event returned successfully!!";
                returnData.Status = 1;
            }
            else
            {
                returnData.Message = "Please fill in the required fields.";
                returnData.Status = 0;
            }

            var json = JToken.FromObject(returnData);
            return Ok(json);
        }

        [HttpPost]
        [Route("UpdateEvent/")]
        public IActionResult UpdateEvent([FromBody] Event _obj)
        {
            int result = 0;
            EventReturn returnData = new EventReturn();

            if (_obj != null)
            {
                result = eventRepository.UpdateEvent(_obj);
            }

            if (result > 0)
            {
                returnData.Message = "Event updated successfully!!";
                returnData.Status = 1;
            }
            else
            {
                returnData.Message = "Event could not be updated!!";
                returnData.Status = 0;
            }

            var json = JToken.FromObject(returnData);
            return Ok(json);

        }

        [HttpGet]
        [Route("DeleteEvent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            long result = 0;
            EventReturn returnData = new EventReturn();

            result = eventRepository.DeleteEvent(id);

            if (result > 0)
            {
                returnData.Message = "Event deleted successfully!!";
                returnData.Status = 1;
            }
            else
            {
                returnData.Message = "Event could not be deleted!!";
                returnData.Status = 0;
            }

            var json = JToken.FromObject(returnData);
            return Ok(json);
        }

        [HttpGet]
        [Route("FetchAllEvents/")]
        public IActionResult fetchAllEvents()
        {
            IEnumerable<Event> model = eventRepository.GetAllEvents();

            EventListReturn result = new EventListReturn();

            if (model != null)
            {
                result.Message = "Events returned successfully!!";
                result.Status = 1;
                result.Data = model;
            }
            else
            {
                result.Message = "No Event(s) found!!";
                result.Status = 0;
                result.Data = null;
            }

            var json = JToken.FromObject(result);
            return Ok(json);
        }

        [HttpGet]
        [Route("FetchEvent/{id}")]
        public IActionResult fetchEvent(int id)
        {
            Event model = eventRepository.GetEvent(id);

            EventReturn result = new EventReturn();

            if (model != null)
            {
                result.Message = "Event returned successfully!!";
                result.Status = 1;
                result.Data = model;
            }
            else
            {
                result.Message = "No Event(s) found!!";
                result.Status = 0;
                result.Data = null;
            }

            var json = JToken.FromObject(result);
            return Ok(json);
        }
    }
}