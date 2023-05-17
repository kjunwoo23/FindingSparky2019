using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

[System.Serializable]
public class Switch
{
    public string switchName;
    public bool bools;
}
public class SwitchManager : MonoBehaviour
{
    [Header("스위치 등록")]
    [SerializeField]
    public Switch[] switches;
    public CinemachineVirtualCamera cm;
    public dqwd dqwd;
    public RawImage truth1;
    public RawImage truth2;
    public GameObject[] fred;
    public RawImage fade;
    Color alpha;
    float endTime = 0;
    bool dog1, gun, knife;//, blood;
    public RawImage[] ending;
    public GameObject stat;


    private void Start()
    {
        dog1 = true; gun = true; knife = true; gun = true; //blood = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (switches[1].bools == false)
        {
            GameObject.Find("1tree2 (2)").GetComponent<PolygonCollider2D>().enabled = false;
            switches[1].bools = true;
        }
        if (switches[2].bools == true)
        {
            GameObject.Find("1알렉스").GetComponent<Line>().enabled = true;
            switches[2].bools = false;
        }
        if (switches[3].bools == true)
        {
            GameObject.Find("1도서관1문").GetComponent<Line>().enabled = false;
            GameObject.Find("1도서관으로").GetComponent<ToLibrary>().enabled = true;
            switches[3].bools = false;
        }
        if (switches[4].bools == true)
        {
            EffectManager.instance.effectSounds[5].source.Play();
            cm.m_Lens.OrthographicSize = 3;
            SpawnManager.instance.day = 1;
            GameObject.Find("2벽").GetComponent<Line>().enabled = false;
            switches[4].bools = false;
        }
        if (switches[5].bools == true)
        {
            GameObject.Find("두번째회상").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
            dqwd.knife = true;
            SpawnManager.instance.kill = 99;
            switches[5].bools = false;
        }
        if (switches[6].bools == true)
        {
            SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[5].clip;
            SoundManager.instance.bgmPlayer.Play();
            cm.m_Lens.OrthographicSize = 10;
            SpawnManager.instance.day = 2;
            GameObject.Find("mob").GetComponent<Line>().enabled = false;
            GameObject.Find("mob").GetComponent<SpriteRenderer>().enabled = false;
            switches[6].bools = false;
        }
        if (switches[7].bools == true)
        {
            if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[7].clip)
            {
                SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[7].clip;
                SoundManager.instance.bgmPlayer.Play();
            }
            GameObject.Find("3울타리").GetComponent<BoxCollider2D>().enabled = true;
            SpawnManager.instance.kill = 99;
            switches[7].bools = false;
        }
        if (switches[8].bools == true)
        {
            if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[7].clip)
            {
                SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[7].clip;
                SoundManager.instance.bgmPlayer.Play();
            }
            GameObject.Find("3잔디").GetComponent<Line>().enabled = false;
            GameObject.Find("3울타리").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 2.5f;
            switches[8].bools = false;
        }
        if (switches[9].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("4tree2").GetComponent<Line>().enabled = false;
            GameObject.Find("4울타리").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 3.0f;
            switches[9].bools = false;
        }
        if (switches[10].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("4tree1").GetComponent<Line>().enabled = false;
            GameObject.Find("4울타리2").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 3.5f;
            switches[10].bools = false;
        }
        if (switches[11].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("5잔디").GetComponent<Line>().enabled = false;
            GameObject.Find("5울타리").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 4.0f;
            switches[11].bools = false;
        }
        if (switches[12].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("5tree1").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 4.5f;
            switches[12].bools = false;
        }
        if (switches[13].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("6잔디2").GetComponent<Line>().enabled = false;
            GameObject.Find("6잔디3").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 5.0f;
            switches[13].bools = false;
        }
        if (switches[14].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("6울타리").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 5.5f;
            switches[14].bools = false;
        }
        if (switches[15].bools == true)
        {
            GameObject.Find("Doll").GetComponent<RawImage>().texture = truth1.texture;
            GameObject.Find("MenuPhoto").GetComponent<RawImage>().texture = truth2.texture;
            switches[15].bools = false;
        }
        if (switches[16].bools == true)
        {
            GameObject.Find("Doll").GetComponent<RawImage>().texture = truth1.texture;
            GameObject.Find("MenuPhoto").GetComponent<RawImage>().texture = truth2.texture;
            GameObject.Find("Quad (2)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
            dqwd.animator.runtimeAnimatorController = dqwd.animator2.runtimeAnimatorController;
            dqwd.hard = true;
            GameObject.Find("Quad").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
            GameObject.Find("Quad (3)").GetComponent<MeshRenderer>().materials = GameObject.Find("Quad (4)").GetComponent<MeshRenderer>().materials;
            switches[16].bools = false;
        }
        if (switches[17].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("7building1").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 6.0f;
            switches[17].bools = false;
        }
        if (switches[18].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("7building2").GetComponent<Line>().enabled = false;
            GameObject.Find("7쓰레기통").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 6.3f;
            switches[18].bools = false;
        }
        if (switches[19].bools == true)
        {
            SpawnManager.instance.kill = 99;
            GameObject.Find("7가로등 (1)").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 6.6f;
            switches[19].bools = false;
        }
        if (switches[20].bools == true)
        {
            SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[12].clip;
            SoundManager.instance.bgmPlayer.Play();
            switches[20].bools = false;
        }
        if (switches[21].bools == true)
        {
            EffectManager.instance.effectSounds[5].source.Play();
            switches[21].bools = false;
        }
        if (switches[22].bools == true)
        {
            SpawnManager.instance.kill = 99;
            EffectManager.instance.effectSounds[5].source.Play();
            GameObject.Find("8안전봉").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 7.0f;
            switches[22].bools = false;
        }
        if (switches[23].bools == true)
        {
            SpawnManager.instance.kill = 99;
            EffectManager.instance.effectSounds[5].source.Play();
            GameObject.Find("8쓰레기통").GetComponent<Line>().enabled = false;
            SpawnManager.instance.day = 7.5f;
            switches[23].bools = false;
        }
        if (switches[24].bools == true)
        {
            EffectManager.instance.effectSounds[17].source.Play();
            switches[24].bools = false;
        }
        if (switches[25].bools == true)
        {
            fred[0].SetActive(false);
            fred[1].SetActive(true);
            EffectManager.instance.effectSounds[17].source.Play();
            dqwd.animator.SetBool("gun", true);
            switches[25].bools = false;
        }
        if (switches[26].bools == true)
        {
            fred[1].SetActive(false);
            fred[2].SetActive(true);
            switches[26].bools = false;
        }
        if (switches[27].bools == true)
        {
            fred[2].SetActive(false);
            fred[3].SetActive(true);
            switches[27].bools = false;
        }
        if (switches[28].bools == true)
        {
            fred[3].SetActive(false);
            fred[4].SetActive(true);
            switches[28].bools = false;
        }
        if (switches[29].bools == true)
        {
            fred[4].SetActive(false);
            fred[5].SetActive(true);
            switches[29].bools = false;
        }
        if (switches[30].bools == true)
        {
            fred[5].SetActive(false);
            fred[6].SetActive(true);
            switches[30].bools = false;
        }
        if (switches[31].bools == true)
        {
            fred[6].SetActive(false);
            fred[7].SetActive(true);
            EffectManager.instance.effectSounds[17].source.Play();
            switches[31].bools = false;
        }
        if (switches[32].bools == true)
        {
            GameObject.Find("Player").GetComponent<Transform>().position += new Vector3(0, 60, 0);
            LoadManager2.instance.currentLibrary = 9.5f;
            SaveManager.instance.Save(9.5f);
            MapManager.instance.mapUpdate();
            fred[7].SetActive(false);
            fred[8].SetActive(true);
            EffectManager.instance.effectSounds[18].source.Play();
            dqwd.animator.SetBool("gun", false);
            cm.m_Lens.OrthographicSize = 1;
            switches[32].bools = false;
        }
        if (switches[33].bools == true)
        {
            //dqwd.playerSpeed = 15;
            switches[33].bools = false;
        }
        if (switches[34].bools == true)
        {
            GameObject.Find("8Nlibrary").GetComponent<Line>().enabled = false;
            switches[34].bools = false;
        }
        if (switches[35].bools == true)
        {
            GameObject.Find("8-1소화전 (2)").GetComponent<PolygonCollider2D>().enabled = false;
            GameObject.Find("8-1building2").GetComponent<Line>().enabled = false;
            switches[35].bools = false;
        }
        if (switches[36].bools == true)
        {
            SaveManager.instance.Save(10);
            LoadManager2.instance.currentLibrary = 10;
            MapManager.instance.mapUpdate();
            switches[36].bools = false;
        }
        if (switches[37].bools == true)
        {
            EffectManager.instance.effectSounds[11].source.clip = EffectManager.instance.effectSounds[15].source.clip;
            switches[37].bools = false;
        }
        if (switches[38].bools == true)
        {
            stat.SetActive(false);
            endTime += Time.deltaTime;
            dqwd.GetComponent<SpriteRenderer>().enabled = false;
            dqwd.enabled = false;
            EffectManager.instance.effectSounds[11].source.Stop();
            if (endTime >= 2.5f && dog1)
            {
                EffectManager.instance.effectSounds[19].source.Play();
                dog1 = false;
            }
            if (endTime >= 5.5f && gun)
            {
                GameObject.Find("Bgs").GetComponent<AudioSource>().Stop();
                EffectManager.instance.effectSounds[19].source.Stop();
                EffectManager.instance.effectSounds[18].source.Play();
                EffectManager.instance.effectSounds[20].source.Play();
                SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[9].clip;
                SoundManager.instance.bgmPlayer.Play();
                gun = false;
            }
            if (endTime >= 10f && knife)
            {
                EffectManager.instance.effectSounds[22].source.Play();
                knife = false;
            }
            /*
            if (endTime >= 15f && blood)
            {
                EffectManager.instance.effectSounds[21].source.Play();
                blood = false;
            }*/

            if (endTime >= 15f)
            {
                ending[0].enabled = true;
            }
            if (endTime >= 18f)
            {
                ending[1].enabled = true;
            }
            if (endTime >= 21f)
            {
                ending[2].enabled = true;
            }
            if (endTime >= 24f)
            {
                ending[3].enabled = true;
            }
            if (endTime >= 27f)
            {
                ending[4].enabled = true;
            }
            if (endTime >= 30f)
            {
                if (SoundManager.instance.bgmPlayer.clip != SoundManager.instance.bgmSounds[0].clip)
                {
                    SoundManager.instance.bgmPlayer.clip = SoundManager.instance.bgmSounds[0].clip;
                    SoundManager.instance.bgmPlayer.Play();
                }
                alpha.a = (endTime - 30) / 60;
                fade.color = alpha;
            }
            if (endTime >= 35)
                GameObject.Find("경찰차1 (1)").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 38)
                GameObject.Find("경찰차1 (2)").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 43)
                GameObject.Find("경찰1").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 48)
                GameObject.Find("도널드 (1)").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 53)
                GameObject.Find("경찰2").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 55)
                GameObject.Find("기자 (1)").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 60)
                GameObject.Find("경찰3").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 62)
                GameObject.Find("경찰차1").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 63)
                GameObject.Find("경찰차1 (3)").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 67)
                GameObject.Find("경찰차1 (4)").GetComponent<SpriteRenderer>().enabled = true;
            if (endTime >= 90f && ending[0].enabled == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    ending[i].enabled = false;
                }
            }
            if (endTime >= 90f)
            {
                ending[5].enabled = true;
                switches[38].bools = false;
            }
        }
    }
}
