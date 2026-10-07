using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delay", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "POI1(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (other.gameObject.name == "POI2(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (other.gameObject.name == "POI3(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (other.gameObject.name == "POI4(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "POI1(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (other.gameObject.name == "POI2(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (other.gameObject.name == "POI3(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (other.gameObject.name == "POI4(Clone)")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void delay()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
