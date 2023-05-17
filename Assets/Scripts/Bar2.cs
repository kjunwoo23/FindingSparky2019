using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar2 : MonoBehaviour
{
    public Slider timebar1;
    public dqwd Dqwd;

    // Start is called before the first frame update
    void Start()
    {
        Dqwd = GameObject.Find("Player").GetComponent<dqwd>();
        timebar1.value = 1 - (float)(Dqwd.curTime1) / (float)(Dqwd.coolTime1);
    }

    // Update is called once per frame
    void Update()
    {
        timebar1.value = 1 - (float)(Dqwd.curTime1) / (float)(Dqwd.coolTime1);
    }
}
