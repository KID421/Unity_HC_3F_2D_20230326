using UnityEngine;

public class TeleportSystem : MonoBehaviour
{
    [SerializeField]
    private TeleportSystem otherDoor;

    private Transform player;

    public bool inDoor;

    private void Awake()
    {
        player = GameObject.Find("µR¤û").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inDoor) return;

        if (collision.gameObject.name.Contains("µR¤û"))
        {
            otherDoor.inDoor = true;
            inDoor = true;
            player.transform.position = otherDoor.transform.position;

            Invoke("DelayReset", 1);
        }
    }

    private void DelayReset()
    {
        otherDoor.inDoor = false;
        inDoor = false;
    }
}
