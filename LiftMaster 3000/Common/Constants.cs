namespace LiftMaster_3000.Common;
/// <summary>
/// These strings are set top clean up inline code and to be re used.
/// </summary>
public static class Constants
{
    public static partial class ElevatorConstants
    {
        public const string ElevatorUp = "Elevator is moving up";
        public const string ElevatorDown = "Elevator is moving down";
        public const string ElevatorDoorClosing = "Elevator door is closing";
        public const string ElevatorDoorOpening = "Elevator door is opening";
        public const string ElevatorArrived = "Elevator has arrived";
    }

    public static partial class QuestionConstants
    {
        public const string CalledFLoorQuestion = "What floor are we going to?:";
        public const string FromFloorQuestion = "From what floor are we calling?:";
        public const string DirectionQuestion = "Going up or down?:";
        public const string AmountOfPeopleQuestion = "How Many People are we taking?:";
        
        
        public const string FloorCountQuestion = "How Many Floors are we simulating?:";
        public const string ElevatorCountQuestion ="How Many Elevators are we simulating?:";
        public const string WeightCapQuestion ="What Is the weight capacity of the elevators?:";
        public const string FloorCapQuestion ="How many people can I add per floor?:";
    }
}