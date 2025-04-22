using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This_is_Sparta__
{
    internal class Quest : MainSpace
    {
        public string questName;
        public string questDescription;
        public string questRequest;
        public string[] questReward;
        public int questProgress;
        public int questGoal;
        public bool IsFinished = false;

        static List<Quest> QuestList = new List<Quest>()
        {
            new Quest
            {
                questName = "마을을 위협하는 미니언 처치",
                questDescription = "이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\r\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\r\n모험가인 자네가 좀 처치해주게!",
                questRequest = "미니언 5마리 처치",
                questProgress = 0,
                questGoal = 5,
                questReward = new string[] {"쓸만한 방패 x 1", "5G" }
            }
        };

        public void QuestOption()
        {
            Console.Clear();
            Console.WriteLine("Quest!!");

            for (int i = 0; i < QuestList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {QuestList[i].questName}");
            }

            Console.WriteLine("\n\n원하시는 퀘스트를 선택해주세요.");
            Console.Write(">> ");

            int num = Input(1, QuestList.Count);

            QuestSelect(QuestList[num - 1]);

        }

        public void QuestSelect(Quest selectQuest)
        {
            Console.Clear();
            Console.WriteLine("Quest!!");
            Console.WriteLine($"\n{selectQuest.questName}");
            Console.WriteLine($"\n{selectQuest.questDescription}");
            Console.WriteLine($"\n- {selectQuest.questRequest} ({selectQuest.questProgress} / {selectQuest.questGoal})");
            Console.WriteLine("- 보상 -");
            Console.WriteLine($"\n{selectQuest.questReward}");
            Console.WriteLine("\n\n1. 수락");
            Console.WriteLine("2. 거절");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">> ");

            int num = Input(1, 2);

            switch (num)
            {
                case 1: QuestAccept(selectQuest); break;
                case 2: MainMenu(); break;
            }
        }

        public void QuestAccept(Quest quest)
        {
            if (quest.questProgress == quest.questGoal)
            {
                quest.IsFinished = true;
                QuestSuccess(quest);
            }
            else
            {
                Console.WriteLine("\n퀘스트가 수락되었습니다!\n");
                Thread.Sleep(1000);
                MainMenu();
            }
        }

        public void QuestSuccess(Quest quest)
        {
            Console.Clear();
            Console.WriteLine("Quest!!");
            Console.WriteLine($"\n{quest.questName}");
            Console.WriteLine($"\n{quest.questDescription}");
            Console.WriteLine($"\n- {quest.questRequest} ({quest.questProgress} / {quest.questGoal})");

            Console.WriteLine("- 보상 -");
            Console.WriteLine($"\n{string.Join("\n", quest.questReward)}");
            Console.WriteLine("\n\n1. 보상 받기");
            Console.WriteLine("2. 돌아가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">> ");

            int num = Input(1, 2);

            switch (num)
            {
                case 1: Reward(); break;
                case 2: MainMenu(); break;
            }
        }

        public void Reward()
        {
            Console.Clear();
            Console.WriteLine("보상을 받았습니다!");

            Thread.Sleep(1000);
            MainMenu();

        }
    }
}
