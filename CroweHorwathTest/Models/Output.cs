
namespace CroweHorwathTest.Models
{
    public class Output
    {
        public string OutputMessage { get; set; }
    }

    public interface IOutputStrategy
    {
        void OutputApplication(Output output);
    }

    public class ConsoleOutput : IOutputStrategy
    {
        public void OutputApplication(Output output)
        {
            output.OutputMessage = "Output is directed to console application";
        }
    }

    public class DatabaseOutput : IOutputStrategy
    {
        public void OutputApplication(Output output)
        {
            output.OutputMessage = "Output is directed to database";
        }
    }

    public class ScreenOutput : IOutputStrategy
    {
        public void OutputApplication(Output output)
        {
            output.OutputMessage = "Hello World";
        }
    }

    public class OutputService
    {
        private readonly IOutputStrategy outputStrategy;

        public OutputService(IOutputStrategy strategy)
        {
            outputStrategy = strategy;
        }

        public void ProcessOutput(Output output)
        {
            outputStrategy.OutputApplication(output);
        }
    }
}