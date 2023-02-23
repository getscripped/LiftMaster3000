using LiftMaster_3000.Interfaces;

namespace LiftMaster_3000.Models;

public class Floor: IPoepleMovement
{
    public int Number { get; }
    public int NumberOfPeople { get; private set; }
    public bool UpButton  { get; }
    public bool DownButton { get; }

    public Floor(int number, int maxFloor, int numberOfPeople)
    {
        Number = number;
        NumberOfPeople = numberOfPeople;
        UpButton = number != (maxFloor-1);
        DownButton = number != 0;;
    }

    public int AddPeople(int amount)
    {
        NumberOfPeople += amount;
        Console.WriteLine($"Floor number {Number+1} now has {NumberOfPeople} people");
        return NumberOfPeople;
    }

    public int RemoveAllPeople()
    {
        throw new NotImplementedException();
    }

    public int RemovePeople(int amount)
    {
        NumberOfPeople -= amount;
        Console.WriteLine($"Floor number {Number+1} now has {NumberOfPeople} people");
        return NumberOfPeople;
    }
}