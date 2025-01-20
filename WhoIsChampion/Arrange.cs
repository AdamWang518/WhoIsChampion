using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsChampion
{
    internal class Arrange
    {
        public void Basic(List<Player> playerList)
        {
            Fight fight = new Fight();

            while (playerList.Count > 1)
            {
                List<Player> nextRoundPlayer = new List<Player>();
                for (int i = 0; i < playerList.Count; i += 2)
                {
                    Player winner = fight.DeathMatch(playerList[i], playerList[i + 1]);
                    Console.WriteLine($"{playerList[i].Name}對戰{playerList[i + 1].Name}");
                    Console.WriteLine($"{winner.Name}獲得勝利");
                    nextRoundPlayer.Add(winner);
                }
                playerList = nextRoundPlayer;
            }
            Console.WriteLine($"比賽結束，{playerList[0].Name}獲得最終勝利");
        }
        public List<Player> Single(List<Player> playerList)
        {
            List<Player> result = new List<Player>();
            List<Player> seedList;
            Fight fight = new Fight();
            (playerList, seedList) = getSeed(playerList);
            for (int i = 0; i < playerList.Count; i += 2)
            {
                Player winner = fight.DeathMatch(playerList[i], playerList[i + 1]);

                Console.WriteLine($"{playerList[i].Name}對戰{playerList[i + 1].Name}");
                Console.WriteLine($"{winner.Name}獲得勝利");
                result.Add(winner);
            }
            result.AddRange(seedList);
            return result;
        }
        public Dictionary<RaceType, List<Player>> Muilti(Dictionary<RaceType, List<Player>> playerDict, int defeat)
        {
            //每個key都比一輪
            List<Player> winnersBracket = new List<Player>(); // 勝者組
            List<Player> losersBracket = new List<Player>();  // 敗者組
            Fight fight = new Fight();
            //需考慮敗者組比賽跟勝者組比賽會重疊的問題(example先比勝者後這些人被加到敗者，然後又在敗者賽中比了一次)
            for (int i = 0; i < playerDict[0].Count; i += 2)
            {
                Player winner = fight.DeathMatch(playerDict[0][i], playerDict[0][i + 1]);
                Player loser = (winner == playerDict[0][i]) ? playerDict[0][i] : playerDict[0][i+1];
                Console.WriteLine($"{playerDict[0][i].Name}對戰{playerDict[0][i + 1].Name}");
                Console.WriteLine($"{winner.Name}獲得勝利");
                Console.WriteLine($"{loser.Name}敗北");
                winnersBracket.Add(winner);
                losersBracket.Add(loser);

                return playerDict;
            }

        }
            public (List<Player>, List<Player>) getSeed(List<Player> playerList)
            {
                List<Player> seedList = new List<Player>();
                int seedLength = FindClosestPowerOfTwo(playerList.Count());

                (playerList, seedList) = SplitList(playerList, seedLength);
                foreach (Player player in seedList)
                {
                    Console.WriteLine($"{player.Name}獲選為種子");
                }

                return (playerList, seedList);
            }
            (List<Player>, List<Player>) SplitList(List<Player> list, int index)
            {
                List<Player> firstPart = list.Take(index).ToList();
                List<Player> secondPart = list.Skip(index).ToList();

                return (firstPart, secondPart);
            }
            private int FindClosestPowerOfTwo(int n)
            {
                if (n <= 0) return 1;

                // 計算以2為底的對數
                double logBase2 = Math.Log(n, 2);

                // 找到最接近的整數次方
                int lower = (int)Math.Floor(logBase2);
                // 計算 2^lower 和 2^upper
                int lowerPower = (int)Math.Pow(2, lower);

                // 回傳最接近的值
                return lowerPower;
            }
        }
        
    }
