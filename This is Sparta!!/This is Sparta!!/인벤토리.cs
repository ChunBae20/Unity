using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This_is_Sparta__
{

    class Item
    {
        public string ItemName;
        public string ItemType;
        public int ItemStat;
        public bool IsEquiped = false;

        public Item(string itemName, string itemType, int itemStat)
        {
            ItemName = itemName;
            ItemType = itemType;
            ItemStat = itemStat;
        }

        public void Equip(bool withIndex = false, int index = 0)
        {
            string status = IsEquiped ? $"[E]" : "";
            string prefix = withIndex ? $"-{index + 1}" : "- ";
            Console.WriteLine($"{prefix}. {status}{ItemName} | {ItemType} | {ItemStat}");
        }

    }

    internal class Inventory : MainSpace // pull 완료 시 메인 체인지
    {
        static Item[] equipment =
        [
            new("낡은 검", "공격력", 2),
            new("낡은 옷", "방어력", 2)
        ];

        public void InventoryUI()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("캐릭터의 장비가 표시 됩니다.\n");

            for (int i = 0; i < equipment.Length; i++)
            {
                equipment[i].Equip(false, i);
            }

            Console.WriteLine("\n1. 장착");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            int num = Input(0, 1);

            switch (num)
            {
                case 0: MainMenu(); break;
                case 1: EquippedAndUnequipped(); break;
            }
        }

        public void EquippedAndUnequipped()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착");
                Console.WriteLine("캐릭터의 장비를 장착 및 해제 가능 합니다.\n");

                for (int i = 0; i < equipment.Length; i++)
                {
                    equipment[i].Equip(true, i);
                }

                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">> ");


                int num = Input(0, equipment.Length);

                switch (num)
                {
                    case 0: InventoryUI(); break;
                    default:
                        equipment[num - 1].IsEquiped = !equipment[num - 1].IsEquiped;

                        string action = equipment[num - 1].IsEquiped ? "장착" : "해제";
                        Console.WriteLine($"\n{equipment[num - 1].ItemName} {action} 완료");

                        Console.WriteLine("\n아무 키나 누르면 계속합니다...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
