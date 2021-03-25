using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefeb;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0; //現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);

    }

    IEnumerator Seaching()
    {
        //背景を大きく
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1f, 1f, 1f));
        //フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));
        //
        yield return new WaitForSeconds(2f);

        
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
        else
        {
            stageUI.Showbuttons();
        }
    }

    //Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.Hidebuttons();
        StartCoroutine (Seaching());
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
