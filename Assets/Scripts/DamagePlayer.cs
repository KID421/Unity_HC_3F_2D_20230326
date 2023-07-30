using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
    [Header("血條")]
    public Image imgHp;
    [Header("控制系統")]
    public ControlSystem controlSystem;
    [Header("結束面板")]
    public GameObject goFinal;

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);

        imgHp.fillAmount = hp / hpMax;

        AudioClip sound = SoundManager.instance.playerHit;
        SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
    }

    protected override void Dead()
    {
        // 1. 關閉控制系統
        controlSystem.enabled = false;

        // 2. 彈出結束畫面
        goFinal.SetActive(true);

        AudioClip sound = SoundManager.instance.playerDead;
        SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
    }

    public void UpdateHealth(float updateHp)
    {
        data.hp = updateHp;
        hp = updateHp;
        hpMax = updateHp;
        imgHp.fillAmount = 1;
    }
}
