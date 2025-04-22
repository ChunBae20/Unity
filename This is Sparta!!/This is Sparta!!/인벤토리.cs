//인벤토리



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlytestTRPG; //나만 추가


namespace This_is_Sparta__
{

    internal class Item //  ♥♥♥♥♥♥♥internal추가
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
            string status = IsEquiped ? $"[E]" : "";  //♥♥♥♥♥♥♥♥♥와 지수님 감사합니다ㅠㅠstatus라는걸 써주셨군요흠 이거 str알def 따로 장비에 int값 넣어주셔야 할것같은데용 그래야 쉽게 불러올수있을것같아요
            string prefix = withIndex ? $"-{index + 1}" : "- ";
            Console.WriteLine($"{prefix}. {status}{ItemName} | {ItemType} | {ItemStat}");  //♥♥♥♥♥♥♥♥타입이 공격력 방어력인가? 그러면 공방 만 불러오면 되겠네?장착여르를 [E]로 갑지하고 불값으로 불러오면 되겠네?
        }                                                                                      //♥♥♥♥♥♥♥♥♥♥♥어? 공교롭게도 itemType 이 string으로 통합됐네?개꿀이잖아?
                                                                                               //♥♥♥♥♥isItemType 선언 안됐고? 개꿀개꿀왕개꿀개꿀
    }                                                                                          //아 잠깐만 설마 이거 겹치나?status클래스랑?

    public class Inventory // ♥♥♥♥♥♥♥♥♥♥♥♥♥이거 상속좀 뺄게요 ㅠㅠ스택오버플로나요 대신 쓸때는 MainSpace로 해야할것같아요 : MainSpace // pull 완료 시 메인 체인지
    {                       //♥♥♥♥♥♥♥♥♥♥♥♥인터널에서 퍼블릭으로 바꿀게요 인터널이라서 메인의new inven에서 접근이 안되네용





        internal static Item[] equipment =                   //internal  쓰겟습니다. 
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

            int num = MainSpace.Input(0, 1);  //♥♥♥♥♥♥♥♥♥♥♥여기도 MainSpace.으로 바꿀게요 ♥♥♥♥♥♥

            switch (num)
            {
                case 0: MainSpace.MainMenu(); break;
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


                int num = MainSpace.Input(0, equipment.Length);/// ♥♥♥♥♥여기도 MainSpace.Input으로 바꿀게요 왜냐면 상송하면 무한반복스택오버플로♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥   

                switch (num)
                {
                    case 0: InventoryUI(); break;
                    default:
                        equipment[num - 1].IsEquiped = !equipment[num - 1].IsEquiped;
                        SearchEquipWeapon();//♥♥♥♥♥밑에 장비 공격력 추가한거 여기에 서 적용할게요
                        string action = equipment[num - 1].IsEquiped ? "장착" : "해제";
                        Console.WriteLine($"\n{equipment[num - 1].ItemName} {action} 완료");

                        Console.WriteLine("\n아무 키나 누르면 계속합니다...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        //♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥이거좀 추가할게요 아이템장비추가 너무힘들어요..ㅠㅠ 뭐가문젠지 어떻게든 연결하려고해봤지만 안돼서 2시간의 고민끝네나온결정임다.,..

        public void SearchEquipWeapon()
        {
            int weaponSTR = 0; //무기공격력    혹시라도 나중에 공격력이랑 방어력 등 두개 이상 할수도있을거같으니일단 이렇게해둠
            int weaponDEF = 0; // 방어구 공격력
            int weaponCRT = 0; // 치명타
            int weaponAVD = 0; // 회피

            for (int i = 0; i < Inventory.equipment.Length; i++)
            {
                if (Inventory.equipment[i].IsEquiped == true)                 // 장창된게 확인된다면
                {
                    if (Inventory.equipment[i].ItemType == "공격력")          //아이템 타입이 공격력이라면
                    {
                        weaponSTR += Inventory.equipment[i].ItemStat;
                    }
                    else if (Inventory.equipment[i].ItemType == "방어력")     //아이템 타입이 방어력이라면
                    {
                        weaponDEF += Inventory.equipment[i].ItemStat;         //weaponDEF에 방어력을 더해준다
                    }
                    else if (Inventory.equipment[i].ItemType == "치명타")     //아이템 타입이 치명타라면
                    {
                        weaponCRT += Inventory.equipment[i].ItemStat;         //weaponCRT에 치명타를 더해준다
                    }
                    else if (Inventory.equipment[i].ItemType == "회피")       //아이템 타입이 회피라면
                    {
                        weaponAVD += Inventory.equipment[i].ItemStat;         //weaponAVD에 회피를 더해준다
                    }
                }
                else
                {
                    
                }

            }
            // 여기서 Status에 저장
            MainSpace.status.nowEquipSTR = weaponSTR;
            MainSpace.status.nowEquipDEF = weaponDEF;
            MainSpace.status.nowEquipCRT = weaponCRT;
            MainSpace.status.nowEquipAVD = weaponAVD;

        }



    }
}
