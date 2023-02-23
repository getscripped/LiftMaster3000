using LiftMaster_3000.Common;
using LiftMaster_3000.Services;

namespace LiftMasterTesting;

public class ElevatorServiceTests
{
    private int _floorCount;
    private int _elevatorCount;
    private int _capacityCount;
    private int _floorPeopleCount;
    private ElevatorService _elevatorService;

    [SetUp]
    public void Setup()
    {
         _floorCount = 10;
         _elevatorCount = 3;
         _capacityCount = 10;
         _floorPeopleCount = 10;
    }

    /// <summary>
    /// This test creates a service and verifies all elevators are created and at position 0
    /// </summary>
    [Test]
    public void Creating_Services_Returns_Valid_Service()
    {
        //arrange
        _elevatorService = new ElevatorService(_floorCount, _elevatorCount, _capacityCount, _floorPeopleCount);
        
        //act
        var elevatorPos1 =_elevatorService.GetElevatorPosition(0);
        var elevatorPos2 =_elevatorService.GetElevatorPosition(1);
        var elevatorPos3 =_elevatorService.GetElevatorPosition(2);
        
        //assert
        Assert.That(elevatorPos1, Is.EqualTo(0));
        Assert.That(elevatorPos2, Is.EqualTo(0));
        Assert.That(elevatorPos3, Is.EqualTo(0));
    }
    
    /// <summary>
    /// This test moves an elevator twice to determine if the closest one is taken on the second move,
    /// The other 2 elevators should remain at position 0
    /// </summary>
    [Test]
    public async Task Calling_Elevator_Should_Pick_Closest_One()
    {
        //arrange
        _elevatorService = new ElevatorService(_floorCount, _elevatorCount, _capacityCount, _floorPeopleCount);
        
        //act
        await _elevatorService.CallElevatorAsync(3, Enums.ElevatorDirections.UP, 3);
        await _elevatorService.SendToDestinationAsync(3,5, Enums.ElevatorDirections.UP);
        
        await _elevatorService.CallElevatorAsync(7, Enums.ElevatorDirections.UP, 3);
        await _elevatorService.SendToDestinationAsync(7,8, Enums.ElevatorDirections.UP);
        
        //assert
        var elevatorPos1 =_elevatorService.GetElevatorPosition(0);
        var elevatorPos2 =_elevatorService.GetElevatorPosition(1);
        var elevatorPos3 =_elevatorService.GetElevatorPosition(2);
        
        Assert.That(elevatorPos1, Is.EqualTo(8));
        Assert.That(elevatorPos2, Is.EqualTo(0));
        Assert.That(elevatorPos3, Is.EqualTo(0));
    }

    [Test]
    public async Task Moving_An_Elevator_Should_Move_People()
    {
        //arrange
        _elevatorService = new ElevatorService(_floorCount, _elevatorCount, _capacityCount, _floorPeopleCount);
        
        //act
        await _elevatorService.CallElevatorAsync(3, Enums.ElevatorDirections.UP, 3);
        await _elevatorService.SendToDestinationAsync(3, 5, Enums.ElevatorDirections.UP);
        
        //assert
        var numberOfPeople = _elevatorService.GetFloorPersonCount(5);

        Assert.That(numberOfPeople, Is.EqualTo(13));

    }
    
    [Test]
    public async Task Moving_An_Elevator_To_The_Same_Floor_Should_Not_Move_People()
    {
        //arrange
        _elevatorService = new ElevatorService(_floorCount, _elevatorCount, _capacityCount, _floorPeopleCount);
        
        //act
        await _elevatorService.CallElevatorAsync(3, Enums.ElevatorDirections.UP, 3);
        await _elevatorService.SendToDestinationAsync(3, 3, Enums.ElevatorDirections.UP);
        
        //assert
        var numberOfPeople = _elevatorService.GetFloorPersonCount(5);

        Assert.That(numberOfPeople, Is.EqualTo(10));

    }
}