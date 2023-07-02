using UnityEngine;

[CreateAssetMenu(menuName = "KID/Data Health Enemy")]
public class DataHealthEnemy : DataHealth
{
    [Header("掉落經驗值物件")]
    public GameObject prefabExp;
    [Header("掉落經驗值機率"), Range(0, 1)]
    public float dropProbability;
}
