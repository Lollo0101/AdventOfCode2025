// See https://aka.ms/new-console-template for more information

using AdventOfCode.DayOne;
using AdventOfCode.Input;
using Microsoft.Extensions.DependencyInjection;

var main = new Main();
main.DayOne();

internal class Main
{
    private readonly ServiceProvider _serviceProvider;

    public Main()
    {
        var serviceCollection = new ServiceCollection();
        // serviceCollection.AddSingleton<IInput, InlineInput>();
        serviceCollection.AddSingleton<IInput, FileInput>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public void DayOne()
    {
        var input = _serviceProvider.GetService<IInput>()!.ReadListInput();

        var dayOne = new DayOne(input);
        dayOne.Run();
    }
}
