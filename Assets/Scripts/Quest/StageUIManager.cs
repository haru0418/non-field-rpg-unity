using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//stageUIを管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject backButton;
    public GameObject stageClearImage;

    private void Start()
    {
        stageClearImage.SetActive(false);
    }

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("ステージ : {0}", currentStage+1);
        
    }

    public void Hidebuttons()
    {
        nextButton.SetActive(false);
        backButton.SetActive(false);
    }

    public void Showbuttons()
    {
        nextButton.SetActive(true);
        backButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        backButton.SetActive(true);
    }
}
