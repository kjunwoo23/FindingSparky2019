using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Animator menuImage;
    public Animator doll;
    public Animator paper;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuImage.GetBool("Appear") == true)
            {
                menuImage.SetBool("Appear", false);
                doll.SetBool("Appear", false);
                paper.SetBool("Appear", false);
            }
            else
            {
                EffectManager.instance.effectSounds[13].source.Play();
                menuImage.SetBool("Appear", true);
                doll.SetBool("Appear", true);
                paper.SetBool("Appear", true);
            }
        }
    }
}
