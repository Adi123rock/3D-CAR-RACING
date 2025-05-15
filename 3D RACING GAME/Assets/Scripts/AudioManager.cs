using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource SFX,BGM,Button;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void PlayButton(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name==name)
            {
                Button.clip=s.clip;
                // Button.pitch=s.pitch;
                // BGM.loop=true;
                Button.Play();
                break;
            }
        }
    }
    public void PlayBGM(string name)
    {
        
        foreach(Sound s in sounds)
        {
            if(s.name==name)
            {
                BGM.clip=s.clip;
                // BGM.pitch=s.pitch;
                BGM.loop=true;
                BGM.Play();
                break;
            }
        }
    }
    public void PlaySFX(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name==name)
            {
                SFX.clip=s.clip;
                // BGM.pitch=s.pitch;/
                // BGM.loop=true;
                SFX.Play();
                break;
            }
        }
    }
    public void StopBGM()
    {
        BGM.loop=false;
        // BGM.Pause();
    }
}
