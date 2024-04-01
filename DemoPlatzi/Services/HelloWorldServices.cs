namespace DemoPlatzi.Services
{
    public class HelloWorldServices : IHelloWorldService
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
