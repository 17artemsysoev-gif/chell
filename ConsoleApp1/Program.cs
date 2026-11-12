using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Система управления БПЛА (версия 1.0) ---");

            // Задание 1 & 3: Массив объектов и использование разных конструкторов
            Drone[] drones = new Drone[]
            {
                new Drone("DJI Mini 3", 85),
                new Drone("Autel EVO Lite+", 15), // Дрон с низким зарядом для проверки условий
                new Drone("Parrot Anafi")         // Использует конструктор по умолчанию (заряд 100%)
            };

            // Вывод информации о каждом дроне и проверка условий заряда (Задание 1 и 2)
            Console.WriteLine("\n--- Список зарегистрированных БПЛА ---");
            foreach (Drone drone in drones)
            {
                drone.PrintInfo();
                if (drone.IsEngineOn)
                {
                    Console.WriteLine($"Оставшееся время полёта: {drone.CalculateFlightTime()} мин.");
                }




                // Проверка заряда (Задание 1, пункт 4)
                if (drone.BatteryLevel < 20)
                {
                    Console.WriteLine($"[ПРЕДУПРЕЖДЕНИЕ]: У дрона {drone.Model} низкий уровень заряда!");

                    // Предложение подзарядки (Задание 2, пункт 3)
                    Console.WriteLine("Выполняется автоматическая подзарядка...");
                    drone.ChargeBattery(50);
                    Console.WriteLine();
                }
            }

            // Интерактивное тестирование первого дрона из списка
            if (drones.Length > 0)
            {
                Drone myDrone = drones[0];
                Console.WriteLine($"\n--- Управление выбранным дроном [{myDrone.Model}] ---");

                int command = -1;
                while (command != 0)
                {
                    Console.Write("Введите команду (1 - взлет, 0 - выход): ");
                    if (int.TryParse(Console.ReadLine(), out command))
                    {
                        if (command == 1)
                        {
                            myDrone.TakeOff();
                        }
                        else if (command != 0)
                        {
                            Console.WriteLine("Неизвестная команда.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода числа.");
                    }
                }
            }

            Console.WriteLine("Программа завершена.");
        }
    }
}
