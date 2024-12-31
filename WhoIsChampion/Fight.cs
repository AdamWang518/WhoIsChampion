using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsChampion
{
    internal class Fight
    {
        public Player DeathMatch(Player playerA, Player playerB) {

            Player attackPlayer = playerA;
            Player defenderPlayer = playerB;
            (attackPlayer, defenderPlayer) = playerB.Agility > playerA.Agility ? (defenderPlayer, attackPlayer) : (attackPlayer, defenderPlayer);
            (attackPlayer, defenderPlayer) = (playerA.Agility == playerB.Agility) && (playerA.ID < playerB.ID) ? (defenderPlayer, attackPlayer) : (attackPlayer, defenderPlayer);
            while (attackPlayer.Health>0 && defenderPlayer.Health >0)
            {
                bool donthasNextTurn = PK(attackPlayer, defenderPlayer);
                if (!donthasNextTurn)
                {
                    (attackPlayer, defenderPlayer) = (defenderPlayer, attackPlayer);
                }
            }
            return attackPlayer;
        }
        private bool PK(Player playerA,Player playerB) {
            //    敏捷高的人先攻, 相同則以號碼低的人先攻
            //    每次攻擊扣的血量為自己的攻擊力 - 對方的防禦力,
            //    若自己的攻擊小於或等於對方防禦, 則對方扣1滴血(至少要能造成對方一點傷害)
            int damage = (playerA.Attack - playerB.Defence);
            int tempHealth = damage > 1 ? damage : 1;
            playerB.Health -= tempHealth;
            return playerB.Health < 0;
        }
    }
}
