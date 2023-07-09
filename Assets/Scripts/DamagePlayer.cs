using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
    [Header("血條")]
    public Image imgHp;

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);

        imgHp.fillAmount = hp / hpMax;
    }
}
