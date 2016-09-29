using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    public static AudioManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public struct LoadAsset
    {
        public string name;
        public AudioClip clip;
    }

    public List<LoadAsset> assets = new List<LoadAsset>();


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

    void InitClips()
    {
        for (int i = 0; i < assets.Count; i++)
        {
            audioClips.Add(assets[i].name, assets[i].clip);
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
        InitClips();
        InitSources();
	}          
	
	// Update is called once per frame
	void Update () {
	
	}
}
