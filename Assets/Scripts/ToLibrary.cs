using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToLibrary : MonoBehaviour
{
    [SerializeField]
    public int minusX;
    public int bgm;
    public float saveLibrary;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            if (saveLibrary == 9)
            {
                SaveManager.instance.Save(saveLibrary);
                LoadManager2.instance.currentLibrary = saveLibrary;
                MapManager.instance.mapUpdate();
                return;
            }
            if (GameObject.Find("Player").GetComponent<Transform>().position.y > -1)
            {
                GameObject.Find("Player").GetComponent<dqwd>().hp = 3;
                GameObject.Find("Player").GetComponent<Transform>().position += new Vector3(0, -60, 0);
                EffectManager.instance.effectSounds[11].source.clip = EffectManager.instance.effectSounds[14].source.clip;
                if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[bgm].clip)
                {
                    SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[bgm].clip;
                    SoundManager.instance.bgmPlayer.Play();
                }
                SaveManager.instance.Save(saveLibrary);
                LoadManager2.instance.currentLibrary = saveLibrary;
                MapManager.instance.mapUpdate();
                if (saveLibrary == 6)
                    SoundManager.instance.bgmPlayer.volume = GameObject.Find("BgmSlider").GetComponent<Slider>().value * 0.5f;

            }
            else if (GameObject.Find("Player").GetComponent<Transform>().position.y < -1 && saveLibrary == 8.5f)
            {
                GameObject.Find("Player").GetComponent<Transform>().position += new Vector3(minusX, 60, 0);
                EffectManager.instance.effectSounds[11].source.clip = EffectManager.instance.effectSounds[16].source.clip;
                SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[8].clip;
                SoundManager.instance.bgmPlayer.Play();
                LoadManager2.instance.currentLibrary = saveLibrary;
                SaveManager.instance.Save(saveLibrary);
                MapManager.instance.mapUpdate();
            }
        }
    }
}
