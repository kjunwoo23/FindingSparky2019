using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgs : MonoBehaviour
{
    [Header("사운드 등록")]
    public Sound[] bgsSounds;
    [Header("Bgs 플레이어")]
    public AudioSource bgsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        bgsPlayer.clip = bgsSounds[0].clip;
        bgsPlayer.Play();
    }
}


