using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    public AudioClip backgroundMusic;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        PlayMusic(backgroundMusic);
    }
    
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null || clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void PlaySoundEffect(AudioClip clip)
    {
        if (sfxSource == null || clip == null) return;

        sfxSource.PlayOneShot(clip);
    }

    void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged += OnScoreChanged;
            GameManager.Instance.OnHealthChanged += OnHealthChanged;
        }
    }

    void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= OnScoreChanged;
            GameManager.Instance.OnHealthChanged -= OnHealthChanged;
        }
    }

   void OnScoreChanged(int newScore)
{
    Debug.Log("Coin sound triggered");
    PlaySoundEffect(coinSound);
}

    void OnHealthChanged(int newHealth)
    {
        PlaySoundEffect(damageSound);
    }
}