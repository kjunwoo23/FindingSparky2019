using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DashPad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    bool dash;
    public bool enter = false;
    public float LclickTime, RclickTime;
    public CinemachineVirtualCamera cm;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player" && player1.GetComponent<dqwd>().isGround)
        {
            enter = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player" && player1.GetComponent<dqwd>().isGround)
        {
            if (!enter)
                enter = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!enabled) return;
        if (other.gameObject.tag == "Player" && player1.GetComponent<dqwd>().isGround)
        {
            enter = false;
        }
    }
    private void Update()
    {
        if (enter)
        {
            LclickTime -= Time.deltaTime;
            RclickTime -= Time.deltaTime;
            if (player1.GetComponent<dqwd>().isGround && player1.GetComponent<dqwd>().enabled)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    RclickTime = 0;
                    if (0 < LclickTime && LclickTime < 0.5)
                    {
                        LclickTime = 0;
                        dash = true;
                        enter = false;
                        StartCoroutine(DashL());
                    }
                    if (LclickTime < 0)
                        LclickTime = 0.5f;

                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    LclickTime = 0;
                    if (0 < RclickTime && RclickTime < 0.5)
                    {
                        RclickTime = 0;
                        dash = true;
                        enter = false;
                        StartCoroutine(DashR());
                    }
                    if (RclickTime < 0)
                        RclickTime = 0.5f;
                }
            }
        }
        if (dash)
        {
            if (cm.m_Lens.OrthographicSize >= 14)
            {
                dash = false;
                return;
            }
            cm.m_Lens.OrthographicSize += Time.deltaTime * 30;
            if (player1.GetComponent<dqwd>().hard)
                cm.transform.rotation = Quaternion.Euler(0, 0, (14 - cm.m_Lens.OrthographicSize) * 3);
            GameObject.Find("View").GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1) * (cm.m_Lens.OrthographicSize + 13) / 36;
        }
    }
    IEnumerator DashL()
    {
        player1.GetComponent<Rigidbody2D>().velocity = new Vector2(-40, 0);
        player1.GetComponent<Animator>().SetTrigger("dash");
        player1.GetComponent<CapsuleCollider2D>().enabled = false;
        player1.GetComponent<dqwd>().enabled = false;
        player1.GetComponent<Rigidbody2D>().isKinematic = true;
        EffectManager.instance.effectSounds[10].source.Play();
        yield return new WaitForSeconds(0.5f);
        player1.GetComponent<Rigidbody2D>().isKinematic = false;
        player1.GetComponent<dqwd>().enabled = true;
        player1.GetComponent<dqwd>().touch = false;
        player1.GetComponent<CapsuleCollider2D>().enabled = true;
    }
    IEnumerator DashR()
    {
        player1.GetComponent<Rigidbody2D>().velocity = new Vector2(40, 0);
        player1.GetComponent<Animator>().SetTrigger("dash");
        player1.GetComponent<CapsuleCollider2D>().enabled = false;
        player1.GetComponent<dqwd>().enabled = false;
        player1.GetComponent<Rigidbody2D>().isKinematic = true;
        EffectManager.instance.effectSounds[10].source.Play();
        yield return new WaitForSeconds(0.5f);
        player1.GetComponent<Rigidbody2D>().isKinematic = false;
        player1.GetComponent<dqwd>().enabled = true;
        player1.GetComponent<dqwd>().touch = false;
        player1.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
