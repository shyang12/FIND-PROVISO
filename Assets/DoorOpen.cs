using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] Text doortext;
    [SerializeField] Text doortext2;
    GameObject DoorOpenS;
    GameObject player;
    GameObject Doortext;
    int ClickCount = 0;

    bool isPlayerEnter;
    public static bool isLock;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        this.Doortext = GameObject.Find("DoorText");
        player = GameObject.FindGameObjectWithTag("Player");
        this.DoorOpenS = GameObject.Find("DoorOpen");
        isPlayerEnter = false;
        isLock = false;
        doortext.gameObject.SetActive(false);
        doortext2.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 0.1f);
        }
        else if (ClickCount == 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
        if(Input.GetMouseButtonDown(0) && isPlayerEnter)
        {
            isLock = true;
            doortext.gameObject.SetActive(false);
            doortext2.gameObject.SetActive(true);
            doortext2.text = "문을 열려면 " + "<color=yellow>" + "(E)" + "</color>";
        }
        
        if(Input.GetKeyDown(KeyCode.E) && Slot.isLock && isPlayerEnter)
        {
            Slot.isLock = false;
            isPlayerEnter = false;
            transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0, -90f));
            this.DoorOpenS.GetComponent<AudioSource>().Play();
            doortext2.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void DoubleClick()
    {
        ClickCount = 0;
    }


    void OnMouseExit()
    {
        doortext.gameObject.SetActive(false);       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isPlayerEnter = true;
            doortext.gameObject.SetActive(true);
            doortext.text = "문을 열려면 인벤토리의 " + "<color=yellow>" + "KEY" + "</color>" + "를 사용하세요";

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
            doortext.gameObject.SetActive(false);
        }
    }
}
