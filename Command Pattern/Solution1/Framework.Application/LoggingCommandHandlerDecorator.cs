namespace Framework.Application
{
    public class LoggingCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> handler;

        public LoggingCommandHandlerDecorator(ICommandHandler<T> handler)
        {
            this.handler = handler;
        }

        public async Task Handle(T command)
        {
            Console.WriteLine($"Command started! {typeof(T).Name}");
            await this.handler.Handle(command);
            Console.WriteLine($"Command {typeof(T).Name} executed successfully");
        }
    }
}
