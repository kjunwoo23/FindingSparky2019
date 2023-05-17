using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public RawImage attack0;
    public RawImage attack1;
    public RawImage attack2;
    public dqwd Dqwd;
    Color alpha;

    // Update is called once per frame
    void Update()
    {
        alpha.a = (float)(Dqwd.curTime0) / (float)(Dqwd.coolTime0) * 0.5f;
        if (alpha.a == 0.5f)
            alpha.a = 1;
        attack0.color = alpha;
        alpha.a = (float)(Dqwd.curTime1) / (float)(Dqwd.coolTime1) * 0.5f;
        if (alpha.a == 0.5f)
            alpha.a = 1;
        attack1.color = alpha;
        alpha.a = (float)(Dqwd.curTime2) / (float)(Dqwd.coolTime2) * 0.5f;
        if (alpha.a == 0.5f)
            alpha.a = 1;
        attack2.color = alpha;
    }
}
