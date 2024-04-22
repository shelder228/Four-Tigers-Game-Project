using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;
    private void Awake()
    {
        int countMusic = FindObjectsOfType<SoundManager>().Length;

        if (countMusic > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        LoadVolume();
    }

    public void ChangeValueSound()
    {
        float volume = soundsSlider.value;
        mixer.SetFloat("Sounds", volume);
        PlayerPrefs.SetFloat(Constants.SOUNDS, volume);
    }

    public void ChangeValueMusic()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat(Constants.MUSIC, volume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat(Constants.MUSIC);
        soundsSlider.value = PlayerPrefs.GetFloat(Constants.SOUNDS);
        
        ChangeValueMusic();
        ChangeValueSound();
    }
}