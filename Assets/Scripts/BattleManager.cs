using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーとエネミーの対戦管理
public class BattleManager : MonoBehaviour
{
    public PlayerManager player;
    public EnemyManager enemy;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;

    void Start()
    {
        player.Attack(enemy);
        playerUI.UpdateUI(player);

        enemy.Attack(player);
        enemyUI.UpdateUI(enemy);
    }
}
