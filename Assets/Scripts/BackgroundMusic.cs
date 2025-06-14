using MainMenu;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clips;

    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (SettingsCanvas.Instance != null)
        {
            SettingsCanvas.Instance.OnSoundChange += Set;
        }
        Set();
    }

    private void Set()
    {
        float savedVolume = PlayerPrefs.GetInt("Sound", 100) / 100f;
        audioSource.volume = savedVolume;

        if (clips.Count > 0)
        {
            currentIndex = 0;
            PlayClip(currentIndex);
        }
    }

    public void PlayClip(int index)
    {
        if (index < 0 || index >= clips.Count)
        {
            Debug.LogWarning("BackgroundMusic: Invalid clip index.");
            return;
        }

        currentIndex = index;
        audioSource.clip = clips[currentIndex];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayNext()
    {
        if (clips.Count == 0) return;

        currentIndex = (currentIndex + 1) % clips.Count;
        PlayClip(currentIndex);
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
        PlayerPrefs.SetInt("Sound", Mathf.RoundToInt(volume * 100));
        PlayerPrefs.Save();
    }
}
