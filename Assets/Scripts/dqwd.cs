using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


[System.Serializable]
public class Sounds
{
    public string soundName;
    public AudioClip clip;
    public AudioSource source;
}

public class dqwd : MonoBehaviour
{
    public bool hard;
    public float jumpPower;
    public float playerSize;
    public float playerSpeed;
    public int hp;
    public bool memory = false;
    public Transform pos;
    public Transform pos2;
    public float checkRadius;
    public LayerMask islayer;
    public bool isGround;
    public bool isWalk;
    public Animator animator, animator2;
    public Rigidbody2D myRigid;
    public AudioSource bgs;
    Vector2 MousePosition;
    public Camera cam;/*
    [SerializeField]
    int SoundsLen;
    [Header("사운드 등록")]
    [SerializeField] Sounds[] effectSounds;*/
    public CinemachineVirtualCamera cm;
    public RectTransform view;
    public RawImage viewFade;
    Color alpha;
    //CinemachineVirtualCamera
    float zoomcount = 0;
    void Start()
    {
        //animator.runtimeAnimatorController = animator2.runtimeAnimatorController;
        bgs.volume = 0;
    }
    public Animator menuAnimator;
    public float curTime0, curTime1, curTime2;
    public float coolTime0 = 1.0f, coolTime1 = 1.0f, coolTime2 = 1.0f;
    public Transform atk0pos, atk1pos, atk2pos;
    public Vector2 atk0size, atk1size, atk2size;
    public GameObject UIHeart1;
    public GameObject UIHeart2;
    public GameObject UIHeart3;
    public GameObject RestartButton;
    public float dmgcool = 1.5f;
    public bool knife = false;
    public SpriteRenderer spriteRenderer;
    public bool touch = false;
    public GameObject knifeIcon;
    public GameObject knifeUI;
    float resetcool = 0.5f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!this.enabled)
            return;
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Damage")
        {
            touch = true;/*
            dmgcool = 1f;
            dmgcool -= Time.deltaTime;*/
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (!this.enabled)
            return;
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Damage")
        {
            touch = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (!this.enabled)
            return;
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Damage")
        {
            touch = false;
        }
    }
    void Update()
    {
        if (touch)
        {
            resetcool = 0.5f;
            if (hp > 0)
                dmgcool -= Time.deltaTime;
            if (dmgcool <= 0)
            {
                hp--;
                EffectManager.instance.effectSounds[12].source.Play();
                dmgcool = 1.5f;
            }
        }
        else
        {
            resetcool -= Time.deltaTime;
            if (dmgcool < 1.5f && resetcool <= 0)
            {
                dmgcool += Time.deltaTime;
            }

        }
        //knife = true;
        if (dmgcool < 0)
            dmgcool = 0;
        if (hp == 3)
        {
            UIHeart1.SetActive(true);
            UIHeart2.SetActive(true);
            UIHeart3.SetActive(true);
        }
        else if (hp == 2)
        {
            //UIHeart1.SetActive(true);
            //UIHeart2.SetActive(true);
            UIHeart3.SetActive(false);

        }
        else if (hp == 1)
        {
            //UIHeart1.SetActive(true);
            UIHeart2.SetActive(false);
            //UIHeart3.SetActive(false);

        }

        else if (hp == 0)
        {
            UIHeart1.SetActive(false);
            //UIHeart2.SetActive(false);
            //UIHeart3.SetActive(false);
            RestartButton.SetActive(true);
            this.GetComponent<dqwd>().enabled = false;
            animator.SetBool("death", true);
            EffectManager.instance.effectSounds[11].source.clip = null;
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().ShowMessage(3, "스파키..");
            GameObject.Find("DialogueManager").GetComponent<DialogueManager>().enabled = false;
        }
        isWalk = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A));
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer) || Physics2D.OverlapCircle(pos2.position, checkRadius, islayer);

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && isGround && !EffectManager.instance.effectSounds[11].source.isPlaying)
            EffectManager.instance.effectSounds[11].source.Play();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || !isGround)
            EffectManager.instance.effectSounds[11].source.Pause();
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walking", true);
            this.transform.position += new Vector3(1, 0, 0) * playerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walking", true);
            this.transform.position += new Vector3(-1, 0, 0) * playerSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("walking", false);

        }

        if (isGround == true && Input.GetKey(KeyCode.Space))
        {
            myRigid.velocity = Vector2.up * jumpPower;
        }
        animator.SetBool("grounded", isGround);

        if (knife)
        {
            knifeIcon.SetActive(true);
            knifeUI.SetActive(true);
            bgs.pitch = 14 / ((cm.m_Lens.OrthographicSize) + 2);
            bgs.volume = (17 - cm.m_Lens.OrthographicSize) / 12;
            view.localScale = new Vector3(1, 1, 1) * (cm.m_Lens.OrthographicSize + 19) / 44;
            alpha.a = (25 - cm.m_Lens.OrthographicSize) / 44;
            viewFade.color = alpha;
        }
        if (memory)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            if (hard)
                cm.transform.rotation = Quaternion.Euler(0, 0, (14 - cm.m_Lens.OrthographicSize) * 3);
            if (zoomcount <= 0)
            {
                    if (cm.m_Lens.OrthographicSize < 14)
                {
                    cm.m_Lens.OrthographicSize += Time.deltaTime * 3;
                }
            }
            else
            {
                zoomcount -= Time.deltaTime;
            }
            spriteRenderer.enabled = true;
            if (curTime0 <= 0 && curTime1 > 0 && knife)
            {
                if (Input.GetMouseButton(0) && !menuAnimator.GetBool("Appear"))
                {
                    if (cm.m_Lens.OrthographicSize > 8)
                        cm.m_Lens.OrthographicSize -= 3;
                    else if (cm.m_Lens.OrthographicSize > 5)
                        cm.m_Lens.OrthographicSize = 3;
                    zoomcount = 0.5f;
                    EffectManager.instance.effectSounds[6].source.Play();
                    animator.SetTrigger("atk0");
                    curTime0 = coolTime0;
                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(atk0pos.position, atk0size, 0);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider.tag == "Enemy" || collider.tag == "Fred")
                        {
                            collider.GetComponent<Animator>().SetTrigger("dmg2");
                            collider.GetComponent<Enemy>().hp -= 3;
                        }
                    }
                }
            }
            else
            {
                curTime0 -= Time.deltaTime;
            }
            if (curTime1 <= 0)
            {
                if (Input.GetMouseButton(0) && !menuAnimator.GetBool("Appear"))
                {
                    if (cm.m_Lens.OrthographicSize > 8)
                        cm.m_Lens.OrthographicSize -= 3;
                    else if (cm.m_Lens.OrthographicSize > 5)
                        cm.m_Lens.OrthographicSize = 3;
                    zoomcount = 0.5f;                    
                    EffectManager.instance.effectSounds[7].source.Play();
                    animator.SetTrigger("atk1");
                    curTime1 = coolTime1;
                    curTime0 = coolTime0;
                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(atk1pos.position, atk1size, 0);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider.tag == "Enemy" || collider.tag == "Object" || collider.tag == "Fred")
                        {
                            collider.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50);
                            if (collider.tag == "Enemy" || collider.tag == "Fred")
                            {
                                collider.GetComponent<Animator>().SetTrigger("dmg1");
                                collider.GetComponent<Enemy>().hp -= 1;
                                collider.GetComponent<Enemy>().attacked = true;
                            }
                        }
                    }
                }
            }
            else
            {
                curTime1 -= Time.deltaTime;
            }
            if (curTime2 <= 0)
            {
                if (Input.GetMouseButton(1) && !menuAnimator.GetBool("Appear"))
                {
                    if (cm.m_Lens.OrthographicSize > 8)
                        cm.m_Lens.OrthographicSize -= 3;
                    else if (cm.m_Lens.OrthographicSize > 5)
                        cm.m_Lens.OrthographicSize = 3;
                    zoomcount = 0.5f;
                    animator.SetTrigger("atk2");
                    EffectManager.instance.effectSounds[8].source.Play();
                    curTime2 = coolTime2;
                    Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(atk2pos.position, atk2size, 0);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider.tag == "Enemy" || collider.tag == "Object" || collider.tag == "Fred")
                        {
                            if (collider.tag == "Enemy" || collider.tag == "Fred")
                            {
                                collider.GetComponent<Animator>().SetTrigger("dmg1");
                                collider.GetComponent<Enemy>().hp -= 1;
                                collider.GetComponent<Enemy>().attacked = true;
                            }
                            if (collider.GetComponent<Transform>().position.x > this.transform.position.x + 0.5 * playerSize)
                                collider.GetComponent<Rigidbody2D>().velocity += new Vector2(30, 0);
                            if (collider.GetComponent<Transform>().position.x < this.transform.position.x - 0.5 * playerSize)
                                collider.GetComponent<Rigidbody2D>().velocity += new Vector2(-30, 0);
                        }
                    }
                }
            }
            else
            {
                curTime2 -= Time.deltaTime;
            }
        }
        MousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (MousePosition.x > this.transform.position.x + 0.5 * playerSize)
            this.transform.localScale = new Vector3(1, 1, 1) * playerSize;
        if (MousePosition.x < this.transform.position.x - 0.5 * playerSize)
            this.transform.localScale = new Vector3(-1, 1, 1) * playerSize;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(atk0pos.position, atk0size);
        Gizmos.DrawWireCube(atk1pos.position, atk1size);
        Gizmos.DrawWireCube(atk2pos.position, atk2size);

    }
}