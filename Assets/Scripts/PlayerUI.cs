using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("犀牛").transform;
    }

    private void Update()
    {
        transform.position = player.position;
    }
}
