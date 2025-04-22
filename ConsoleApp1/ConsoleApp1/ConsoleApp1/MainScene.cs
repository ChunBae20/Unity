using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public static class MainScene
    {
        static void Main(string[] args)
        {
            MainScene.newStart();
        }

        public static void newStart()
        {





            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n\n원하는 행동의 숫자를 타이핑하면 실행합니다.\n\n");
            // Console.WriteLine("\n1. 상태 보기\n2. 인벤토리 \r\n3. 상점\n\n");

            mainStartScene:
                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리 \r\n3. 상점\n\n");
                string? chooseThree = (Console.ReadLine());


                switch (chooseThree)
                {
                    case "1":
                        Console.WriteLine("상태를 봅니다.");
                        GameManager.player.InputOne();


                        break;
                    case "2":
                        Console.WriteLine("인벤토리를 봅니다.");
                    GameManager.inventoryInfo.InputTwo();

                    break;
                    case "3":
                        Console.WriteLine("상점을봅니다.");

                    GameManager.store.InputThree();
                        break;
                    default:

                    Console.Clear();
                    Console.WriteLine("잘못된 입력값입니다.");


                        for (int i = 1; i < 11; i++)
                        {

                            Console.Write("■■■■");
                        }
                        goto mainStartScene;






                }

         }   
             
    }
}


