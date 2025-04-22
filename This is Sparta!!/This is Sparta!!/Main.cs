using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace This_is_Sparta__
{
    internal class MainSpace // 메인에 Ctrl + C, Ctrl + V
    {
        HealItem healItem = new HealItem();
        Inventory inventory = new Inventory();
        Quest quest = new Quest();
        static void Main(string[] arg)
        {
            MainSpace mainSpace = new MainSpace();
            mainSpace.MainMenu();
        }

        public void MainMenu()
        {
            inventory.InventoryUI();
            healItem.Heal();
            quest.QuestOption();
        }
        public int Input(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "";
                bool IsSelect = int.TryParse(input, out int number);

                if (IsSelect && min <= number && max >= number)
                {
                    return number;
                }
                Console.WriteLine("잘못된 입력입니다");
            }
        }
    }
}
