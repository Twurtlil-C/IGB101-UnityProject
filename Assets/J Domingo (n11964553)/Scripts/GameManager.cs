using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton Instance
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // Ensure GameManager Singleton exists only once
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
    #endregion

    public GameObject player;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;    
    public Text pickupText;

    // Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    private AudioSource myAudioSource;

    // Level Complete SFX
    public AudioClip levelCompleteSFX;
    private bool completeSFXPlayed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();

        if (levelComplete && !completeSFXPlayed && levelCompleteSFX != null)
        {
            PlayAudioClip(levelCompleteSFX, 0.5f, 1.0f);
            completeSFXPlayed = true;
        } 
    }

    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
        {
            levelComplete = true;
        }
        else
        {
            levelComplete = false;
        }
    }

    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    /// <summary>
    /// Loop for playing audio proximity events - AudioSource based
    /// </summary>
    private void PlayAudioSamples()
    {
        for (int i = 0;  i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }

    public void PlayAudioClip(AudioClip clip, float volume, float pitch)
    {
        myAudioSource.clip = clip;
        myAudioSource.volume = volume;
        myAudioSource.pitch = pitch;

        myAudioSource.Play();
    }
}
