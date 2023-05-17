using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public SpawnManager spawnManager;
    public Line line;
    public PolygonCollider2D polygonCollider;

    // Update is called once per frame
    void Update()
    {
        if ((spawnManager.kill == spawnManager.maxCount) && line.enabled == false)
            polygonCollider.isTrigger = true;
    }
}
