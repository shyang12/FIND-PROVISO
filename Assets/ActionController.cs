using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    GameObject Text;
    [SerializeField]
    private float range; // 습득 가능한 최대 거리.

    private bool pickupActivated = false; // 습득 가능할 시 true


    [SerializeField]
    private LayerMask layerMask; // 아이템 레이어에만 반응하도록 레이어 마스크를 설정

    [SerializeField]
    

    // Start is called before the first frame update
    void Start()
    {
        this.Text = GameObject.Find("ShowText");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(pickupActivated)
            {
                Destroy(gameObject);
            }
            
        }
    }

    void OnMouseEnter()
    {
        pickupActivated = true;
        Text.SetActive(true);
        Text.GetComponent<Text>().text =  "Key 획득 " + "<color=yellow>" + "(클릭)" + "</color>";
    }

     void OnMouseExit()
    {
        pickupActivated = false;
        Text.SetActive(false);
    }
}
