using EventManagementWebApi.Services;

namespace EventManagementWebApi.Interfaces
{
    public interface IWebEventsRepository
    {
        WebEvent Add(WebEvent webEvent);
        IEnumerable<WebEvent> GetAll();
        WebEvent GetById(int id);
        void DeleteById(int id);
    }
}
