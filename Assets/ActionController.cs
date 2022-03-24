using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    GameObject Text;
    [SerializeField]
    private float range; // ���� ������ �ִ� �Ÿ�.

    private bool pickupActivated = false; // ���� ������ �� true


    [SerializeField]
    private LayerMask layerMask; // ������ ���̾�� �����ϵ��� ���̾� ����ũ�� ����

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
        Text.GetComponent<Text>().text =  "Key ȹ�� " + "<color=yellow>" + "(Ŭ��)" + "</color>";
    }

     void OnMouseExit()
    {
        pickupActivated = false;
        Text.SetActive(false);
    }
}
