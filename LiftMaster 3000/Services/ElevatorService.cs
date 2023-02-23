using LiftMaster_3000.Common;
using LiftMaster_3000.Common.Extensions;
using LiftMaster_3000.Interfaces;
using LiftMaster_3000.Models;

namespace LiftMaster_3000.Services;

/// <summary>
/// Service That orchestrates the movement of elevators and keeps track of people per floor
/// </summary>
public class ElevatorService : IElevatorService
{
    private readonly int _floorCount;
    private readonly int _elevatorCount;
    private readonly int _weightLimit;
    private readonly int _peoplePerFloor;
    private List<Elevator> _elevators;
    private List<Floor> _floors;

    public ElevatorService(int floorCount, int elevatorCount, int weightLimit, int peoplePerFloor)
    {
        _floorCount = floorCount;
        _elevatorCount = elevatorCount;
        _weightLimit = weightLimit;
        _peoplePerFloor = peoplePerFloor;
        _elevators = new List<Elevator>();
        _floors = new List<Floor>();

        InitializeElevators();
        InitializeFloors();
    }

    public async Task CallElevatorAsync(int floor, Enums.ElevatorDirections direction, int amountToTake)
    {
        var elevator = _elevators.MinBy(e => Math.Abs(e.CurrentFloor - floor));
        var currentFloor = _floors[floor-1];

        if (elevator == null)
        {
            Console.WriteLine("No available elevators at the moment. Please try again later.");
            return;
        }

        if (elevator != null)
        {
            Console.WriteLine($"Elevator {elevator.Number + 1} has been selected from floor {elevator.CurrentFloor}");
            var peopleToRemove = elevator.MoveToFloor(floor, amountToTake);

            currentFloor.RemovePeople(peopleToRemove);
        }
    }

    public async Task SendToDestinationAsync(int originFloor, int destinationFloor,
        Enums.ElevatorDirections direction)
    {
        // Send the elevator to the requested floor
        var elevator = _elevators.FirstOrDefault(x => x.CurrentFloor == originFloor);
        var callingFloor = _floors[originFloor-1];
        var calledFloor = _floors[destinationFloor-1];


        var peopleToAdd = elevator.MoveToFloor(destinationFloor, -1);
        if (elevator != null)
        {
            if (originFloor == destinationFloor)
            {
                Console.WriteLine("Elevator Is already at destination.");
                callingFloor.AddPeople(peopleToAdd);
            }
            else
            {
                calledFloor.AddPeople(peopleToAdd);
            }

            elevator.RemoveAllPeople();
        }
    }

    public bool CanCallFloor(int floor)
        {
            if (floor < 1 || floor > _floorCount)
            {
                return false;
            }

            return true;
        }

        private void InitializeElevators()
        {
            for (int i = 0; i < _elevatorCount; i++)
            {
                _elevators.Add(new Elevator(i, _floorCount, _weightLimit, 0, 0));
            }
        }

        private void InitializeFloors()
        {
            for (int i = 0; i < _floorCount; i++)
            {
                _floors.Add(new Floor(i, _floorCount, _peoplePerFloor));
            }
        }

        public int GetElevatorPosition(int elevatorNumber)
        {
            return _elevators[elevatorNumber].CurrentFloor;
        }

        public int GetFloorPersonCount(int floorNumber)
        {
            return _floors[floorNumber-1].NumberOfPeople;
        }

        public int GetElevatorCount()
        {
            return _elevatorCount;
        }

        public int GetFloorCount()
        {
            return _floorCount;
        }

        public int GetWeightLimit()
        {
            return _weightLimit;
        }
    }