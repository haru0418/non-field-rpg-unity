﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefeb;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;

    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);

    }

    //Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        currentStage++;
        //進行度をUIに反映
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            QuestClear();
        }
        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
            
        }
    }
    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        stageUI.Hidebuttons();
        GameObject enemyobj = Instantiate(enemyPrefeb);
        EnemyManager enemy = enemyobj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void Endbattle()
    {
        stageUI.Showbuttons();
    }

    void QuestClear()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        stageUI.ShowClearText();
        //sceneTransitionManager.LoadTo("TownScene");
    }
}
