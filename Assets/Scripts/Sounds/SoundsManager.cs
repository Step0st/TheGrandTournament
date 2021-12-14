using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoundsManager : MonoBehaviour
{
    [HideInInspector]public AudioSource source;
    
    [SerializeField] private AudioClip _stepSound;
    [SerializeField] private AudioClip _jumpSound;
    
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    public void StepSound()
    {
        Play(_stepSound);
    }
    
    public void JumpSound()
    {
        Play(_jumpSound);
    }
    
    
    public void Play(AudioClip clip, float volume = 1f, bool loop = true)
    {
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.Play();
    }
}
