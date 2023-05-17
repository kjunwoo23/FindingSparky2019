using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar3 : MonoBehaviour
{
    public Slider timebar2;
    public dqwd Dqwd;

    // Start is called before the first frame update
    void Start()
    {
        Dqwd = GameObject.Find("Player").GetComponent<dqwd>();
        timebar2.value = 1 - (float)(Dqwd.curTime2) / (float)(Dqwd.coolTime2);
    }

    // Update is called once per frame
    void Update()
    {
        timebar2.value = 1 - (float)(Dqwd.curTime2) / (float)(Dqwd.coolTime2);
    }
}
