using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsChampion
{
    internal class FightGame
    {
        // 建立FightGame 類別，讓他有CreatePlayer StartGame ShowWinner的函示
        // 讓人數建立都在CreatePlayrer做
        // 然後StartGame 去拿到Player List, 就可以在 StartGame 裡面進行遊玩
        // 並且讓使用者決定要使用循環賽還是單淘汰賽 (請使用enum來做)
        // 最後做完之後透過ShowWinner 顯示最終勝利玩家
        public List<Player> playerList = new List<Player>();
        public Dictionary<RaceType, List<Player>> playerDict = new Dictionary<RaceType, List<Player>>();
        public void createPlayer()
        {
            int numberOfPlayer = 0;
            Console.WriteLine("請輸入玩家數量");
            numberOfPlayer = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPlayer; i++)
            {
                playerList.Add(new Player(i, Console.ReadLine()));
            }
            playerDict[RaceType.勝者組] = playerList;
        }
        public void setGameType()
        {
            Console.WriteLine("請輸入遊戲類型");
            Console.WriteLine("1.單淘汰賽");
            Console.WriteLine("2.雙淘汰賽");
            Console.WriteLine("3.循環賽");
            FightGameType gameType;
            while (true)
            {
                Console.Write("輸入對應的數字: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int gameTypeNum) && Enum.IsDefined(typeof(FightGameType), gameTypeNum))
                {
                    gameType = (FightGameType)gameTypeNum;
                    Console.WriteLine($"選擇的遊戲類型是: {gameType}");
                    break;
                }
                else
                {
                    Console.WriteLine("無效輸入，請輸入 1, 2 或 3。");
                }
            }

            switch (gameType)
            {
                case FightGameType.單淘汰賽:
                    Console.WriteLine("已設定為單淘汰賽。");
                    break;
                case FightGameType.雙淘汰賽:
                    Console.WriteLine("已設定為雙淘汰賽。");
                    break;
                case FightGameType.循環賽:
                    Console.WriteLine("已設定為循環賽。");
                    break;
            }
        }
    }
}
