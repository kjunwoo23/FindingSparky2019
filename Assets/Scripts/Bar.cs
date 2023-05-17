using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar : MonoBehaviour
{
    public Slider timebar0;
    public dqwd Dqwd;

    // Start is called before the first frame update
    void Start()
    {
        Dqwd = GameObject.Find("Player").GetComponent<dqwd>();
        timebar0.value = 1 - (float)(Dqwd.curTime0) / (float)(Dqwd.coolTime0);
    }

    // Update is called once per frame
    void Update()
    {
        timebar0.value = 1 - (float)(Dqwd.curTime0) / (float)(Dqwd.coolTime0);
    }
}
