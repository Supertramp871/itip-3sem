using System;

namespace pr1
{
    internal class Program
    {
        abstract class Cat
        {
            // Поля
            protected string name;
            protected int age;
            protected double weight;

            // Конструктор
            public Cat()
            {
                name = "Неизвестная";
                age = 4;
                weight = 5.0;
            }

            public Cat(string name, int age, double weight)
            {
                Name = name;
                Age = age;
                Weight = weight;
            }

            // Свойства
            public string Name { get; set; }
            public int Age { get; set; }
            public double Weight { get; set; }

            // Виртуальные методы
            public virtual void DisplayClassName()
            {
                Console.WriteLine("Класс: Cat");
            }
            public virtual void Pet()
            {
                Console.WriteLine($"Вы погладили {Name}, {Name} - счастлива.");
            }

            // Абстрактные методы
            public abstract void Speak();
            public abstract void Play();
            public abstract void Feed();
            public abstract void DisplayJudging();

            // Перегрузка ToString()
            public override string ToString()
            {
                return String.Format(" Имя по паспорту - {3} \n Имя кошки - {0} \n Возраст кошки - {1} лет \n Вес кошки - {2} килограмм \n", Name, Age, Weight, GetType().Name);
            }


            // Перегрузка операторов сравнения
            public static bool operator ==(Cat cat1, Cat cat2)
            {
                // Если оба объекта null, они равны
                if (ReferenceEquals(cat1, null) && ReferenceEquals(cat2, null))
                {
                    return true;
                }

                // Если один из объектов null, они не равны
                if (ReferenceEquals(cat1, null) || ReferenceEquals(cat2, null))
                {
                    return false;
                }

                return cat1.weight == cat2.weight && cat1.age == cat2.age && cat1.name == cat2.name;
            }

            public static bool operator !=(Cat cat1, Cat cat2)
            {
                return !(cat1 == cat2);
            }

        }

        class ScottishCat : Cat
        {
            private const int percent_of_judgment = 60;
            private int percent_of_hapinnes = 50;

            public ScottishCat(string name, int age, double weight) : base(name, age, weight) { }
            public int PercentOfHapinnes { get; set; }


            // Методы
            public override void DisplayClassName()
            {
                base.DisplayClassName();
                Console.WriteLine("Класс: ScottishCat");
            }
            public override void Pet()
            {
                base.Pet();
                Console.WriteLine("Шотландская вислоухая хочет еще.");
                percent_of_hapinnes += 10;
                Console.WriteLine("Уровень счастья поднялся на 10%. ");
            }

            public override void Speak()
            {
                Console.WriteLine("Шотландская вислоухая мяукает на волынке. ");
            }

            public override void Play()
            {
                Console.WriteLine($"{Name} поиграла и похудела на 10 грамм :) ");
                Weight -= 0.1;
                Console.WriteLine($"{Name} устала. ");
            }

            public override void Feed()
            {
                Console.WriteLine($"{Name} поела и потолстела на 30 грамм :( ");
                Weight += 0.3;
                Console.WriteLine($"{Name} не наелась. ");
            }


            public override void DisplayJudging()
            {
                Judging();
            }

            public static void Judging()
            {
                Random random = new Random(); // Генератор случайных чисел
                double randomValue = random.NextDouble() * 100; // Случайное число от 0 до 100

                if (randomValue <= percent_of_judgment)
                {
                    Console.WriteLine("Шотландская вислоухая смотрит на вас с осуждением.");
                }
                else
                {
                    Console.WriteLine("Шотландская вислоухая не решилась вас осуждать.");
                }
            }

            // Уникальный метод
            public void CheckHappines()//-----------------------------------------------------------------------
            {
                Console.WriteLine("Метод CheckHappines()");
                Console.WriteLine($"Кошка счастлива на {percent_of_hapinnes} процентов");
            }

            // Перегрузка ToString()
            public override string ToString()
            {
                return String.Format(" Имя по паспорту - {4} \n Имя кошки - {0} \n Возраст кошки - {1} лет \n Вес кошки - {2} килограмм \n Процент счасться - {3} \n ", Name, Age, Weight, percent_of_hapinnes, GetType().Name);
            }

            //Перегрузка арифметической операции сложения двух кошек
            public static ScottishCat operator +(ScottishCat cat1, ScottishCat cat2)
            {
                return new ScottishCat("Кошка-Мутант", (cat1.age + cat2.age) / 2, cat1.weight + cat2.weight);
            }

        }

        sealed class MeinKunCat : Cat
        {
            private const int percent_of_judgment = 100;
            private int count_of_destroyed_shoez;

            public MeinKunCat(string name, int age, double weight, int countOfDestroyedShoez) : base(name, age, weight) => DestroyedShoez = countOfDestroyedShoez;
            public int DestroyedShoez { get; set; }

            // Методы
            public override void DisplayClassName()
            {
                base.DisplayClassName();
                Console.WriteLine("Класс: MeinKunCat");
            }
            public override void Pet()
            {
                base.Pet();
                Console.WriteLine("Но в следующий раз надо попросить разрешение! ");
            }

            public override void Speak()
            {
                Console.WriteLine("Мейн кун не желает говорить. ");
            }

            public override void Play()
            {
                Console.WriteLine("Мейн кун не желает с вами играть. ");
            }

            public override void Feed()
            {
                Console.WriteLine("Мейн кун деликатно откусил вам палец и потолстел на 50 грамм... ");
                Weight += 0.5;
            }

            public override void DisplayJudging()
            {
                Judging();
            }
            public static void Judging()
            {
                Random random = new Random(); // Генератор случайных чисел
                double randomValue = random.NextDouble() * 100; // Случайное число от 0 до 100

                if (randomValue <= percent_of_judgment)
                {
                    Console.WriteLine("Мейн Кун смотрит на вас с осуждением. ");
                }
                else
                {
                    Console.WriteLine("Мейн кун не решился вас осуждать. ");
                }
            }

            // Уникальный метод
            public void DestroyYourShoez() //--------------------------------------------------------------------------------------------
            {
                Console.WriteLine("Метод DestroyYourShoez()");
                Console.WriteLine($"Мейн кун унизтельно уничтожил {DestroyedShoez} ваших ботинок");
            }


            // Перегрузка ToString()
            public override string ToString()
            {
                return String.Format(" Имя по паспорту - {4} \n Имя кошки - {0} \n Возраст кошки - {1} лет \n Вес кошки - {2} килограмм \n Количество ботнок которые унчитожат - {3} \n ", Name, Age, Weight, DestroyedShoez, GetType().Name);
            }

        }
        
        class PersidCat : Cat
        {
            private const int percent_of_judgment = 80;
            private int count_of_money;

            public PersidCat(string name, int age, double weight, int count_of_money) : base(name, age, weight) => CountOfMOney = count_of_money;
            public int CountOfMOney { get; set; }

            // Методы
            public override void DisplayClassName()
            {
                base.DisplayClassName();
                Console.WriteLine("Класс: PersidCat");
            }

            public override void Pet()
            {
                base.Pet();
                Console.WriteLine("В следующий раз старайтесь лучше! ");
            }
            public override void Speak()
            {
                Console.WriteLine($"{Name} мяукнула, в далеке слышны египетские мотивы. ");
            }

            public override void Play()
            {
                Console.WriteLine($"{Name} поиграла и похудела на 60 грамм :) ");
                Weight -= 0.6;
                Console.WriteLine($"{Name} никогда не устанет. ");
            }

            public override void Feed()
            {
                Console.WriteLine($"{Name} поела и потолстела на 10 грамм :( ");
                Weight += 0.1;
                Console.WriteLine($"{Name} больше не хочет. ");
            }

            public override void DisplayJudging()
            {
                Judging();
            }
            public static void Judging()
            {
                Random random = new Random(); // Генератор случайных чисел
                double randomValue = random.NextDouble() * 100; // Случайное число от 0 до 100

                if (randomValue <= percent_of_judgment)
                {
                    Console.WriteLine("Персидская кошка смотрит на вас с осуждением. ");
                }
                else
                {
                    Console.WriteLine("Персидская кошка не решилась вас осуждать. (ВЫ ИЗБРАННЫЙ) ");
                }
            }

            // Уникальный метод
            public void CheckBankAccount() //--------------------------------------------------------------------------------------------
            {
                Console.WriteLine("Метод CheckBankAccount()");
                Console.WriteLine("{0} сегодня щедра, она дала вам {1} драхм, теперь у нее ничего нету. ", Name, CountOfMOney);
                CountOfMOney = 0;
            }


            // Перегрузка ToString()
            public override string ToString()
            {
                return String.Format(" Имя по паспорту - {4} \n Имя кошки - {0} \n Возраст кошки - {1} лет \n Вес кошки - {2} килограмм \n Драхм на счету- {3} \n ", Name, Age, Weight, CountOfMOney, GetType().Name);
            }


        }

        class SfinksCat : Cat
        {
            private const int percent_of_judgment = 10;
            private const int percent_of_allergy = 50;

            public SfinksCat(string name, int age, double weight) : base(name, age, weight) { }

            // Методы
            public override void DisplayClassName()
            {
                base.DisplayClassName();
                Console.WriteLine("Класс: SfinksCat");
            }

            public override void Pet()
            {
                base.Pet();
                Console.WriteLine($"{Name} - много и не надо для счастья"); ;
            }
            public override void Speak()
            {
                Console.WriteLine($"{Name} мяукнула. {Name} не хочет чтобы вы уходили :( ");
            }

            public override void Play()
            {
                Console.WriteLine($"{Name} поиграла и похудела на 10 грамм :) ");
                Weight -= 0.1;
                Console.WriteLine($"{Name} некуда худеть. ");
            }

            public override void Feed()
            {
                Console.WriteLine($"{Name} поела и потолстела на 40 грамм :( ");
                Weight += 0.4;
                Console.WriteLine($"{Name} любит кушать. ");
            }

            public override void DisplayJudging()
            {
                Judging();
            }
            public static void Judging()
            {
                Random random = new Random(); // Генератор случайных чисел
                double randomValue = random.NextDouble() * 100; // Случайное число от 0 до 100

                if (randomValue <= percent_of_judgment)
                {
                    Console.WriteLine("Персидская кошка смотрит на вас с осуждением. Вам очень не повезло. ");
                }
                else
                {
                    Console.WriteLine("Персидская кошка не решилась вас осуждать. Лишь бы вы ее не осуждали. ");
                }
            }

            // Уникальный метод
            public void GetAllergy() //--------------------------------------------------------------------------------------------
            {
                Console.WriteLine("Метод GetAllergy()");
                Random random = new Random(); // Генератор случайных чисел
                double randomValue = random.NextDouble() * 100; // Случайное число от 0 до 100

                if (randomValue <= percent_of_allergy)
                {
                    Console.WriteLine($"У вас аллергия на прекрасную {Name}. ");
                }
                else
                {
                    Console.WriteLine($"У вас нет аллергии на прекрасную {Name}, ваша жизнь будет счастливой");
                }
            }


            // Перегрузка ToString()
            public override string ToString()
            {
                return String.Format(" Имя по паспорту - {4} \n Имя кошки - {0} \n Возраст кошки - {1} лет \n Вес кошки - {2} килограмм \n Вероятность что у вас аллергия на кошку- {3} \n ", Name, Age, Weight, percent_of_allergy, GetType().Name);
            }
        }

        // Главное меню
        static int Menu1()
        {
            int choosed = -1;
            bool validInput = false;

            while (!validInput)
            {
                // Если это не первая итерация, выводим сообщение об ошибке
                if (choosed != -1)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 0 до 8.");
                }

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Создать Шотландскую вислоухую");
                Console.WriteLine("2 - Создать Мейн-Куна");
                Console.WriteLine("3 - Создать Персидскую");
                Console.WriteLine("4 - Создать Сфинкса");
                Console.WriteLine("5 - Вывести свойства объекта");
                Console.WriteLine("6 - Выполнить базовые методы объекта");
                Console.WriteLine("7 - Выполнить уникальный метод обьекта");
                Console.WriteLine("8 - Вывод имени обьекта");
                Console.WriteLine("0 - Выход");

                validInput = Int32.TryParse(Console.ReadLine(), out choosed) && (choosed >= 0 && choosed <= 8);

                Console.Clear();
            };

            return choosed;
        }

        // Меню для выбора метода
        static int Menu2()
        {
            int choosed = -1;
            bool validInput = false;

            while (!validInput)
            {
                // Если это не первая итерация, выводим сообщение об ошибке
                if (choosed != -1)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 0 до 5.");
                }

                Console.WriteLine("Выберите метод:");
                Console.WriteLine("1 - Попросить мякнуть");
                Console.WriteLine("2 - Погладить");
                Console.WriteLine("3 - Поиграть.");
                Console.WriteLine("4 - Покормить.");
                Console.WriteLine("5 - Получить осуждающий взгляд.");
                Console.WriteLine("0 - Выход");

                validInput = Int32.TryParse(Console.ReadLine(), out choosed) && (choosed >= 0 && choosed <= 5);

                Console.Clear();
            };

            return choosed;
        }

        // Методы для получения корректного числа от пользователя
        static string GetNameInput()
        {
            Console.WriteLine("Введите имя: ");
            return Console.ReadLine();
        }

        static int GetAgeInput()
        {
            int value;
            while (true)
            {
                Console.Write("Введите возраст от 1 года до 100 лет: ");
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
                Console.Write("Введите вес от 0 до 20 кг: ");
                if (double.TryParse(Console.ReadLine(), out value) && (value >= 0.0 && value <= 20.0))
                {
                    break;
                }
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
            return value;
        }
        
        // Метод для MeinKunCat
        static int GetDestroyedShoezInput()
        {
            int value;
            while (true)
            {
                Console.WriteLine("Введите количесвто ботинок которые уничтожат от 1 до 100: ");
                if ((int.TryParse(Console.ReadLine(), out value)) && (value >= 0 && value <= 100))
                { break; }
                Console.WriteLine("Некорректный ввод. Попробуйте снова: ");
            }
            
            return value;
        }

        // Метод для PersidCat
        static int GetMoneyInput()
        {
            int value;
            while (true)
            {
                Console.WriteLine("Введите количесвто драхм которые есть у кошки от 1 до 10000: ");
                if ((int.TryParse(Console.ReadLine(), out value)) && (value >= 0 && value <= 10000))
                { break; }
                Console.WriteLine("Некорректный ввод. Попробуйте снова: ");
            }

            return value;

        }

        public static void Main()
        {
            string name;
            int age;
            double weight;

            int count_of_destroyed_shoez;
            int count_of_money;

            Cat live_cat = null;
            
            int choosed1 = -1;
            while (choosed1 != 0)
            {
                choosed1 = Menu1();
                switch (choosed1)
                {
                    case 1:
                        // Создание вислоухой
                        name = GetNameInput();
                        age = GetAgeInput();
                        weight = GetWeightInput();

                        live_cat = new ScottishCat(name, age, weight);
                        Console.WriteLine("Создана Шотландская вислоухая кошка.");
                        break;
                    case 2:
                        // Создание мейн куна
                        name = GetNameInput();
                        age = GetAgeInput();
                        weight = GetWeightInput();

                        count_of_destroyed_shoez = GetDestroyedShoezInput();

                        live_cat = new MeinKunCat(name, age, weight, count_of_destroyed_shoez);
                        Console.WriteLine("Создан Мейн кун.");
                        break;
                    case 3:
                        // создание персидской
                        name = GetNameInput();
                        age = GetAgeInput();
                        weight = GetWeightInput();

                        count_of_money = GetMoneyInput();

                        live_cat = new PersidCat(name, age, weight, count_of_money);
                        Console.WriteLine("Создана Персидская Кошка");
                        break;
                    case 4:
                        // Создание сфинкса
                        name = GetNameInput();
                        age = GetAgeInput();
                        weight = GetWeightInput();

                        live_cat = new SfinksCat(name, age, weight);
                        Console.WriteLine("СФИНКС БЫЛ СОЗДАН...");
                        break;
                    case 5:
                        // вывести свойства обьекта
                        if (live_cat != null)
                        {
                            Console.WriteLine(live_cat.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте объект.");
                        }
                        break;
                    case 6:
                        // выполнить базовые методы обьекта
                        int choosed2 = -1;
                        choosed2 = Menu2();
                        if(live_cat != null)
                        {
                            switch (choosed2)
                            {
                                case 1:
                                    live_cat.Speak();
                                    break;
                                case 2:
                                    live_cat.Pet();
                                    break;
                                case 3:
                                    live_cat.Play();
                                    break;
                                case 4:
                                    live_cat.Feed();
                                    break;
                                case 5:
                                    live_cat.DisplayJudging();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("Error...");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте объект.");
                        }
                        break;
                    case 7:
                        // выполнить уникальный метод объекта
                        if (live_cat != null)
                        {
                            switch (live_cat)
                            {
                                case ScottishCat Cat1:
                                    Cat1.CheckHappines();
                                    break;
                                case MeinKunCat Cat2:
                                    Cat2.DestroyYourShoez();
                                    break;
                                case PersidCat Cat3:
                                    Cat3.CheckBankAccount();
                                    break;
                                case SfinksCat Cat4:
                                    Cat4.GetAllergy();
                                    break;
                                default:
                                    Console.WriteLine("Неизвестный тип.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте объект.");
                        }
                        break;
                    case 8:
                        // вывод имени обьекта
                        if (live_cat != null)
                        {
                            live_cat.DisplayClassName();
                        }
                        else
                        {
                            Console.WriteLine("Сначала создайте объект.");
                        }
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
