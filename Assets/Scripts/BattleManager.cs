using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーとエネミーの対戦管理
public class BattleManager : MonoBehaviour
{
    public PlayerManager player;
    public EnemyManager enemy;
    void Start()
    {
        player.Attack(enemy);
        enemy.Attack(player);
    }
}
