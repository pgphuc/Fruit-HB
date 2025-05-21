using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;

    private AudioSource sfxSource;
    [SerializeField] private AudioClip ripClip;
    [SerializeField] private AudioClip pickUpClip;
    [SerializeField] private AudioClip tomatoJaredClip;
    [SerializeField] private AudioClip closeLidClip;
    [SerializeField] private AudioClip victoryClip;

    private void Start()
    {
        sfxSource = GetComponent<AudioSource>();

        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void OnRip()
    {
        sfxSource.PlayOneShot(ripClip);
    }

    public void OnPickUp()
    {
        sfxSource.PlayOneShot(pickUpClip);
    }

    public void OnTomatoJared()
    {
        sfxSource.PlayOneShot(tomatoJaredClip);
    }

    public void OnCloseLid()
    {
        sfxSource.PlayOneShot(closeLidClip);
    }

    public void OnVictory()
    {
        sfxSource.PlayOneShot(victoryClip);
    }
}