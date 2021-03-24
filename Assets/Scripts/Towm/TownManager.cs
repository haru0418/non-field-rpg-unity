using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }
}
