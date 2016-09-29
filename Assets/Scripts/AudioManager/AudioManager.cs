using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    [SerializeField]
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) { 
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip; 
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol; 
        return newAudio; 
    }

    void InitSources()
    {
        foreach (KeyValuePair<string, AudioClip> clip in audioClips)
        {
            audioSources.Add(clip.Key, AddAudio(clip.Value, false, false, 1f));
        }
    }

    public void PlaySound(string audioClipName)
    {
        if (!audioSources[audioClipName].isPlaying)
        {
            audioSources[audioClipName].Play();
        }
    }

    public void StopSound(string audioClipName)
    {
        if (audioSources[audioClipName].isPlaying)
        {
            audioSources[audioClipName].Stop();
        }
    }

	// Use this for initialization
	void Start () {        
        audioClips.Add("terminal", Resources.Load<AudioClip>("Sounds/terminal"));
        InitSources();
	}          
	
	// Update is called once per frame
	void Update () {
	
	}
}
