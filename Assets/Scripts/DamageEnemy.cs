using UnityEngine;

public class DamageEnemy : DamageSystem
{
    private DataHealthEnemy dataEnemy;

    private void Start()
    {
        dataEnemy = (DataHealthEnemy)data;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("武器"))
        {
            float attack = collision.gameObject.GetComponent<Weapon>().attack;
            GetDamage(attack);
        }
    }

    protected override void Dead()
    {
        Destroy(gameObject);
        DropExp();
    }

    private void DropExp()
    {
        // print("這隻怪物的掉落經驗機率：" + dataEnemy.dropProbability);
        if (Random.value <= dataEnemy.dropProbability)
        {
            Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
        }
    }
}
