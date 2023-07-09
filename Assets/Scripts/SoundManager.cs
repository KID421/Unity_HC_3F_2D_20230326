using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [Header("音效清單")]
    public AudioClip playerHit;
    public AudioClip playerDead;
    public AudioClip playerShoot;
    public AudioClip enemyHit;
    public AudioClip enemyDead;
    public AudioClip btnNormal;
    public AudioClip btnUpdateSkill;
    public AudioClip btnLevelUp;

    private AudioSource aud;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
        aud = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound, float min, float max)
    {
        float volume = Random.Range(min, max);
        aud.PlayOneShot(sound, volume);
    }
}
