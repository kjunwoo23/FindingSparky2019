using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class JumpPad : MonoBehaviour
{
    // Start is called before the first frame update

    public bool right = true;
    public float jumpPower;
    public Rigidbody2D player1;
    bool ready = false;
    public CinemachineVirtualCamera cm;

    void OnTriggerStay2D(Collider2D other)
    {
        //if (!enabled) return;
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!GameObject.Find("Player").GetComponent<dqwd>().isGround && GameObject.Find("Player").GetComponent<dqwd>().enabled)
                { ready = true;
                    player1.velocity = Vector2.up * jumpPower;
                    if (right)
                        player1.velocity += new Vector2(30, 0);
                    else if (!right)
                        player1.velocity += new Vector2(-30, 0);
                    EffectManager.instance.effectSounds[9].source.Play();
                }
            }
        }
    }
    private void Update()
    {
        if (ready)
        {
            if (cm.m_Lens.OrthographicSize >= 14)
            {
                ready = false;
                return;
            }
            cm.m_Lens.OrthographicSize += Time.deltaTime * 30;
            GameObject.Find("View").GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1) * (cm.m_Lens.OrthographicSize + 13) / 36;
        }
    }
}