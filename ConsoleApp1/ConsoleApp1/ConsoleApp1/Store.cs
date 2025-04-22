using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Store
    {
        public void InputThree()
        {
        ReInput:
            Console.Clear();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다. ");
            Console.WriteLine(" [ 보유 골드 ] : "+GameManager.player.gold);
            Console.WriteLine("[ 아이템 목록 ] ");
            Console.WriteLine(" - 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.  ");
            Console.WriteLine(" - 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다. ");
            Console.WriteLine(" - 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G ");
            Console.WriteLine(" - 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다. ");
            Console.WriteLine(" - 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다. ");
            Console.WriteLine(" - 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  구매완료 ");
            Console.WriteLine("\n\n\n1.아이템구매\n0.나가기");


            String? exitStore = Console.ReadLine();





            if (exitStore == "0")
            {
                MainScene.newStart();
            }
            else if (exitStore == "1")
            {
                GameManager.purchase.InputPurchase();
            }
            else
            {
                Console.WriteLine("잘못된 값입니다.");
                goto ReInput;
            }



        }


    }

   

    
}
