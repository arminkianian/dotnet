using Framework.Application;
using SampleContext.Application.Contracts;
using Autofac;
using SampleContext.Application;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // Register your types here
            
            //builder.RegisterType<DemoCommandBus>().As<ICommandBus>();
            builder.RegisterType<AutofacCommandBus>().As<ICommandBus>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(AddAuctionCommandHandler).Assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            builder.RegisterGenericDecorator(typeof(LoggingCommandHandlerDecorator<>), typeof(ICommandHandler<>));

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var commandBus = scope.Resolve<ICommandBus>();

                var addAuctionCommand = new AddAuctionCommand()
                {
                    Title = "My first auction"
                };

                var placeBidCommand = new PlaceBidCommand()
                {
                    AuctionId = 1,
                    Amount = 100
                };

                commandBus.Dispatch(addAuctionCommand);
                commandBus.Dispatch(placeBidCommand);
            }
        }
    }
}
