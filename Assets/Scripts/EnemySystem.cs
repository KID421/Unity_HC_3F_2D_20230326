using UnityEngine;

/// <summary>
/// 敵人系統
/// 1. 追蹤玩家
/// 2. 翻面
/// </summary>
public class EnemySystem : MonoBehaviour
{
    [Header("追蹤速度"), Range(0, 100)]
    public float moveSpeed = 3.5f;
    [Header("敵人資料")]
    public DataHealthEnemy data;

    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("犀牛").transform;
    }

    // Update 一秒執行約 60 次
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
