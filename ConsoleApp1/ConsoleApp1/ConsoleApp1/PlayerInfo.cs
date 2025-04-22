using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    public class PlayerInfo
    {

        public int level = 1;
        public string job = "(전사)";
        public int str = 10;
        public int def = 10;
        public int hp = 100;
        public int gold = 1500;


        public void InputOne()//dksl 여기서 씨 스태틱쓰면 딸깍 이긴한데 레벨같은 변수도 다 스태틱으로 바꿔야도ㅓㅣ네 이러면 나중에 캐릭터 여러개일때 안되잖아.
                            //지금 여기서 스태틱 안썼는데 메인씬에서  PlayerInfo.InputOne();스태틱마냥 써서 오류발생중임정신나가버릴거같아그냥 과제제출용으로 딸깍마렵네


        {
            ReInput:

            Console.WriteLine(" 플레이어 상태창 보기 화면입니다. \n\n\n" );

            Console.Clear();
            Console.WriteLine("Lv." + level);
            Console.WriteLine("Chad" + job);
            Console.WriteLine("공격력" + str);
            Console.WriteLine("방어력" + def);
            Console.WriteLine("체력" + hp);
            Console.WriteLine("Gold" + gold);
            Console.WriteLine("\n\n\n");


            Console.WriteLine("0.나가기\n\n\n\n\n\n\n\n\n원하시는 행동을 입력해주세요");

            string? exitZero = Console.ReadLine();//에라이 모르겠다 예 다가져가세요 눌도 들어오세 그냥 다 가져가세요

            if (exitZero == "0")
            {
                // MainScene.newStart();//이거는 왜 안되는데 메인씬으로 좀 처 가세요 제발
                MainScene.newStart();
            }




            while (exitZero != "0")
            {
                Console.WriteLine("잘못된 입력값입니다.");

                goto ReInput;
            }

        }




    }
}
