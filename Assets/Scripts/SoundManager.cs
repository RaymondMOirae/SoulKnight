using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource fxSource;
    public AudioSource bgSource;
    public static SoundManager theSoundManager = null;
    public float lowPitch = 0.95f;
    public float highPitch = 1.05f;
    // Start is called before the first frame update
    void Awake()
    {
        if(theSoundManager == null)
        {
            theSoundManager = this;
        }else if(theSoundManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        fxSource.clip = clip;
        fxSource.Play();
    }
}
