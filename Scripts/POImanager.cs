using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POImanager : MonoBehaviour
{
    public AudioClip POI1Sound;
    public AudioClip POI2Sound;
    public AudioClip POI3Sound;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("POIImageController STARTED");
        
    }

    public void POI1imageAppeared()
    {
        Debug.Log("POI1 FOUND");
        this.GetComponent<AudioSource>().PlayOneShot(POI1Sound);
    }

    public void POI1imageLost()
    {
        Debug.Log("POI1 LOST");
        this.GetComponent<AudioSource>().Stop();
    }

    public void POI2imageAppeared()
    {
        Debug.Log("POI2 FOUND");
        this.GetComponent<AudioSource>().PlayOneShot(POI2Sound);
    }

    public void POI2imageLost()
    {
        Debug.Log("POI2 LOST");
        this.GetComponent<AudioSource>().Stop();
    }

    public void POI3imageAppeared()
    {
        Debug.Log("POI3 FOUND");
        this.GetComponent<AudioSource>().PlayOneShot(POI3Sound);
    }

    public void POI3imageLost()
    {
        Debug.Log("POI3 LOST");
        this.GetComponent<AudioSource>().Stop();
    }
}
