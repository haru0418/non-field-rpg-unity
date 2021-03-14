using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーとエネミーの対戦管理
public class BattleManager : MonoBehaviour
{
    public PlayerManager player;
    EnemyManager enemy;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;


    public void Setup(EnemyManager enemyManager)
    {
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);
    }

    void PlayerAttack()
    {
        player.Attack(enemy);
        playerUI.UpdateUI(player);

    }

    void EnemyAttack()
    {
        enemy.Attack(player);
        enemyUI.UpdateUI(enemy);

    }
}
