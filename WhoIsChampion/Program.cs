using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsChampion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 建立FightGame 類別，讓他有CreatePlayer StartGame ShowWinner的函示
            // 讓人數建立都在CreatePlayrer做
            // 然後StartGame 去拿到Player List, 就可以在 StartGame 裡面進行遊玩
            // 並且讓使用者決定要使用循環賽還是單淘汰賽 (請使用enum來做)
            // 最後做完之後透過ShowWinner 顯示最終勝利玩家
            Player p1 = new Player(1, "小明");
            Player p2 = new Player(2, "小華");
            Player p3 = new Player(3, "阿寶");
            Player p4 = new Player(4, "老皮");
            Player p5 = new Player(5, "Joker");
            List<Player> playerList = new List<Player> { p1, p2, p3, p4,p5 };
            Arrange arrange = new Arrange();
            while (playerList.Count > 1)
            {
                playerList=arrange.Single(playerList);
            }
            Console.WriteLine($"比賽結束，{playerList[0].Name}獲得最終勝利");
            Console.ReadKey();
        }
    }
}
//1.利用類別生成4個人, 其素值包含攻擊 / 防禦 / 敏捷 / 血
//    血固定為10,
//    攻擊/防禦/敏捷以亂數產生, 值為6~10
//2. 比賽採1vs1, 淘汰賽,
//    1號對2號, 3號對4號, 兩場比賽勝利者對決
//    敏捷高的人先攻, 相同則以號碼低的人先攻
//    每次攻擊扣的血量為自己的攻擊力 - 對方的防禦力,
//    若自己的攻擊小於或等於對方防禦, 則對方扣1滴血(至少要能造成對方一點傷害)
//3. 顯示每回合的戰果(比如1號對2號造成X傷害) => 多增加狀態面板
//    最後顯示贏家及其剩於血量
//4. 顯示冠軍是幾號