using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioClip bgm;
    [SerializeField] AudioClip[] sfx;


    public enum SFX { Attack,Click,Coin,EnemyDead,Gacha,PlayerDead};
    SFX type;

    AudioSource[] audioSources;



    void Awake()
    {
        instance = this;
        audioSources = GetComponents<AudioSource>();

    }
    private void Update()
    {
        VolumSetting(bgmSlider.value, sfxSlider.value);
    }

    private void VolumSetting(float bgm, float sfx)
    {
        audioSources[0].volume = bgm;
        for (int i = 1; i < audioSources.Length; i++)
        {
            audioSources[i].volume = sfx;
        }
    }

    public void BGM()
    {
        audioSources[0].clip = bgm;
        audioSources[0].Play();
    }


    public void SFXPlayer(SFX sfx1,float volum=1)
    {
        for (int i = 1; i < audioSources.Length; i++)
        {
            if (audioSources[i].isPlaying)
                continue;
            else
            {
                audioSources[i].clip = sfx[(int)sfx1];
                audioSources[i].volume = volum;
                audioSources[i].Play();

                return;
            }
        }
    }
}
