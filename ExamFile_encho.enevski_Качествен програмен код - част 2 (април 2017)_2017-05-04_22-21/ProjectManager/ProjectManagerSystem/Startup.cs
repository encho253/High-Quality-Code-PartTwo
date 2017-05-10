using ProjectManagerSystem.Common;
using ProjectManagerSystem.Core;
using ProjectManagerSystem.Core.Providers;
using ProjectManagerSystem.Data;

namespace ProjectManagerSystem
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();
            var dataBase = new Database();
            var fileLogger = new FileLogger();
            var modelsFactoryProvider = new ModelsFactoryProvider();
            var commandsProvider = new CommandsParserProvider(dataBase, modelsFactoryProvider);
            var commandProcessor = new CommandProcessor(commandsProvider);

            var newEngine = new Engine(fileLogger, commandProcessor, reader, writer);

            newEngine.Start();
        }
    }
}