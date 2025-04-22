using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EquipManager
    {
        public bool isEquipArmor = false;
        public bool isEquipSpear = false;
        public bool isEquipSword = false;

        public void InputOne()
        {
        ReInput:
            Console.Clear();
            Console.WriteLine("장착 관리를 할 수 있습니다.");

            Console.WriteLine("인벤토리 - 장착 관리\r\n보유 중인 아이템을 관리할 수 있습니다. ");
            Console.WriteLine("[아이템 목록]\n\n- 1 [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.\r\n- 2 [E]스파르타의 창  | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.\r\n- 3 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다. ");

            Console.WriteLine("\n\n\n 나가기 0번\n\n\n아이템 장착/해제는 해당번호 입력");

            List<string> inventory = GameManager.inventoryInfo.inventory;
            for (int i = 0; i < inventory.Count; i++)
            {
                string equipStatus = "";

                if (i == 0 && isEquipArmor) equipStatus = "[E] ";
                if (i == 1 && isEquipSpear) equipStatus = "[E] ";
                if (i == 2 && isEquipSword) equipStatus = "[E] ";


                Console.WriteLine($"{i + 1}. {equipStatus}{inventory[i]}");
                

            }

            /* 쉽지않네 나중에 강해져서 foreach도 해본다.

             foreach (string item in GameManager.inventoryInfo.inventory)
             {
                 if (isEquipArmor == true)
                 {
                     Console.WriteLine("[E]" + item);
                 }
                 else
                     Console.WriteLine(item);
                 if (isEquipSpear == true)
                 {
                     Console.WriteLine("[E]" + item);
                 }
                 else
                     Console.WriteLine(item);
                 if (isEquipSword == true)
                 {
                     Console.WriteLine("[E]" + item);
                 }
                 else
                     Console.WriteLine(item);

             }

             */

            // public List<string> inventory = new List<string>();

            // Console.WriteLine(GameManager.inventoryInfo());




            string? selectForEuqip = Console.ReadLine(); //사용자가 입력하는 것을 string nullable타입의 변수명 selectforeuqip 에 저장하겠음


            if (selectForEuqip == "0")
            {
                MainScene.newStart();
            }


                if (selectForEuqip == "1")
            {
                isEquipArmor = !isEquipArmor;  //토글 완전히 이해함 수학처럼 생각하면 안됨 !isEquip = isEquip 는 문법적으로 틀림 !isEquip이게 값이기 때문임. 글고 isEquip = !isEquip가 
                                     //isEquip을 반대로 바꾼후 !isEquip(오해해서 이게 걍 isequip 의 반대의 값 즉 not이라는 의미를 갖는줄 알았음
                                     //사실은 isequip이라는 두가지 밖에 없는 전등 스위치처럼 이 문장을 통과할때마다 바뀌는 거였는데 ㅋㅋ

                if (isEquipArmor == true)
                {
                    GameManager.player.def += 5;
                    Console.WriteLine("무쇠갑옷이 장착되었습니다.");
                    Console.WriteLine("현재 방어력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }
                else
                {
                    GameManager.player.def -= 5;
                    Console.WriteLine("무쇠갑옷이 장착 해제되었습니다.");
                    Console.WriteLine("현재 방어력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;


                }
            }

            if (selectForEuqip == "2")
            {
                isEquipSpear = !isEquipSpear;

                if (isEquipSpear == true)
                {
                    GameManager.player.str += 7;
                    Console.WriteLine("스파르타의 창이 장착되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }

                else
                {
                    GameManager.player.str -= 7;
                    Console.WriteLine("스파르타의창이이 장착해제되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }
            }

            if (selectForEuqip == "3")
            {

                isEquipSword = !isEquipSword;
                if (isEquipSword == true)
                {
                    GameManager.player.str += 2;
                    Console.WriteLine("낡은 검이 장착되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }
                else
                {
                    GameManager.player.str -= 2;
                    Console.WriteLine("낡은 검이 장착 해제되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }

            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                goto ReInput;

            }
        }

    }
}
