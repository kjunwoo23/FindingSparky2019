using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public Animator photo;
    public Animator note;
    public Animator map;
    public Animator start;
    public Animator gun;
    public GameObject block;
    public GameObject notice;
    public RawImage text;
    public RawImage newStart;
    public RawImage load;
    public RawImage report;
    public RawImage reportError;
    public RawImage reportOpen;
    public RawImage levelHard;
    public RawImage levelNormal;
    public RawImage levelError;
    public RawImage exit;
    public GameObject hard;
    public GameObject loadOn;
    public Button mapButton;
    public GameObject fade;
    public AudioSource bgm;
    public GameObject loading;
    public RawImage[] noteImages;
    public RawImage shadow;
    public RawImage mapImage;

    public bool hardMode;
    public bool normalClear;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("MaxLibrary") > 6)
            hard.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickElse();
        }

    }

    public void OnClickNotice()
    {
        if (start.GetBool("Appear"))
        {
            loading.SetActive(true);
            bgm.Stop();
            start.SetBool("Appear", false);
            block.SetActive(false);
            notice.SetActive(false);
            PlayerPrefs.SetFloat("StartLibrary", 0);
            SceneManager.LoadScene("SampleScene");
        }
        if (note.GetBool("Appear"))
        {
            if (PlayerPrefs.GetFloat("MaxLibrary") == 10)
            {
                bgm.Stop();
                EffectManager.instance.effectSounds[6].source.Play();
                notice.SetActive(false);
                block.SetActive(true);
                shadow.enabled = false;
                mapImage.enabled = false;
                noteImages[0].enabled = true;
                noteImages[0].texture = noteImages[1].texture;
                return;
            }
            else
            {
                EffectManager.instance.effectSounds[3].source.Play();
                text.texture = reportError.texture;
                return;
            }/*
            note.SetBool("Appear", false);
            block.SetActive(false);
            notice.SetActive(false);*/
        }
        if (photo.GetBool("Appear"))
        {
            PlayerPrefs.SetFloat("MaxLibrary", 0);
            GameObject.Find("LoadManager(Title)").GetComponent<LoadManager>().mapUpdate();
            EffectManager.instance.effectSounds[3].source.Play();
            hard.SetActive(false);
            photo.SetBool("Appear", false);
            block.SetActive(false);
            notice.SetActive(false);
        }
        if (map.GetBool("Appear"))
        {
            mapButton.enabled = false;
            loadOn.SetActive(true);
            notice.SetActive(false);
        }
        if (gun.GetBool("Appear"))
        {
            EffectManager.instance.effectSounds[5].source.Play();
            fade.SetActive(true);
            StartCoroutine("Wait");
        }
    }
    public void OnClickStart()
    {
        start.SetBool("Appear", true);
        EffectManager.instance.effectSounds[0].source.Play();
        text.texture = newStart.texture;
        notice.SetActive(true);
        block.SetActive(true);
    }
    public void OnClickNote()
    {
        note.SetBool("Appear", true);
        EffectManager.instance.effectSounds[2].source.Play();
        text.texture = report.texture;
        notice.SetActive(true);
        block.SetActive(true);
    }
    public void OnClickPhoto()
    {
        photo.SetBool("Appear", true);
        EffectManager.instance.effectSounds[6].source.Play();
        text.texture = levelHard.texture;
        notice.SetActive(true);
        block.SetActive(true);
    }
    public void OnClickMap()
    {
        map.SetBool("Appear", true);
        EffectManager.instance.effectSounds[1].source.Play();
        text.texture = load.texture;
        notice.SetActive(true);
        block.SetActive(true);
    }
    public void OnClickGun()
    {
        gun.SetBool("Appear", true);
        EffectManager.instance.effectSounds[4].source.Play();
        text.texture = exit.texture;
        notice.SetActive(true);
        block.SetActive(true);
    }
    public void OnClickElse()
    {
        if (noteImages[0].enabled == true)
        {
            for (int i = 8; i >= 0; i--)
            {
                if (noteImages[0].texture == noteImages[8].texture)
                {
                    bgm.Play();
                    note.SetBool("Appear", false);
                    noteImages[0].enabled = false;
                    block.SetActive(false);
                    shadow.enabled = true;
                    mapImage.enabled = true;
                    return;
                }
                if (noteImages[0].texture == noteImages[i].texture)
                {
                    EffectManager.instance.effectSounds[1].source.Play();
                    noteImages[0].texture = noteImages[i + 1].texture;
                    return;
                }
            }
        }
        mapButton.enabled = true;
        loadOn.SetActive(false);
        start.SetBool("Appear", false);
        note.SetBool("Appear", false);
        photo.SetBool("Appear", false);
        map.SetBool("Appear", false);
        gun.SetBool("Appear", false);
        notice.SetActive(false);
        block.SetActive(false);
        EffectManager.instance.effectSounds[8].source.Stop();
    }
    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        bgm.Stop();
        yield return new WaitForSeconds(1.5f);
        OnApplicationQuit();
    }
}
