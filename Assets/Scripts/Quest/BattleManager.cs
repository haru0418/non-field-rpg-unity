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

    }

    void EndBattle()
    {
        SoundManager.instance.PlayBGM("Quest");
        questManager.Endbattle();
    }
}
