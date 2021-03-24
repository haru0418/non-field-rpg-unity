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
    public QuestManager questManager;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
    }


    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);
        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hp <= 0)
        {
            enemyUI.gameObject.SetActive(false);
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
        //SoundManager.instance.PlaySE(1);
        enemy.Attack(player);
        playerUI.UpdateUI(player);

    }

    void EndBattle()
    {
        SoundManager.instance.PlayBGM("Quest");
        questManager.Endbattle();
    }
}
