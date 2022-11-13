using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public List<AudioClip> clips=new List<AudioClip>();
    private List<AudioSource> audioSources = new List<AudioSource>();


    public void PlayAudio(string name)
    {
        AudioSource source = GetAudioSources();
        AudioClip clip = GetAudioClip(name);
        source.clip = clip;
        source.Play();
    }

    private AudioClip GetAudioClip(string name)
    {
        for (int i = 0; i < clips.Count; i++)
        {
            if (clips[i].name == name)
                return clips[i];
        }
        return null;
    }

    private AudioSource GetAudioSources()
    {
        for (int i = 0; i < audioSources.Count; i++)
        {
            if (!audioSources[i].isPlaying)
                return audioSources[i];
        }
        AudioSource target= gameObject.AddComponent<AudioSource>();
        audioSources.Add(target);
        return target;
    }

}
