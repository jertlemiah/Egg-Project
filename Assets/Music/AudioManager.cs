using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // public List<
    [SerializeField] public Sound[] backgroundTracks;
    private int currentSongIndex = 0;
    [SerializeField] string currentSong;
    [SerializeField] public AudioSource musicAudioSource;
    public AudioMixer mixer;
    public static AudioManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
        if(!musicAudioSource)
        {
            musicAudioSource = GetComponent<AudioSource>();
        } 
    }
    void Start()
    {
        PlayNextTrack();
    }
    public void SetVolMaster(float sliderValue)
    {
        mixer.SetFloat("VolMusic",Mathf.Log10(sliderValue)*20);
    }
    public void SetVolMusic(float sliderValue)
    {
        mixer.SetFloat("VolMaster",Mathf.Log10(sliderValue)*20);
    }
    void Update()
    {
        if(musicAudioSource.isPlaying == false)
        {
            PlayNextTrack();
        }
    }
    public void PlayNextTrack()
    {
        musicAudioSource.clip = backgroundTracks[currentSongIndex].audioClip;
        musicAudioSource.volume = backgroundTracks[currentSongIndex].volume;
        musicAudioSource.pitch = backgroundTracks[currentSongIndex].pitch;
        currentSong = backgroundTracks[currentSongIndex].soundName;
        musicAudioSource.Play();
        currentSongIndex++;
        if(currentSongIndex >= backgroundTracks.Length) { currentSongIndex=0;}
    }
}
