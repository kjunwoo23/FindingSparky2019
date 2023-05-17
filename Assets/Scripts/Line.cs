using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        [TextArea(3, 10)]
        public string[] sentences;
        public int[] npc;
        public int[] setTrue = { 0, 0, 0 };
        public int[] setFalse = { 0, 0, 0 };
    }
    public Dialogue dialogue;

    DialogueManager dialogueManager;
    SwitchManager switchManager;
    int i = 0;
    string line;
    int npc;
    int lineStop = 0;
    int lineSize;
    bool stay = false;
    bool skip = false;
    void Start()
    {
        if (!enabled) return;
        npc = dialogue.npc[i];
        line = dialogue.sentences[i];
        lineSize = dialogue.sentences.Length;
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        switchManager = GameObject.Find("SwitchManager").GetComponent<SwitchManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            stay = true;
            i = 0;
            dialogueManager.ShowMessage(0, line);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            if (stay == false)
            {
                stay = true;
                i = 0;
                dialogueManager.ShowMessage(0, line);
            }
        }
    }
    void Update()
    {
        if (!enabled) return;
        if (stay)
        {
            if (Input.GetKeyDown(KeyCode.W) && !(dialogueManager.animator.GetBool("Window")))
            {
                dialogueManager.animator.SetBool("Window", true);
                EffectManager.instance.effectSounds[0].source.Play();
            }
            if (Input.GetKeyDown(KeyCode.S) && (dialogueManager.animator.GetBool("Window")) && skip)
            {
                dialogueManager.animator.SetBool("Window", false);
                EffectManager.instance.effectSounds[4].source.Stop();
            }
            if (lineStop == 0)
            {
                npc = dialogue.npc[i];
                line = dialogue.sentences[i];
                dialogueManager.WriteMessage(npc, line);
                lineStop++;
            }
            if (i == lineSize - 2)
            {
                i++;
                dialogueManager.HideMessage();
                skip = true;
            }
            if (Input.GetKeyDown(KeyCode.W) && i < lineSize - 2)
            {
                dialogueManager.write();
                i++;
                npc = dialogue.npc[i];
                line = dialogue.sentences[i];
                dialogueManager.WriteMessage(npc, line);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            dialogueManager.HideMessage();
            lineStop = 0;

            if (i == lineSize - 1)
                for (int i = 0; i < 3; i++)
                {
                    switchManager.switches[dialogue.setTrue[i]].bools = true;
                    switchManager.switches[dialogue.setFalse[i]].bools = false;
                }
            stay = false;
        }
    }
}
