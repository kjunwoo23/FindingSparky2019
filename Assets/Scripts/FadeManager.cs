using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public RawImage panel;
    float time = 0f;
    float F_time = 1f;
    public void Fade()
    {
        time = 0;
        panel.gameObject.SetActive(true);
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Color alpha = panel.color;
        while (alpha.a < 1f) //페이드 아웃
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1f);
        while (alpha.a > 0f) //페이드 인
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        panel.gameObject.SetActive(false);
        yield return null;
    }
}
