using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Drone[] drones = new Drone[]
            {
                new Drone("DJI Mini 3", 85),
                new Drone("Autel EVO Lite+", 15),
                new Drone("Parrot Anafi")
            };

            while (true)
            {
                Console.WriteLine("\n*******************************************");
                Console.WriteLine("*** Система управления БПЛА (версия 3.0) ***");
                Console.WriteLine("*******************************************");
                Console.WriteLine("1. Показать информацию о всех дронах");
                Console.WriteLine("2. Взлёт выбранного дрона");
                Console.WriteLine("3. Подзарядка выбранного дрона");
                Console.WriteLine("4. Расчёт времени полёта");
                Console.WriteLine("5. Сохранить состояние в файл");
                Console.WriteLine("6. Загрузить состояние из файла");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string? choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("\n--- Список зарегистрированных БПЛА ---");
                            for (int i = 0; i < drones.Length; i++)
                            {
                                Console.Write($"[{i}] ");
                                drones[i].PrintInfo();
                            }
                            break;

                        case "2":
                            int takeOffIndex = SelectDroneIndex(drones);
                            if (takeOffIndex != -1)
                            {
                                drones[takeOffIndex].TakeOff();
                            }
                            break;

                        case "3":
                            int chargeIndex = SelectDroneIndex(drones);
                            if (chargeIndex != -1)
                            {
                                Console.Write("Введите процент заряда: ");
                                if (int.TryParse(Console.ReadLine(), out int amount))
                                {
                                    drones[chargeIndex].ChargeBattery(amount);
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: введите целое число.");
                                }
                            }
                            break;

                        case "4":
                            int timeIndex = SelectDroneIndex(drones);
                            if (timeIndex != -1)
                            {
                                Console.WriteLine($"Оставшееся время полёта: {drones[timeIndex].CalculateFlightTime()} мин.");
                            }
                            break;

                        case "5":
                        case "6":
                            Console.WriteLine("Функция сохранения/загрузки будет добавлена в следующем задании.");
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }

        static int SelectDroneIndex(Drone[] drones)
        {
            if (drones.Length == 0)
            {
                Console.WriteLine("Список дронов пуст.");
                return -1;
            }

            Console.Write($"Введите индекс дрона (от 0 до {drones.Length - 1}): ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < drones.Length)
            {
                return index;
            }

            Console.WriteLine("Ошибка: некорректный индекс дрона.");
            return -1;
        }
    }
}
