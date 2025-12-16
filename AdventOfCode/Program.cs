// See https://aka.ms/new-console-template for more information

using AdventOfCode.DayFive;
using AdventOfCode.DayFour;
using AdventOfCode.DayOne;
using AdventOfCode.DayThree;
using AdventOfCode.DayTwo;
using AdventOfCode.Input;
using Microsoft.Extensions.DependencyInjection;

var main = new Main();
main.DayFive();

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

        var dayTwo = new DayTwo(input);
        dayTwo.Run();
    }

    public void DayThree()
    {
        var input = _serviceProvider.GetService<IInput>()!.ReadDayThreeInput();

        var dayThree = new DayThree(input);
        dayThree.Run();
    }

    public void DayFour()
    {
        var input = _serviceProvider.GetService<IInput>()!.ReadDayFourInput();

        var dayFour = new DayFour(input);
        dayFour.Run();
    }

    public void DayFive()
    {
        var input = _serviceProvider.GetService<IInput>()!.ReadDayFiveInput();

        var dayFive = new DayFive(input);
        dayFive.Run();
    }
}
