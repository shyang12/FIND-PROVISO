using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] Text pickUpText;
    bool isPickUp;

    public enum TYPE { KEY, PROVISO, PROVISO2, PROVISO3, PROVISO4, PROVISO5 }

    public TYPE type;
    public Sprite DefaultImg;
    public int MaxCount;

    private Inventory Iv;
    // Start is called before the first frame update
    void Awake()
    {
        Iv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickUp && Input.GetMouseButtonDown(0))
        {
            AddItem();
            pickUpText.gameObject.SetActive(false);
            isPickUp = false;
        }
    }

    void OnMouseEnter()
    {
        pickUpText.gameObject.SetActive(true);
        pickUpText.text = this.gameObject.name + " »πµÊ " + "<color=yellow>" + "(≈¨∏Ø)" + "</color>";
        isPickUp = true;
    }

    void OnMouseExit()
    {
        pickUpText.gameObject.SetActive(false);
        isPickUp = false;
    }

    void AddItem()
    {
        if (!Iv.AddItem(this))
            Debug.Log("æ∆¿Ã≈€¿Ã ∞°µÊ √°Ω¿¥œ¥Ÿ.");
        else
            gameObject.SetActive(false);
    }
}
