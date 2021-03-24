using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceSE; //SEのスピーカー
    public AudioClip audioClip; //　ならす素材

    void Start()
    {
    }

    public void PlaySE()
    {
        audioSourceSE.PlayOneShot(audioClip);

    }

}
