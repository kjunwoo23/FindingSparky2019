using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ToMemory : MonoBehaviour
{
    public int nextBgm;
    public GameObject stat;
    public GameObject player1;
    public float saveLibrary;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            if (player1.GetComponent<Transform>().position.y > -80)
            {
                stat.SetActive(false);
                //player1.GetComponent<dqwd>().playerSpeed = 0.17f;
                player1.GetComponent<dqwd>().memory = true;
                if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[nextBgm].clip)
                {
                    SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[nextBgm].clip;
                    SoundManager.instance.bgmPlayer.Play();
                }
                GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 10;
                GameObject.Find("CM vcam1").GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 00);
                if (saveLibrary == 7)
                    player1.GetComponent<Transform>().position += new Vector3(30, -60, 0);
                else
                    player1.GetComponent<Transform>().position += new Vector3(0, -60, 0);
                if (saveLibrary == 6)
                    SoundManager.instance.bgmPlayer.volume = GameObject.Find("BgmSlider").GetComponent<Slider>().value;
            }
            else if (GameObject.Find("Player").GetComponent<Transform>().position.y < -80)
            {
                stat.SetActive(true);
                //player1.GetComponent<dqwd>().playerSpeed = 0.2f;
                player1.GetComponent<dqwd>().memory = false;
                if (saveLibrary == 1.5)
                    player1.transform.position = new Vector3(-159.87f, 1.98f, 0);
                else if (saveLibrary == 2.5)
                    player1.transform.position = new Vector3(185.6f, -0.6f, 0);
                else if (saveLibrary == 3.5)
                    player1.transform.position = new Vector3(479.24f, -0.62f, 0);
                else if (saveLibrary == 4.5)
                    player1.transform.position = new Vector3(817.6f, -0.57f, 0);
                else if (saveLibrary == 5.5)
                    player1.transform.position = new Vector3(1088.5f, -0.57f, 0);
                else if (saveLibrary == 6.5)
                    player1.transform.position = new Vector3(1486, -0.57f, 0);
                else if (saveLibrary == 7.5)
                    player1.transform.position = new Vector3(1760, -0.57f, 0);
                else if (saveLibrary == 8.5)
                    player1.transform.position = new Vector3(2047, -0.57f, 0);
                else if (saveLibrary == 9.5)
                    player1.transform.position = new Vector3(2349f, 60.4f, 0);
                if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[nextBgm].clip)
                {
                    SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[nextBgm].clip;
                    SoundManager.instance.bgmPlayer.Play();
                }
                LoadManager2.instance.currentLibrary = saveLibrary;
                SaveManager.instance.Save(saveLibrary);
                MapManager.instance.mapUpdate();
                EffectManager.instance.effectSounds[11].source.clip = EffectManager.instance.effectSounds[15].source.clip;
                if (saveLibrary == 6.5)
                    GameObject.Find("SwitchManager").GetComponent<SwitchManager>().switches[16].bools = true;
                if (saveLibrary >= 6.5)
                    EffectManager.instance.effectSounds[11].source.clip = EffectManager.instance.effectSounds[16].source.clip;
            }
        }
    }
}
