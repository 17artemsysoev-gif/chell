using System;

namespace ConsoleApp1
{
    public class Drone
    {
        // Поля класса (примитивные типы)
        public string Model { get; set; }
        public int BatteryLevel { get; set; } // заряд от 0 до 100
        public double Altitude { get; set; }   // высота в метрах
        public bool IsEngineOn { get; set; }

        // Конструктор
        public Drone(string model, int batteryLevel)
        {
            Model = model;
            BatteryLevel = batteryLevel;
            Altitude = 0;
            IsEngineOn = false;
        }

        // Вспомогательный конструктор из Задания 3
        public Drone(string model) : this(model, 100)
        {
        }

        // Метод для вывода информации о дроне
        public void PrintInfo()
        {
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Заряд батареи: {BatteryLevel}%");
            Console.WriteLine($"Высота: {Altitude} м");
            Console.WriteLine($"Двигатель: {(IsEngineOn ? "включен" : "выключен")}");
            Console.WriteLine();
        }

        // Метод для взлета
        public void TakeOff()
        {
            if (BatteryLevel < 20)
            {
                Console.WriteLine("Недостаточно заряда для взлета (нужно минимум 20%).");
                return;
            }

            IsEngineOn = true;
            Altitude = 10.0;
            BatteryLevel -= 5;
            Console.WriteLine($"[{Model}] взлетел на высоту 10 м. Заряд: {BatteryLevel}%");
        }

        // Метод из Задания 2: Зарядка
        public void ChargeBattery(int amount)
        {
            BatteryLevel += amount;
            if (BatteryLevel > 100)
            {
                BatteryLevel = 100;
            }
            Console.WriteLine($"Заряд после подзарядки: {BatteryLevel}%");
        }
    }
}

