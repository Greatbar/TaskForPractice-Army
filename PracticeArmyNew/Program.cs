using System;
using System.Collections.Generic;

namespace PracticeArmyNew
{
    class Program
    {
        public static void Main()
        {
            bool isgameplaying = true;
            List <Warriors> Army = AddWarriors();

            while (isgameplaying)
            {
                Menu();
                int chose = Convert.ToInt32(Console.ReadLine());

                switch (chose)
                {
                    case 1:
                        foreach (Warriors warriors in Army)
                        {
                            string info = String.Format(
                                "{0}: Здоровье = {1}, Урон = {2}, Броня = {3}, Скорость = {4}",
                                warriors.Name, warriors.Hp, warriors.Attack, warriors.Armor, warriors.Speed
                                );
                            Console.WriteLine(info);
                        }
                        break;
                    case 2:
                        float general_hp = 0;
                        float general_attack = 0;
                        float general_armor = 0;
                        int units_number = 0;
                        foreach (Warriors warriors in Army)
                        {
                            units_number++;
                            general_hp +=  warriors.Hp;
                            general_attack += warriors.Attack;
                            general_armor += warriors.Armor;
                        }
                        ArmyInfo(general_hp, general_attack, general_armor, units_number);
                        break;
                    case 3:
                        Console.WriteLine("Нанести урон: ");
                        float user_attack = float.Parse(Console.ReadLine());
                        Warriors unit = Army[0];
                        if (user_attack >= unit.Armor)
                        {
                            float hp = unit.DamageHit(user_attack);
                            if (unit.IfUnitAlive())
                            {
                                Console.WriteLine("Юнит '{0}' уничтожен, Командор, что делать дальше?", unit.Name);
                                Army.RemoveAt(0);
                            }
                            else
                            {
                                Console.WriteLine("Юнит '{0}' получил урон! Его здоровье всего лишь {1}.", unit.Name, unit.Hp);
                            }
                        }
                        else
                        {
                            float hp = unit.DamageHit(user_attack);
                            Console.WriteLine("Юнит '{0}' броня не пробита! Его броня {1} и Здоровье {2}", unit.Name, unit.Armor, unit.Hp);
                        }
                        if (Army.Count == 0)
                        {
                            Console.WriteLine("Ваша армия мертва, Сэр! Хотите начать по новой?");
                            isgameplaying = false;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Битва завершена, командор, мы отступаем!");
                        isgameplaying = false;
                        break;
                }
            }
        }

        private static List<Warriors> AddWarriors()
        {
            List<Warriors> Army = new List<Warriors>();
            Army.Add(new Warriors("Баллиста (Боеприпас - Bolt)", 644, 16, 0, 0));
            Army.Add(new Warriors("Маг", 22, 8, 10, 10));
            Army.Add(new Warriors("Солдат", 139, 11, 20, 20));
            Army.Add(new Warriors("Всадник", 34, 50, 34, 120));
            Army.Add(new Warriors("Рино", 73, 30, 0, 100));
            return Army;
        }

        private static void Menu()
        {
            Console.WriteLine("\n1 - Параметры армии");
            Console.WriteLine("2 - Общие показатели армии");
            Console.WriteLine("3 - Нанести урон");
            Console.WriteLine("4 - Закончить сражение\n");
            Console.WriteLine("Выберите что вы хотите сделать: ");
        }

        static void ArmyInfo(float general_hp, float general_attack, float general_armor, int units_number)
        {
            Console.WriteLine(
                "\nОбщее здоровье Вашей армии: '{0}'. Командор, мы хорошо подготовились?\n" +
                "Общий урон Вашей армии: '{1}'. Никто не сможет выстоять против нас!\n" +
                "Общая защита Вашей армии: {2}. С новой броней нас не победить!\n" +
                "Общая численность Вашей армии: {3}. Вся деревня за нас...",
                general_hp, general_attack, general_armor, units_number
                );
        }
    }
}
