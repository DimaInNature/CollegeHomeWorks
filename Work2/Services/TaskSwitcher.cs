using Work2.Models;

namespace Work2.Services
{
    public class TaskSwitcher
    {
        public static void Switch(int taskNumber)
        {
            var clients = ClientModel.Create(10);
            var consumers = ConsumerModel.EnumerableCreate(10);
            var enrolies = EnrolleeModel.Create(10);
            var gasStations = GasStationModel.Create(10);
            var shops = ShopModel.EnumerableCreate(10);
            var students = StudentModel.EnumerableCreate(10);
            var subjects = SubjectModel.EnumerableCreate(10);

            taskNumber = taskNumber < 1 || taskNumber > 9 
                ? 1
                : taskNumber;

            switch (taskNumber)
            {
                case 1:
                    TaskManager.TaskOne(clients);
                    break;
                case 2:
                    TaskManager.TaskTwo(clients);
                    break;
                case 3:
                    TaskManager.TaskThree(enrolies);
                    break;
                case 4:
                    TaskManager.TaskFour(enrolies);
                    break;
                case 5:
                    TaskManager.TaskFive(gasStations);
                    break;
                case 6:
                    TaskManager.TaskSix(consumers, shops);
                    break;
                case 7:
                    TaskManager.TaskSeven(consumers, shops);
                    break;
                case 8:
                    TaskManager.TaskEight(students, subjects);
                    break;
                case 9:
                    TaskManager.TaskNine(students, subjects);
                    break;
            }
        }
    }
}
