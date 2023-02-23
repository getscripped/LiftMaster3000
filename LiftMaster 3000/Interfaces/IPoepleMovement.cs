namespace LiftMaster_3000.Interfaces;

public interface IPoepleMovement
{
    /// <summary>
    /// Method to add people to the entity
    /// </summary>
    /// <param name="people">Amount of people to add</param>
    /// <returns></returns>
    int AddPeople(int people);
    
    /// <summary>
    /// Method to remove all people to the elevator
    /// </summary>
    /// <returns></returns>
    int RemoveAllPeople();
    
    /// <summary>
    /// Method to remove some people to the elevator
    /// </summary>
    /// <returns></returns>
    int RemovePeople(int people);
}