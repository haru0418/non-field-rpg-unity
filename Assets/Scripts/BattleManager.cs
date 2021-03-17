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
        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hp <= 0)
        {
            Destroy(enemy.gameObject);
            EndBattle();
        }
        else
        {
            EnemyAttack();
        }
    }

    void EnemyAttack()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);

    }

    void EndBattle()
    {
        Debug.Log("バトル終了");
    }
}
