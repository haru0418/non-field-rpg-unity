using System;
using UnityEngine;
using DG.Tweening;


//敵を管理
public class EnemyManager : MonoBehaviour
{
    Action tapAction;
    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;

    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    public void Damage(int damage)
    {
        Instantiate(hitEffect, this.transform);
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
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
