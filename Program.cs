using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;

namespace FirstQuestion;

class Program
{
    public static void Main(string[] args)
    {
        List<Car> database = new();
        while (true)
        {
            Console.WriteLine("Выберите действие:\n1 - Добавить сведения о машине\n2 - Удалить сведения о машине\n3 - Завершить сеанс");
            string put = Console.ReadLine();
            if (int.Parse(put) == 1)
            {
                // Задание 1
                Car newCar = new Car();
                newCar.RegNumber = GetRegNumber();

                while (true)
                {
                    Console.WriteLine("Введите государственный регистрационный номер автомобиля: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Поле регистрационного номера не может быть пустым.");
                        continue;
                    }

                    newCar.RegNumber = input;
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Введите модель машины: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Поле модели не может быть пустым.");
                        continue;
                    }

                    newCar.Model = input;
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Введите цвет машины: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Поле цвета не может быть пустым.");
                        continue;
                    }

                    newCar.Color = input;
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Введите ФИО владельца: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Поле не может быть пустым. Попробуйте ещё раз.");
                        continue;
                    }

                    if (input.Any(char.IsDigit))
                    {
                        Console.WriteLine("В ФИО человека не должно быть чисел. Попробуйте ещё раз.");
                        continue;
                    }

                    newCar.Holder = input;
                    break;
                }

                database.Add(newCar);
                Console.WriteLine($"\nДобавлена информация о машине: \nНомер: {newCar.RegNumber}\nМодель: {newCar.Model}\nЦвет: {newCar.Color}\nФИО владельца: {newCar.Holder}");
                continue;
            }
            else if (int.Parse(put) == 2)
            {
                while (true)
                {
                    Console.WriteLine("Введите номер автомобиля для удаления из базы: ");
                    string regNumber = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrWhiteSpace(regNumber))
                    {
                        Console.WriteLine("Номер не может быть пустым. Попробуйте ещё раз.");
                        continue;
                    }

                    var carToRemove = database.FirstOrDefault(c => c.RegNumber == regNumber);
                    if (carToRemove != null)
                    {
                        database.Remove(carToRemove);
                        Console.WriteLine("Данные о машине успешно удалены");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. В базе нет автомобиля с таким номером.");
                        continue;
                    }
                }

            }
            else if (int.Parse(put) == 3)
            {
                Console.WriteLine("Заполнение базы оконченою");
                break;
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Повторите ввод.");
                continue;
            }
        }

        // Задание 2.1
        Character newCharacter = new Character();

        while (true)
        {
            Console.WriteLine("\nВведите символ: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Поле не может быть пустым. Повторите ввод.");
                continue;
            }

            if (input.Length != 1)
            {
                Console.WriteLine("Нужно ввести ровно один символ. Попробуйте снова.");
                continue;
            }

            if (!char.TryParse(input, out char parsedChar))
            {
                Console.WriteLine("Ошибка ввода. Преобразование не удалось.");
                continue;
            }

            newCharacter.SetChar(parsedChar);
            break;
        }

        newCharacter.PrintChar();

        // Задание 2.2
        TwoSimbols newTwoSimbols = new();

        while (true)
        {
            Console.WriteLine("\nВведите первый символ: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
            {
                Console.WriteLine("Нужно ввести ровно один символ. Повторите ввод.");
                continue;
            }
            if (!char.TryParse(input, out char parsedChar))
            {
                Console.WriteLine("Ошибка ввода.");
                continue;
            }

            newTwoSimbols.One = parsedChar;
            break;
        }

        while (true)
        {
            Console.WriteLine("\nВведите второй символ: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
            {
                Console.WriteLine("Нужно ввести ровно один символ. Повторите ввод.");
                continue;
            }
            if (!char.TryParse(input, out char parsedChar))
            {
                Console.WriteLine("Ошибка ввода.");
                continue;
            }

            newTwoSimbols.Two = parsedChar;
            break;
        }

        newTwoSimbols.Method();

        // Задание 2.3
        IntFields newIntFields1 = new IntFields(1, 2);
        Console.WriteLine($"IntFields: NumOne={newIntFields1.NumOne}, NumTwo={newIntFields1.NumTwo}");
    }
    // === Дополнительные функии ==
    // Проверка ввода
    public static string NormalizeInput(string prompt, string errorMessage)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine(errorMessage);
        }
    }

    public static bool IsThisTrueRegNumber(string input)
    {
        if (char.IsLetter(input[0]) &&
            char.IsDigit(input[1]) &&
            char.IsDigit(input[2]) &&
            char.IsDigit(input[3]) &&
            char.IsLetter(input[4]) &&
            char.IsLetter(input[5])
        )
            return true;
        return false;
    }
    public static string GetRegNumber()
    {
        while (true)
        {
            string number = NormalizeInput(
                "Введите государственный регистрационный номер автомобиля: ",
                "Поле регистрационного номера не может быть пустым.");

            if (IsThisTrueRegNumber(number))
                return number;

            Console.WriteLine("Вы ввели недействительный номер. Повторите ввод.");
        }
    }
    // === Классы ===
    // Задание 1
    class Car
    {
        public string RegNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Holder { get; set; }
    }

    // Задание 2.1
    class Character
    {
        private char cr;
        public void SetChar(char cha)
        {
            cr = cha;
        }

        public int CharCode(char cha)
        {
            return (int)cha;
        }

        public void PrintChar()
        {
            Console.WriteLine("\nВаш символ: " + cr + "\nКод вашего символа: " + CharCode(cr));
        }
    }

    // Задание 2.2
    class TwoSimbols
    {
        public char One { get; set; }
        public char Two { get; set; }

        public void Method()
        {
            int start = (int)One;
            int end = (int)Two;

            if (start < end)
            {
                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine((char)i);
                }
            }
            else if (end < start)
            {
                for (int i = start; i >= end; i--)
                {
                    Console.WriteLine((char)i);
                }
            }
            else
            {
                Console.WriteLine(One);
            }
        }
    }

    // Задание 2.3
    class IntFields
    {
        public int NumOne { get; set; }
        public int NumTwo { get; set; }
        public IntFields(int numFirst, int numSecond)
        {
            NumOne = numFirst;
            NumTwo = numSecond;
        }

        public IntFields(int numFirst)
        {
            NumOne = numFirst;
        }

        public IntFields() { }
    }
}
