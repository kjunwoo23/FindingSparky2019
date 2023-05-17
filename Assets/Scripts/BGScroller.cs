using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BGScroller : MonoBehaviour
{
    private MeshRenderer render;
    private float offset;
    public float BgSpeed;
    public int why;
    public Transform player1;
    public CinemachineVirtualCamera cm;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        player1 = GameObject.Find("Player").GetComponent<Transform>();
        cm = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        BgSpeed = (((cm.m_Lens.OrthographicSize - 19) + 5) * 20 - 5) / 100;
        this.transform.position = new Vector3(player1.transform.position.x, why, 20);
        offset += Time.deltaTime * BgSpeed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
