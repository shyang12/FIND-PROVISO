using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign1 : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
