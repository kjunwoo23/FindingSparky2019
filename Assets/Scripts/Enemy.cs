using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int mobType;
    public int hp;
    public float totalTime;
    public float randomTime;
    public float followTime;
    Transform player1;
    public float mobSize;
    public float mobSpeed;
    public Transform pos;
    public Transform pos2;
    public float checkRadius;
    public LayerMask islayer;
    public bool isGround;
    public float time1;
    float deathTime = 2.0f;
    public GameObject enemy;
    float dmgcool;
    bool touch;
    int dir;
    bool follow = false;
    public bool attacked = false;
    public GameObject dmg;
    public BoxCollider2D foot;
    public SpriteRenderer skin;
    Color alpha;

    void Start()
    {
        player1 = GameObject.Find("Player").GetComponent<Transform>();
        time1 = totalTime;
        StartCoroutine("Dir");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Damage")
        {
            touch = true;
            dmgcool = 0.5f;
            dmgcool -= Time.deltaTime;
        }
        if (other.gameObject.tag == "Player" && mobType == 2)
        {
            this.GetComponent<Animator>().SetBool("push", true);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Damage")
        {
            dmgcool = 0.5f;
        }
        if (other.gameObject.tag == "Player" && mobType == 2)
        {
            this.GetComponent<Animator>().SetBool("push", false);
        }
    }
    IEnumerator Dir()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            dir = Random.Range(-1, 2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (touch)
        {
            if (hp > 0)
                dmgcool -= Time.deltaTime;
            if (dmgcool <= 0)
            {
                hp -= 10;
                dmgcool = 0.5f;
            }
        }
        if (hp <= 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
            GetComponent<CapsuleCollider2D>().enabled = false;
            foot.enabled = false;
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                SpawnManager.instance.kill++;
                Destroy(this.gameObject);
            }

        }
        if (attacked)
        {
            time1 = 3;
            attacked = false;
        }
        if (-30 < player1.position.x - this.transform.position.x && player1.position.x - this.transform.position.x < 30)
            if (-5 < player1.position.y - this.transform.position.y && player1.position.y - this.transform.position.y < 5)
                follow = true;
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer) || Physics2D.OverlapCircle(pos2.position, checkRadius, islayer);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (follow)
        {
            if (mobType == 2)
            {
                alpha = skin.color;
                alpha.a = hp / 37.5f + 0.2f;
                skin.color = alpha;
                if (this.transform.position.x > player1.position.x + mobSize)
                {
                    this.transform.localScale = new Vector3(-1, 1, 1) * mobSize;
                    dmg.transform.localScale = new Vector3(-1, 1, 1);
                    this.transform.position += new Vector3(-1, 0, 0) * mobSpeed * Time.deltaTime;
                }
                else if (this.transform.position.x < player1.position.x - mobSize)
                {
                    this.transform.localScale = new Vector3(1, 1, 1) * mobSize;
                    dmg.transform.localScale = new Vector3(1, 1, 1);
                    this.transform.position += new Vector3(1, 0, 0) * mobSpeed * Time.deltaTime;
                }
                if (this.GetComponent<Animator>().GetBool("push") && isGround)
                    player1.GetComponent<Rigidbody2D>().velocity = new Vector3(30, 0, 0);
                return;
            }


            time1 -= Time.deltaTime;

            if (mobType == 0)
                if (time1 >= randomTime)//1.5초 동안 맘대로
                {
                    if (dir != 0)
                    {
                        this.transform.localScale = new Vector3(-dir, 1, 1) * mobSize * 0.45f;
                        dmg.transform.localScale = new Vector3(-dir, 1, 1);
                    }
                    this.transform.position += new Vector3(dir, 0, 0) * mobSpeed * Time.deltaTime;
                }
                else if (time1 >= followTime)//1.5초 동안 따라디니기
                {
                        if (this.transform.position.x > player1.position.x + mobSize)
                        {
                        this.transform.localScale = new Vector3(1, 1, 1) * mobSize * 0.45f;
                        dmg.transform.localScale = new Vector3(1, 1, 1);
                        this.transform.position += new Vector3(-1, 0, 0) * mobSpeed * Time.deltaTime;
                        }
                        else if (this.transform.position.x < player1.position.x - mobSize)
                        {
                        this.transform.localScale = new Vector3(-1, 1, 1) * mobSize * 0.45f;
                        dmg.transform.localScale = new Vector3(-1, 1, 1);
                        this.transform.position += new Vector3(1, 0, 0) * mobSpeed * Time.deltaTime;
                        }
                }
                else if (time1 < 0)
                {
                    time1 = totalTime;
                }

            if (mobType == 1)
            {
                alpha = skin.color;
                alpha.a = hp / 25.0f + 0.2f;
                skin.color = alpha;
                if (time1 >= randomTime)//1.5초 동안 맘대로
                {
                    if (dir != 0)
                    {
                        this.transform.localScale = new Vector3(-dir, 1, 1) * mobSize * 0.45f;
                        dmg.transform.localScale = new Vector3(-dir, 1, 1);
                    }
                    this.transform.position += new Vector3(dir, 0, 0) * mobSpeed * Time.deltaTime;
                }
                else//1.5초 동안 따라디니기
                {
                    if (this.transform.position.x > player1.position.x + mobSize)
                    {
                        this.transform.localScale = new Vector3(1, 1, 1) * mobSize * 0.45f;
                        dmg.transform.localScale = new Vector3(1, 1, 1);
                        this.transform.position += new Vector3(-1, 0, 0) * mobSpeed * Time.deltaTime;
                        if (time1 <= 0) //0초일 때 대쉬
                        {
                            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
                            time1 = totalTime;
                        }
                    }
                    else if (this.transform.position.x < player1.position.x - mobSize)
                    {
                        this.transform.localScale = new Vector3(-1, 1, 1) * mobSize * 0.45f;
                        dmg.transform.localScale = new Vector3(-1, 1, 1);
                        this.transform.position += new Vector3(1, 0, 0) * mobSpeed * Time.deltaTime;
                        if (time1 <= 0) //0초일 때 대쉬
                        {
                            this.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);
                            time1 = totalTime;
                        }
                    }
                }
            }
        }
    }
}
