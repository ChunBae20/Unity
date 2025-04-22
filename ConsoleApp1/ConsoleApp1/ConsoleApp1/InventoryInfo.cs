using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InventoryInfo

    {
        public List<string> inventory = new List<string>();

        public InventoryInfo()
        {
            inventory.Add("무쇠갑옷");
            inventory.Add("스파르타의 창");
            inventory.Add("낡은 검");
        }

        public void InputTwo()
        {
        ReInput:
            Console.Clear();
            Console.WriteLine("플레이어의 인벤토리를 보여줍니다.\n");

            Console.WriteLine("원하시는 행동을 입력하세요\n\n\n");

            Console.WriteLine("[아이템 목록]");
            //원래 여기다가 add넣었는데 계속 추가하네 이거 다른사람들 til 보다가 중복방지 처리가 이거였구나
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine(inventory[i]);
            }

            Console.WriteLine("\n\n\n");

            Console.WriteLine(" 1.장착관리");
            Console.WriteLine(" 0.나가기 ");
            Console.WriteLine(" ㅁㅁㅁㅁㅁㅁㅁ ");


            //1.장착관리

            //0.나가기
            string? exitZero = Console.ReadLine();
            Console.WriteLine("잘못된 입력값입니다.");


            if (exitZero == "0") //0입력받으면 메인씬으로 이동
            {
                // MainScene.newStart();//이거는 왜 안되는데 메인씬으로 좀 처 가세요 제발
                Console.Clear();
                MainScene.newStart();
            }

            if (exitZero == "1")//1입력받으면 장착관리창으로 이동
            {
                Console.Clear();

                GameManager.equipManager.InputOne();
                return;
            }


            while (exitZero != "0") // 0이 아니라면 채팅로그 지우고 다시 ReInput으로 이동인데 조건이 참일때 계속 반복하는거잖아
                                    //위에 if문 두개 다 해당 안되면 밑으로 내려와서 while문 실행시켜야 하는거 아님?
                                    //if 랑 else if 랑 else 쓰면 되는거 아는데 이 게 왜 안되는데 ㅅ발
            {

                Console.Clear();

                goto ReInput;

            }
        }
    }
}
