using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Purchase
    {

        public bool isEquipArmorS = false;
        public bool isEquipArmorM = false;
        public bool isEquipArmorSp = false;
        public bool isEquipSword = false;
        public bool isEquipAxe = false;
        public bool isEquipSpear = false;


        public List<string> sellInfo = new List<string>();


        public Purchase()
        {
            sellInfo.Add("수련자 갑옷 1000G");
            sellInfo.Add("무쇠 갑옷 1000G");
            sellInfo.Add("스파르타의 갑옷 3500G");
            sellInfo.Add(" 낡은 검 600G");
            sellInfo.Add(" 청동 도끼 1500G");
            sellInfo.Add(" 스파르타의 창 1000G");


        }
        public void InputPurchase()
        {
        ReInput:
            Console.WriteLine("상점 - 아이템 구매\n\n필요한 아이템을 얻을 수 있는 상점입니다.");


            List<string> sellInfo = GameManager.purchase.sellInfo;
            for (int i = 0; i < sellInfo.Count; i++)
            {
                string equipStatus = "";

                if (i == 0 && isEquipArmorS) equipStatus = "[E] ";
                if (i == 1 && isEquipArmorM) equipStatus = "[E] ";
                if (i == 2 && isEquipArmorSp) equipStatus = "[E] ";
                if (i == 3 && isEquipSword) equipStatus = "[E] ";
                if (i == 4 && isEquipAxe) equipStatus = "[E] ";
                if (i == 5 && isEquipSpear) equipStatus = "[E] ";


                Console.WriteLine($"{i + 1}. {equipStatus}{sellInfo[i]}");


            }

            string? selectForEuqip = Console.ReadLine();
            bool CanIBuyEquipArmorS = false;
            bool CanIBuyEquipArmorM = false;
            bool CanIBuyEquipArmorSp = false;
            bool CanIBuyisEquipSword = false;
            bool CanIBuyisEquipAxe = false;
            bool CanIBuyisEquipSpear = false;

            

                if (selectForEuqip == "0")
                {
                    MainScene.newStart();
                }


            if (selectForEuqip == "1")
            {
                isEquipArmorS = !isEquipArmorS;


                if (isEquipArmorS == true)
                {
                    GameManager.player.def += 5;
                    Console.WriteLine("숙련자의 갑옷이 장착되었습니다.");
                    Console.WriteLine("현재 방어력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }
                else
                {
                    GameManager.player.def -= 5;
                    Console.WriteLine("숙련자의 갑옷이 장착 해제되었습니다.");
                    Console.WriteLine("현재 방어력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;


                }
            }

            if (selectForEuqip == "2")
            {
                isEquipArmorM = !isEquipArmorM;

                if (isEquipArmorM == true)
                {
                    GameManager.player.def += 9;
                    Console.WriteLine(" 무쇠 갑옷이 장착되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }

                else
                {
                    GameManager.player.def -= 9;
                    Console.WriteLine("무쇠 갑옷이 장착해제되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }
            }

            if (selectForEuqip == "3")
            {

                isEquipArmorSp = !isEquipArmorSp;
                if (isEquipArmorSp == true)
                {
                    GameManager.player.def += 15;
                    Console.WriteLine(" 스파르타 갑옷이 장착되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }
                else
                {
                    GameManager.player.def -= 15;
                    Console.WriteLine("스파르타 갑옷이 장착 해제되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.def);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;

                }

            }
            if (selectForEuqip == "4")
            {

                isEquipSword = !isEquipSword;
                if (isEquipSword == true)
                {
                    GameManager.player.str += 2;
                    Console.WriteLine("낡은 검이 장착 되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;
                }

                else
                {
                    GameManager.player.str -= 2;
                    Console.WriteLine("낡은 검이 장착 해제되었습니다.");

                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;
                }
            }
            if (selectForEuqip == "5")
            {

                isEquipAxe = !isEquipAxe;
                if (isEquipAxe == true)
                {
                    GameManager.player.str += 5;
                    Console.WriteLine("청동 도끼가 장착 되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;
                }

                else
                {
                    GameManager.player.str -= 5;
                    Console.WriteLine("청동도끼가 해제 되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;
                }
            }

            if (selectForEuqip == "6")
            {

                isEquipSpear = !isEquipSpear;
                if (isEquipSpear == true)
                {
                    GameManager.player.str += 7;
                    Console.WriteLine("스파르타의 창이 장착 되었습니다.");
                    Console.WriteLine("현재 공격력 :" + GameManager.player.str);
                    Console.WriteLine(" 아무키나입력");
                    Console.ReadKey();
                    goto ReInput;
                }

                else
                {
                    GameManager.player.str -= 7;
                    Console.WriteLine("스파르타의 창이 해제 되었습니다.");
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
