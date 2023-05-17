using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public GameObject load0, load1, load2, load3, load4, load5, load6, load7, load8, load9, load10, load11, load12, load13, load14, load15, load16, load17, load18, load19;
    public LoadManager2 loadManager2;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void mapUpdate()
    {
        if (loadManager2.currentLibrary >= 0) load0.SetActive(true);
        if (loadManager2.currentLibrary >= 1) load1.SetActive(true);
        if (loadManager2.currentLibrary >= 1.5) load2.SetActive(true);
        if (loadManager2.currentLibrary >= 2) load3.SetActive(true);
        if (loadManager2.currentLibrary >= 2.5) load4.SetActive(true);
        if (loadManager2.currentLibrary >= 3) load5.SetActive(true);
        if (loadManager2.currentLibrary >= 3.5) load6.SetActive(true);
        if (loadManager2.currentLibrary >= 4) load7.SetActive(true);
        if (loadManager2.currentLibrary >= 4.5) load8.SetActive(true);
        if (loadManager2.currentLibrary >= 5) load9.SetActive(true);
        if (loadManager2.currentLibrary >= 5.5) load10.SetActive(true);
        if (loadManager2.currentLibrary >= 6) load11.SetActive(true);
        if (loadManager2.currentLibrary >= 6.5) load12.SetActive(true);
        if (loadManager2.currentLibrary >= 7) load13.SetActive(true);
        if (loadManager2.currentLibrary >= 7.5) load14.SetActive(true);
        if (loadManager2.currentLibrary >= 8) load15.SetActive(true);
        if (loadManager2.currentLibrary >= 8.5) load16.SetActive(true);
        if (loadManager2.currentLibrary >= 9) load17.SetActive(true);
        if (loadManager2.currentLibrary >= 9.5) load18.SetActive(true);
        if (loadManager2.currentLibrary >= 10) load19.SetActive(true);
    }
}
