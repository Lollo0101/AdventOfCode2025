// See https://aka.ms/new-console-template for more information

using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;
using AdventOfCode.Input;
using Microsoft.Extensions.DependencyInjection;

var main = new Main();
main.DayTwo();

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
        var input = _serviceProvider.GetService<IInput>()!.ReadDayOneInput();

        var dayOne = new DayOne(input);
        dayOne.Run();
    }

    public void DayTwo()
    {
        var input = _serviceProvider.GetService<IInput>()!.ReadDayTwoInput();

        var dayOne = new DayTwo(input);
        dayOne.Run();
    }
}
