using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private AudioSource[] _audioSources;
    private Text _text;

    private void Start()
    {
        _audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        
        _text=GetComponentInChildren<Text>();
        _text.text = "SoundON";

    }

    public void SoundOffOn()
    {
        if (_audioSources[0].enabled)
        {
            foreach(AudioSource i in _audioSources)
            {
                i.enabled = false;
                _text.text = "SoundOFF";

            }
        }
        else
        {
            foreach (AudioSource i in _audioSources)
            {
                i.enabled = true;
                _text.text = "SoundON";

            }
        }
    }

}
