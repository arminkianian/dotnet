using Autofac;
using Framework.Application;

namespace ConsoleApp1
{
    internal class AutofacCommandBus : ICommandBus
    {
        private readonly ILifetimeScope lifetimeScope;

        public AutofacCommandBus(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public async Task Dispatch<T>(T command) where T : ICommand
        {
            var handlers = lifetimeScope.Resolve<IEnumerable<ICommandHandler<T>>>();

            foreach (var commandHandler in handlers)
            {
                await commandHandler.Handle(command);

            }
        }
    }
}
