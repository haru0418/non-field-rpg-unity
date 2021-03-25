using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//プレイヤーとエネミーの対戦管理
public class BattleManager : MonoBehaviour
{
    public Transform cameraObj;
    public PlayerManager player;
    EnemyManager enemy;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public QuestManager questManager;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
        playerUI.SetupUI(player);
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
        StopAllCoroutines();
        DialogTextManager.instance.SetScenarios(new string[] { "プレイヤーの攻撃" });
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hp <= 0)
        {
            StartCoroutine(EndBattle());
        }
        else
        {
            StartCoroutine(EnemyAttack());
        }
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySE(1);
        cameraObj.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
        DialogTextManager.instance.SetScenarios(new string[] { "モンスターの攻撃" });
        if (player.hp <= 0)
        {
            questManager.PlayerDeath();
        }

    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);
        enemyUI.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.Endbattle();
    }
}
