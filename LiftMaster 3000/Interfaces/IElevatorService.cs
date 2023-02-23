using LiftMaster_3000.Common;

namespace LiftMaster_3000.Interfaces;

/// <summary>
/// Contract for elevatorService
/// </summary>
public interface IElevatorService
{
    /// <summary>
    /// Checks whether a floor can be called
    /// </summary>
    /// <param name="floor">Floor to be called</param>
    /// <returns></returns>
    public bool CanCallFloor(int floor);
    
    /// <summary>
    /// Takes an Elevator and kicks off the process to move it to the destination floor
    /// </summary>
    /// <param name="callingFloor">Origin floor</param>
    /// <param name="destinationFloor">Destination floor</param>
    /// <param name="direction">Up or Down</param>
    public Task SendToDestinationAsync(int callingFloor, int destinationFloor, Enums.ElevatorDirections direction);
    
    /// <summary>
    /// Takes an Elevator and kicks off the process to move it to the calling floor to pick up people
    /// </summary>
    /// <param name="floor">Floor being called from</param>
    /// <param name="direction">Up or down</param>
    /// <param name="amountToTake">Amount of people we would like to take</param>
    public Task CallElevatorAsync(int floor, Enums.ElevatorDirections direction, int amountToTake);

    /// <summary>
    /// Gets the position of the nth elevator
    /// </summary>
    /// <param name="elevatorNumber">Elevator number</param>
    /// <returns></returns>
    public int GetElevatorPosition(int elevatorNumber);
    
    /// <summary>
    /// Returns the amount of people on floor n
    /// </summary>
    /// <param name="floorNumber">Floor Number</param>
    /// <returns></returns>
    public int GetFloorPersonCount(int floorNumber);
    
    /// <summary>
    /// Returns amount of elevators
    /// </summary>
    /// <returns></returns>
    public int GetElevatorCount();
    
    /// <summary>
    /// Returns number of floors
    /// </summary>
    /// <returns></returns>
    public int GetFloorCount();
    
    /// <summary>
    /// Gets set weight limit
    /// </summary>
    /// <returns></returns>
    public int GetWeightLimit();
}