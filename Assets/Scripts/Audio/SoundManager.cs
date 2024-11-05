using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private static SoundManager instance = null;
    public static SoundManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }
    //soundͬʱ���ܲ��Ŷ��,���Ҫ����ټ�stop
    public void Play(string name)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Sound/" + name);
        if (audioClip == null)
        {
            Debug.LogError(name + " is not a sound!");
        }
        audioSource.PlayOneShot(audioClip);
    }
}