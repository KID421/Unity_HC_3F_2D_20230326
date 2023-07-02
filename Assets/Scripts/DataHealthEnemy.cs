using UnityEngine;

[CreateAssetMenu(menuName = "KID/Data Health Enemy")]
public class DataHealthEnemy : DataHealth
{
    [Header("掉落經驗值物件")]
    public GameObject prefabExp;
    [Header("掉落經驗值機率"), Range(0, 1)]
    public float dropProbability;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 20;
    [Header("攻擊間隔"), Range(0, 5)]
    public float attackInterval = 2.5f;
    [Header("攻擊距離"), Range(0, 10)]
    public float attackRange = 3;
}
