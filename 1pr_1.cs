using System;

namespace pr1
{
    internal class Program
    {
        class ScottishCat
        {
            // Поля
            private string name;
            private int age;
            private double weight;

            private const int percent_of_judgment = 60;

            // Конструкторы
            public ScottishCat()
            {
                name = "Template кошка";
                age = 7;
                weight = 4.5;
            }

            public ScottishCat(int age, double weight)
            {
                this.age = age;
                this.weight = weight;
            }

            public ScottishCat(string name, int age, double weight)
            {
                this.name = name;
                this.age = age;
                this.weight = weight;
            }

            // Свойства
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public double Weight
            {
                get { return weight; }
                set { weight = value; }
            }

            // Методы
            public void Play()
            {
                Console.WriteLine($"{name} поиграла и похудела на 10 грамм :)");
                weight -= 0.1;
            }
            public void Feed()
            {
                Console.WriteLine($"{name} поела и потолстела на 20 грамм :(");
                weight += 0.2;
            }
            public void Pet()
            {
                Console.WriteLine($"Вы погладили {name}, {name} - счастлива.");
            }

            public static void Judging()
            {
                Random random = new Random();  // Генератор случайных чисел
                double randomValue = random.NextDouble() * 100;  // Случайное число от 0 до 100

                if (randomValue <= percent_of_judgment)
                {
                    Console.WriteLine("Шотландская вислоухая смотрит на вас с осуждением.");
                }
                else
                {
                    Console.WriteLine("Шотландская вислоухая не решилась вас осуждать.");
                }
            }

            //  Перегрузка ToString()
            public override string ToString()
            {
                return String.Format(" Имя по паспорту - {4} \n Имя кошки - {0} \n Возраст кошки - {1} лет \n Вес кошки - {2} килограмм \n Процент осуждения кошки - {3}%", name, age, weight, percent_of_judgment, GetType());
            }

            // Перегрузка операторов сравнения
            public static bool operator ==(ScottishCat cat1, ScottishCat cat2)
            {
                return cat1.weight == cat2.weight && cat1.age == cat2.age && cat1.name == cat2.name;
            }

            public static bool operator !=(ScottishCat cat1, ScottishCat cat2)
            {
                return !(cat1 == cat2);
            }

            //Перегрузка арифметической операции сложения веса
            public static ScottishCat operator +(ScottishCat cat1, ScottishCat cat2)
            {
                return new ScottishCat("Кошка-Мутант", (cat1.age + cat2.age) / 2, cat1.weight + cat2.weight);
            }
        }

        static int Menu()
        {
            int choosed = -1;
            bool validInput = false;

            while (!validInput)
            {
                // Если это не первая итерация, выводим сообщение об ошибке
                if (choosed != -1)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 0 до 6.");
                }

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Поиграть");
                Console.WriteLine("2 - Покормить");
                Console.WriteLine("3 - Погладить");
                Console.WriteLine("4 - Получить осуждающий взгляд от кошки (статический)");
                Console.WriteLine("5 - Вывести персональные данные кошки");
                Console.WriteLine("6 - Задать персональные данные кошки");
                Console.WriteLine("0 - Выход");

                validInput = Int32.TryParse(Console.ReadLine(), out choosed) && (choosed >= 0 && choosed <= 6);

                Console.Clear();
            };

            return choosed;
        }

        // Методы для получения корректного числа от пользователя
        static string GetNameInput()
        {
            Console.WriteLine("Введите имя кошки: ");
            return Console.ReadLine();
        }
        static int GetAgeInput()
        {
            int value;
            while (true)
            {
                Console.Write("Введите возраст кошки от 1 года до 100 лет: ");
                if (int.TryParse(Console.ReadLine(), out value) && (value >= 0 && value <= 100))
                {
                    break;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }

        static double GetWeightInput()
        {
            double value;
            while (true)
            {
                Console.Write("Введите вес кошки от 0 до 20 кг: ");
                if (double.TryParse(Console.ReadLine(), out value) && (value >= 0.0 && value <= 20.0))
                {
                    break;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
            return value;
        }

        public static void Main()
        {
            ScottishCat FirstCat;
            FirstCat = new ScottishCat();

            int choosed = -1;
            while (choosed != 0)
            {
                choosed = Menu();
                switch (choosed)
                {
                    case 1:
                        FirstCat.Play();
                        break;
                    case 2:
                        FirstCat.Feed();
                        break;
                    case 3:
                        FirstCat.Pet();
                        break;
                    case 4:
                        ScottishCat.Judging();
                        break;
                    case 5:
                        Console.WriteLine(FirstCat.ToString());
                        break;
                    case 6:
                        string name = GetNameInput();
                        int age = GetAgeInput();
                        double weight = GetWeightInput();
                        
                        FirstCat = new ScottishCat(name, age, weight);

                        Console.WriteLine("Кошка успешно создана.");
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Error...");
                        break;
                }
            }
        }

    }
}
