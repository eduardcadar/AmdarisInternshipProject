using Application.Services.Interfaces;

namespace Application.Services
{
    public class ServiceCreate : IServiceCreate
    {
        public string Greet()
        {
            return "Hello world";
        }
    }
}
