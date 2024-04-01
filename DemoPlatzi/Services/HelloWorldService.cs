namespace DemoPlatzi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "Hello World! from Dependency Injection";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }
}
