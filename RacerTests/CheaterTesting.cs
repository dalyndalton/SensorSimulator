namespace RacerTests;
using SharedClasses;
using RacerServer;

public class CheaterTesting
{
    [Fact]
    public void SimpleCheaterCheck()
    {
        // Create Racers & Cheating Computer
        var computer = new CheaterComputer();
        var racer1 = new Racer("Bob", 1, new RaceGroup("G1", 1, 0, 0, 0));
        var racer2 = new Racer("Dan", 2, new RaceGroup("G2", 2, 0, 0, 0));

        racer1.Subscribe(computer);
        racer2.Subscribe(computer);

        // Simulate a simple cheat
        racer1.UpdateRacerSensor(1, 1000);
        racer2.UpdateRacerSensor(1, 1100);
        racer2.UpdateRacerSensor(2, 303000);
        racer1.UpdateRacerSensor(2, 303300);

        Assert.True(computer.Cheaters.Any());
    }
    [Fact]
    public void NoCheaterCheck()
    {
        var computer = new CheaterComputer();

        var group = new RaceGroup("G1", 1, 0, 0, 0);
        var racer1 = new Racer("Bob", 1, group);
        var racer2 = new Racer("Dan", 2, group);

        racer1.Subscribe(computer);
        racer2.Subscribe(computer);

        // Simulate a simple cheat
        racer1.UpdateRacerSensor(1, 1000);
        racer2.UpdateRacerSensor(1, 1100);
        racer2.UpdateRacerSensor(2, 303000);
        racer1.UpdateRacerSensor(2, 303300);

        // No cheaters should be found if in same group
        Assert.True(!computer.Cheaters.Any());
    }
}