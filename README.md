# SensorSimulator-Version2

> Just looking for the observers?
>
> - `Racer.cs` - Subject
> - `RacerDisplay / cheaterDisplay` - Observers
> - `CheaterCPU` - Subject and Observer

## Diagrams

### Class

![class diagram](/Class%20Diagram.drawio.png)

### Sequence

![sequence diagram](/Sequence%20Diagram.drawio.png)
Make sure to open the supplied solution, as many projects are old / redundant.
The main files you will need are:

## `RacerServer`

- Main entry to the program in `Program.cs`
- Starts listener server using `DataReceiver.cs`
- See sequence diagram for differences between threads
  - UI runs on main thread, listening server and Racer / Cheater notifications run on secondary thread.

## SharedClasses

- Contain the datamodels for our project, key highlights

### `Racer.cs`

Heart of the program, sends notification when attributes are updated using public setters.

### `CheaterComputer.cs`

Auto subscribes to all racers at beginning of the race, sends notifications when it finds cheaters.
