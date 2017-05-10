using Bytes2you.Validation;
using ProjectManagerSystem.Common;
using ProjectManagerSystem.Common.Exceptions;
using ProjectManagerSystem.Core.Contracts;
using ProjectManagerSystem.Core.Providers.Contracts;
using System;

namespace ProjectManagerSystem.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";
        private const string TerminatedMessage = "Program terminated.";
        private const string ErrorMessage = "Opps, something happened. :(";

        public Engine(FileLogger fileLogger, CommandProcessor commandProcessor, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(fileLogger, "Engine Logger provider").IsNull().Throw();

            Guard.WhenArgument(commandProcessor, "Engine Processor provider").IsNull().Throw();

            this.FileLogger = fileLogger;
            this.CommandProcessor = commandProcessor;
            this.Reader = reader;
            this.Writer = writer;
        }

        public CommandProcessor CommandProcessor { get; set; }

        public FileLogger FileLogger { get; set; }

        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public void Start()
        {
            while (true)
            {
                var commandFromInput = this.Reader.ReadLine();

                if (commandFromInput.ToLower() == TerminationCommand)
                {
                    this.Writer.WriteLine(TerminatedMessage);

                    break;
                }

                try
                {
                    var executionResult = this.CommandProcessor.ProcessCommandFromInput(commandFromInput);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ErrorMessage);
                    this.FileLogger.ShowError(ex.Message);
                }
            }
        }
    }
}
