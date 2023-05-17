using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Effect
{
    public string soundName;
    public AudioClip clip;
    public AudioSource source;
}
public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [Header("효과음 등록")]
    [SerializeField]
    public Effect[] effectSounds;

    void Start()
    {
        instance = this;
        //bgm이랑 bgs랑 다름!!!

        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source = gameObject.AddComponent<AudioSource>();
            effectSounds[i].source.clip = effectSounds[i].clip;
            effectSounds[i].source.loop = false;
        }
        if (effectSounds.Length != 9)
        {
            this.effectSounds[4].source.pitch = 1.5f;
            this.effectSounds[4].source.volume = 0.3f;
            this.effectSounds[9].source.pitch = 2;
            this.effectSounds[10].source.pitch = 1.5f;
            this.effectSounds[11].source.loop = true;
        }
        else
        {
            effectSounds[0].source.pitch = 0.7f;
        }
    }
    
    public void SetEffectVolume(Slider slider)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            effectSounds[i].source.volume = slider.value;
            if (i == 4)
                this.effectSounds[4].source.volume *= 0.5f;
        }
    }
}
