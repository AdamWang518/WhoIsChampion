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
        public List<Player> playerList=new List<Player>();
        public void createPlayer() {
            int numberOfPlayer = 0;
            numberOfPlayer=int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPlayer; i++) {
                playerList.Add(new Player(i,Console.ReadLine()));
            }
        }
    }
}
