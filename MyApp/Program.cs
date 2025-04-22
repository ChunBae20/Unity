using System;
using System.Collections.Generic;

namespace TextRpgBattle
{
    // 1) 몬스터 정보 클래스
    class Monster
    {
        public string Name;
        public int Level;
        public int MaxHp;
        public int Hp;
        public int Atk;
        public bool IsDead => Hp <= 0;

        public Monster(string name, int level, int hp, int atk)
        {
            Name  = name;
            Level = level;
            MaxHp = hp;
            Hp    = hp;
            Atk   = atk;
        }
    }

    // 2) 플레이어 정보 클래스
    class Player
    {
        public string Name  = "Chad";
        public string Job   = "전사";
        public int    Level = 1;
        public int    MaxHp = 100;
        public int    Hp    = 100;
        public int    Atk   = 10;
    }

    class Program
    {
        static Random rand = new Random();

        static void Main()
        {
            var player   = new Player();
            var monsters = SpawnMonsters();

            // **전투 루프**: 플레이어 차례 → 적 차례 → 반복
            while (true)
            {
                // 1) 전투 시작 / 현황 UI
                DisplayBattleStartUI(player, monsters);

                // 2) 플레이어 공격 선택 & 결과 UI
                if (!PlayerTurn(player, monsters))
                    break;  // 0(취소) 누르면 전투 종료

                // 3) Enemy Phase
                EnemyPhase(player, monsters);

                // 4) 전투 계속 여부: 몬스터 전부 죽었거나 플레이어 죽었으면 종료
                if (player.Hp <= 0 || monsters.TrueForAll(m => m.IsDead))
                    break;
            }

            // 최종 결과
            Console.Clear();
            if (player.Hp <= 0)
                Console.WriteLine("You Lose...");
            else
                Console.WriteLine("Victory!");

            Console.WriteLine("\n엔터를 눌러 종료합니다.");
            Console.ReadKey();
        }

        // ————————————————
        // 몬스터 1~4마리 랜덤 생성, 순서도 랜덤
        static List<Monster> SpawnMonsters()
        {
            var types = new List<Monster> {
                new Monster("미니언",      2, 15, 5),
                new Monster("공허충",      3, 10, 9),
                new Monster("대포미니언",  5, 25, 8)
            };

            int count = rand.Next(1, 5);
            var list  = new List<Monster>();
            for (int i = 0; i < count; i++)
            {
                var t = types[rand.Next(types.Count)];
                list.Add(new Monster(t.Name, t.Level, t.MaxHp, t.Atk));
            }
            // Fisher–Yates 섞기
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
            return list;
        }

        // 1) 전투 시작 UI
        static void DisplayBattleStartUI(Player player, List<Monster> monsters)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");
            for (int i = 0; i < monsters.Count; i++)
            {
                var m = monsters[i];
                Console.WriteLine($"Lv.{m.Level} {m.Name}   HP {m.Hp}");
            }
            Console.WriteLine("\n[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}/{player.MaxHp}\n");
            Console.WriteLine("1. 공격   (0. 도망가기)");
        }

        // 2) 플레이어 턴: 공격 선택부터 결과 표시까지
        //   반환값: true=계속, false=전투 종료(도망)
        static bool PlayerTurn(Player player, List<Monster> monsters)
        {
            Console.Write("\n원하시는 행동을 입력해주세요: ");
            int action = CheckInput(0, 1);
            if (action == 0) return false;  // 도망

            // 공격 대상 선택
            int choice;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!!\n");
                for (int i = 0; i < monsters.Count; i++)
                {
                    var m = monsters[i];
                    string status = m.IsDead ? "Dead" : $"HP {m.Hp}";
                    Console.WriteLine($"{i+1}. Lv.{m.Level} {m.Name}   {status}");
                }
                Console.WriteLine("\n0. 취소");
                Console.Write("대상을 선택해주세요: ");

                if (!int.TryParse(Console.ReadLine(), out choice)
                    || choice < 0 || choice > monsters.Count)
                {
                    Console.WriteLine("잘못된 입력입니다."); continue;
                }
                if (choice == 0) return true;  // 공격 취소, 다시 루프
                if (monsters[choice-1].IsDead)
                {
                    Console.WriteLine("이미 죽은 몬스터입니다."); continue;
                }
                break;
            }

            // 데미지 계산(±10% 오차, 소수점 올림)
            var target = monsters[choice-1];
            double err   = player.Atk * 0.1;
            int minDmg   = (int)Math.Ceiling(player.Atk - err);
            int maxDmg   = (int)Math.Ceiling(player.Atk + err);
            int damage   = rand.Next(minDmg, maxDmg + 1);

            // 결과 UI
            Console.Clear();
            Console.WriteLine("Battle!! - Result\n");
            Console.WriteLine($"{player.Name} 의 공격!");
            Console.WriteLine($"{target.Level} Lv.{target.Name} 을(를) 맞췄습니다. [데미지 : {damage}]\n");

            // HP 차감 후 상태 표시
            target.Hp -= damage;
            if (target.Hp < 0) target.Hp = 0;
            Console.WriteLine(target.IsDead
                ? $"{target.Level} Lv.{target.Name}   Dead"
                : $"{target.Level} Lv.{target.Name}   HP {target.Hp}");

            // 다음 대기
            Console.WriteLine("\n0. 다음");
            Console.Write(">> ");
            CheckInput(0, 0);

            return true;
        }

        // 3) 적 차례 UI
        static void EnemyPhase(Player player, List<Monster> monsters)
        {
            foreach (var m in monsters)
            {
                if (m.IsDead) continue;
                Console.Clear();
                Console.WriteLine("Enemy Phase\n");
                Console.WriteLine($"{m.Level} Lv.{m.Name} 의 공격!");
                Console.WriteLine($"Chad 을(를) 맞췄습니다. [데미지 : {m.Atk}]\n");

                player.Hp -= m.Atk;
                if (player.Hp < 0) player.Hp = 0;
                Console.WriteLine($"Lv.{player.Level} {player.Name}   HP {player.MaxHp} -> {player.Hp}");

                Console.WriteLine("\n0. 다음");
                Console.Write(">> ");
                CheckInput(0, 0);
            }
        }

        // 입력 범위 검사
        static int CheckInput(int min, int max)
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < min || n > max)
                Console.WriteLine("잘못된 입력입니다.");
            return n;
        }
    }
}