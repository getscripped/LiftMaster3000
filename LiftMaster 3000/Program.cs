using LiftMaster_3000.Common;
using LiftMaster_3000.Common.Extensions;
using LiftMaster_3000.Services;

bool validated = false;

Console.WriteLine("----------Welciome to Liftmaster 300 Simulation-------------");

var floorCount = Convert.ToInt32(
    ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.FloorCountQuestion, 0, typeof(int)));

var elevatorCount = Convert.ToInt32(
    ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.ElevatorCountQuestion, 0, typeof(int)));

var capacityCount = Convert.ToInt32(
    ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.WeightCapQuestion, 0, typeof(int)));

var floorPeopleCount = Convert.ToInt32(
    ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.FloorCapQuestion, 0, typeof(int)));
Console.WriteLine("========================================================================");

var elevatorService = new ElevatorService(floorCount, elevatorCount, capacityCount, floorPeopleCount);

ConsoleExtensions.ElevatorDownAnimation();

while (true)
{
    var callingFLoor = Convert.ToInt32(
        ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.FromFloorQuestion, floorCount, typeof(int)));

    var direction = ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.DirectionQuestion, null,
        typeof(Enums.ElevatorDirections)).ToUpper();

    var amountToTake = Convert.ToInt32(
        ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.AmountOfPeopleQuestion, capacityCount,
            typeof(int)));

    await elevatorService.CallElevatorAsync(callingFLoor, Enum.Parse<Enums.ElevatorDirections>(direction),
        amountToTake);

    var calledFLoor = Convert.ToInt32(
        ConsoleExtensions.GetInputAndValidate(Constants.QuestionConstants.CalledFLoorQuestion, floorCount,
            typeof(int)));

    await elevatorService.SendToDestinationAsync(callingFLoor, calledFLoor,
        Enum.Parse<Enums.ElevatorDirections>(direction));

    Console.WriteLine("========================================================================");
}