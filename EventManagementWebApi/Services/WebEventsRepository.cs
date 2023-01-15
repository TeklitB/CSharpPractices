using EventManagementWebApi.Interfaces;

namespace EventManagementWebApi.Services
{
    public record WebEvent(int Id, DateTime Date, string Location, string Description);
    public class WebEventsRepository : IWebEventsRepository
    {
        private static List<WebEvent> _webEvents = new List<WebEvent>();

        public WebEvent Add(WebEvent webEvent)
        {
            _webEvents.Add(webEvent);
            return webEvent;
        }

        public IEnumerable<WebEvent> GetAll()
        {
            return _webEvents;
        }

        public WebEvent GetById(int id) => _webEvents.FirstOrDefault(e => e.Id == id);

        public void DeleteById(int id)
        {
            var webEventToDelete = GetById(id);
            if (webEventToDelete == null)
            {
                throw new ArgumentException("No event exists with the given id.");
            }
            _webEvents.Remove(webEventToDelete);
        }
    }
}
