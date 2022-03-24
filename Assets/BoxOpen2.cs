using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpen2 : MonoBehaviour
{
    GameObject player;
    GameObject OpenS;


    public bool isPlayerEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerEnter = false;
    }
    void Start()
    {
        this.OpenS = GameObject.Find("BoxOpen");
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerEnter && Input.GetMouseButtonDown(0))
        {
            transform.localPosition = new Vector3(0.02191086f, 0.63f, -0.2f);
            transform.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
            this.OpenS.GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}