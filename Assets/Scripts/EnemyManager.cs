﻿using System;
using UnityEngine;

//敵を管理
public class EnemyManager : MonoBehaviour
{
    Action tapAction;
    public new string name;
    public int hp;
    public int at;

    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log("モンスターのHPは" + hp);
    }

    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        tapAction();
        Debug.Log("クリック");
    }
}
