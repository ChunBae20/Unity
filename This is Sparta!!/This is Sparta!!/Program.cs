using System;
using System.Collections.Generic;

namespace This_is_Sparta__
{

    public class Reward
    {
        public string Name;
        public int Amount;

        public Reward(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
    public class MonsterReward
    {
        public string MonsterType;
        public Func<Reward> GetReward;

        public MonsterReward(string type, Func<Reward> rewardFunc)
        {
            MonsterType = type;
            GetReward = rewardFunc;
        }
    }
    internal class Program
    {

        private static int level;
        private static string name;
        private static int maxHp;
        private static int currentHp;
        private static int mostersDefeated;

        static readonly Dictionary<string, List<Reward>> dropTable = new Dictionary<string, List<Reward>> 
        {
           { "미니언",      new List<Reward>{ new Reward("Gold",  50) } },
           { "공허충",      new List<Reward>{ new Reward("Gold", 150) } },
           { "대포미니언",  new List<Reward>{
          new Reward("Gold",  300),
          new Reward("포션", 1),
          new Reward("낡은검", 1)
              }}
        };


        private static int goldReward;
        private static int potionCount;
        private static int swordCount;

        static void Main(string[] args)
        {
            setDate();

            var kills = new List<string> { "미니언", "공허충", "대포미니언" };
            bool allDead = (kills.Count >= mostersDefeated);

            // ShowBattleResult는 CollectAllRewards를 내부에서 호출하므로
            // 잊지 말고 여기에 반드시 CollectAllRewards 정의가 있어야 합니다.
            ShowBattleResult(allDead, kills, maxHp, currentHp);
        }
        static void setDate()
        {
            level = 1;
            name = "Chad";
            maxHp = 100;
            currentHp = 74;
            mostersDefeated = 3;
        }

        // — 보상 합산 메서드 (dropTable 기반) —
        static List<Reward> CollectAllRewards(List<string> kills)
        {
            // 1) 임시로 보상 합계를 저장할 딕셔너리
            var aggregated = new Dictionary<string, int>();

            // 2) kills 리스트에 기록된 몬스터별로 dropTable에서 보상 꺼내오기
            foreach (var mType in kills)
            {
                // dropTable에서 이 몬스터의 보상 목록(drops)을 얻고
                if (!dropTable.TryGetValue(mType, out var drops))
                    continue;  // 없는 몬스터면 건너뛰기

                // 각각의 Reward를 aggregated에 누적
                foreach (var r in drops)
                {
                    // 없으면 0으로 시작
                    if (!aggregated.ContainsKey(r.Name))
                        aggregated[r.Name] = 0;
                    aggregated[r.Name] += r.Amount;
                }
            }

            // 3) 딕셔너리를 List<Reward>로 변환해서 반환
            var result = new List<Reward>();
            foreach (var kv in aggregated)
                result.Add(new Reward(kv.Key, kv.Value));

            return result;
        }
        static void ShowBattleResult(bool allMonstersDead, List<string> kills, int initHp, int finalHp)
        {
            // 보상 계산
            var rewards = CollectAllRewards(kills);

            // Victory vs Lose 분기
            if (allMonstersDead)
                DisplayResultUI("Victory", kills.Count, initHp, finalHp, rewards);
            else
                DisplayResultUI("You Lose", kills.Count, initHp, finalHp, rewards);
        }

        static void DisplayResultUI(
            string resultText,
            int monsterCount,
            int initHp,
            int finalHp,
            List<Reward> rewards)
        {
            Console.Clear();
            Console.WriteLine("Battle!! - Result\n");
            Console.WriteLine(resultText + "\n");
            Console.WriteLine($"던전에서 몬스터 {monsterCount}마리를 {(resultText == "Victory" ? "잡았습니다" : "시도했습니다")}.\n");

            Console.WriteLine("[캐릭터 정보]");
            Console.WriteLine($"HP {initHp} -> {finalHp}\n");

            Console.WriteLine("[획득 보상]");
            if (rewards.Count == 0)
            {
                Console.WriteLine("없음\n");
            }
            else
            {
                foreach (var r in rewards)
                    Console.WriteLine($"{r.Name} +{r.Amount}");
                Console.WriteLine();
            }

            Console.WriteLine("0. 다음");
            CheckInput(0, 0);
            // → 이후 메인UI로 복귀하거나 게임종료 처리
        }


        static int CheckInput(int min, int max)
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine().Trim();
                bool isNumber = int.TryParse(input, out result);
                if (isNumber)
                {
                    if (result >= min && result <= max)
                        return result;
                }
                Console.WriteLine("잘못된 입력입니다.");
            }


        }


    }
}

