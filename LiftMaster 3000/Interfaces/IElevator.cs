namespace LiftMaster_3000.Models;
/// <summary>
/// Contract for Elevator
/// </summary>
public interface IElevator
{
    /// <summary>
    /// Iterator to keep track of the current floor the elevator is on
    /// </summary>
    int CurrentFloor { get; }
    
    /// <summary>
    /// Number of people currently on the elevator
    /// </summary>
    int NumberOfPeople { get; }
    
    
    /// <summary>
    /// Method that moves the elevator to the new floor
    /// </summary>
    /// <param name="floor">Floor to go to</param>
    /// <param name="numberOfPeople">Poeple being taken to the floor</param>
    /// <returns></returns>
    int MoveToFloor(int floor,int numberOfPeople = -1);
}