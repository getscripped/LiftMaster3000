using System.Runtime.InteropServices.JavaScript;
using LiftMaster_3000.Common;
using LiftMaster_3000.Common.Extensions;
using LiftMaster_3000.Interfaces;

namespace LiftMaster_3000.Models;

/// <summary>
/// Elevator class that encapsulates all elevator specific logic and movement
/// </summary>
public class Elevator : IElevator, IPoepleMovement
{
    public readonly int Number;
    private readonly int _floorCount;
    private readonly int _maxPeople;
    private bool _isMoving = false;
    public int CurrentFloor { get; private set;}
    public int NumberOfPeople { get; private set; }
    
    public Elevator(int number,int floorCount, int maxPeople, int currentFloor, int numberOfPeople)
    {
        Number = number;
        _floorCount = floorCount;
        _maxPeople = maxPeople;
        CurrentFloor = currentFloor;
        NumberOfPeople = numberOfPeople;
    }

    public int AddPeople(int people)
    {
        if (NumberOfPeople + people > _maxPeople)
        {
            Console.WriteLine($"Elevator Can only take{_maxPeople - NumberOfPeople}");
            var peopleTaken = people - (_maxPeople - NumberOfPeople);
            NumberOfPeople = _maxPeople;

            return (peopleTaken);
        }
        else
        {
            NumberOfPeople += people;
            return NumberOfPeople;
        }
    }

    public int RemoveAllPeople()
    {
        var peopleToTransfer = NumberOfPeople;
        NumberOfPeople = 0;
        return peopleToTransfer;
    }

    public int RemovePeople(int people)
    {
        throw new NotImplementedException();
    }

    public int MoveToFloor(int floor,int numberOfPeople = -1)
    {
        _isMoving = true;
        if (floor < 1 || floor > _floorCount)
        {
            throw new ArgumentOutOfRangeException(nameof(_floorCount), "Floor Out Of Bounds");
        }
        
        
        if (numberOfPeople == -1)
        {
            NumberOfPeople = this.RemoveAllPeople();
        }
        else
        {
            NumberOfPeople = AddPeople(numberOfPeople);
        }

        if (floor == CurrentFloor)
            return NumberOfPeople;

        var direction = floor < CurrentFloor ? Enums.ElevatorDirections.DOWN : Enums.ElevatorDirections.UP;
        switch (direction)
        {
            case Enums.ElevatorDirections.DOWN:
                Constants.ElevatorConstants.ElevatorDown.WriteWithLoadingDots(3,200);
                break;
            case Enums.ElevatorDirections.UP:
                Constants.ElevatorConstants.ElevatorUp.WriteWithLoadingDots(3,200);
                break;
        }

        _isMoving = false;
        Constants.ElevatorConstants.ElevatorDoorOpening.WriteWithLoadingDots(3,200);
        CurrentFloor = floor;
        
        Constants.ElevatorConstants.ElevatorDoorClosing.WriteWithLoadingDots(3,200);
        return NumberOfPeople;
    }
}