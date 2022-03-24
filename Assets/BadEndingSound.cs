using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndingSound : MonoBehaviour
{
    GameObject Kung;
    GameObject Chul;
    // Start is called before the first frame update
    void Start()
    {
        Kung = GameObject.Find("Kung");
        Chul = GameObject.Find("Chul");
        StartCoroutine(badending());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator badending()
    {
        Kung.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        Chul.GetComponent<AudioSource>().Play();
    }
}
