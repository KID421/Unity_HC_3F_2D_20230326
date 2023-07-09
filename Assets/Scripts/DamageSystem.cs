using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("血量資料")]
    public DataHealth data;
    [Header("畫布傷害值")]
    public GameObject prefabDamage;

    protected float hp;
    protected float hpMax;

    private void Awake()
    {
        hp = data.hp;
        hpMax = hp;
    }

    public virtual void GetDamage(float damage)
    {
        // print($"<color=#ff6699>受到的傷害 {damage}</color>");
        hp -= damage;
        GameObject tempDamage = Instantiate(prefabDamage, transform.position, Quaternion.identity);
        tempDamage.transform.Find("文字傷害值").GetComponent<TextMeshProUGUI>().text = damage.ToString();
        Destroy(tempDamage, 1.5f);

        if (hp <= 0) Dead();
    }

    protected virtual void Dead()
    {
        
    }
}
