using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar4 : MonoBehaviour
{
    public Slider timebar4;
    public dqwd dqwd;

    // Start is called before the first frame update
    void Start()
    {
        dqwd = GameObject.Find("Player").GetComponent<dqwd>();
        timebar4.value = dqwd.dmgcool * 2 / 3;
    }

    // Update is called once per frame
    void Update()
    {
        timebar4.value = dqwd.dmgcool / 3 * 2;
    }
}
