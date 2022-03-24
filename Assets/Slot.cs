using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    GameObject Scroll1;
    GameObject Problem1;
    GameObject Problem2;
    GameObject Problem3;
    GameObject Problem4;
    GameObject Problem5;

    bool activeScroll = false;
    GameObject LockS;
    // Start is called before the first frame update
    public Stack<Item> slot;       // ������ �������� �����.
    public Sprite DefaultImg; // ���Կ� �ִ� �������� �� ����� ��� �ƹ��͵� ���� �̹����� �־��� �ʿ䰡 �ִ�.

    public DoorOpen door;

    private Image ItemImg;
    private bool isSlot;   // ���� ������ ����ִ���?
    public static bool isDoor;
    public static bool isLock;

    public Item ItemReturn() { return slot.Peek(); } // ���Կ� �����ϴ� �������� ���� ��ȯ.
    public bool ItemMax(Item item) { return ItemReturn().MaxCount > slot.Count; } // ��ĥ�� �ִ� �Ѱ�ġ�� ������.   
    public bool isSlots() { return isSlot; } // ������ ���� ����ִ���? �� ���� �÷��� ��ȯ.
    public void SetSlots(bool isSlot) { this.isSlot = isSlot; }

    void Start()
    {
        this.LockS = GameObject.Find("LockOpen");
        this.Scroll1 = GameObject.Find("Scroll1");
        this.Problem1 = GameObject.Find("Problem1");
        this.Problem2 = GameObject.Find("Problem2");
        this.Problem3 = GameObject.Find("Problem3");
        this.Problem4 = GameObject.Find("Problem4");
        this.Problem5 = GameObject.Find("Problem5");
        Scroll1.GetComponent<Image>().enabled = activeScroll;
        Problem1.GetComponent<Image>().enabled = activeScroll;
        Problem2.GetComponent<Image>().enabled = activeScroll;
        Problem3.GetComponent<Image>().enabled = activeScroll;
        Problem4.GetComponent<Image>().enabled = activeScroll;
        Problem5.GetComponent<Image>().enabled = activeScroll;

        door = FindObjectOfType<DoorOpen>();

        // ���� �޸� �Ҵ�.
        slot = new Stack<Item>();

        // �� ó���� ������ ����ִ�.
        isSlot = false;
        isDoor = false;
        isLock = false;

        // �ؽ�Ʈ ������Ʈ�� RectTransform�� �����´�.
        // �ؽ�Ʈ ��ü�� �θ� ��ü�� x������ �����´�.
        // ��Ʈ�� ũ�⸦ �θ� ��ü�� x���� / 2 ��ŭ���� �������ش�.
        ItemImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void AddItem(Item item)
    {
        // ���ÿ� ������ �߰�.
        slot.Push(item);
        UpdateInfo(true, item.DefaultImg);
    }

    // ������ ���.
    public void ItemUse()
    {
        // ������ ��������� �Լ��� ����.
        if (!isSlot)
            return;

        // ���Կ� �������� 1���� ���.
        // �������� 1���� �� ����ϰ� �Ǹ� 0���� �ȴ�.
        if (slot.Count == 1)
        {
            // Ȥ�� �� ������ �����ϱ� ���� slot����Ʈ�� Clear���ش�
            slot.Clear();
            // ������ ������� ���� ������ ������ ǥ���ϴ� �ؽ�Ʈ�� �޶������Ƿ� ������Ʈ �����ش�.
            UpdateInfo(false, DefaultImg);
            return;
        }
        Debug.Log(ItemReturn().type);
        slot.Pop();
       
        UpdateInfo(isSlot, ItemImg.sprite);
        
    }

    // ���Կ� ���� ���� ���� ������Ʈ.
    public void UpdateInfo(bool isSlot, Sprite sprite)
    {
        SetSlots(isSlot);                                          // ������ ����ִٸ� false �ƴϸ� true ����.
        ItemImg.sprite = sprite;                                   // ���Ծȿ� ����ִ� �������� �̹����� ����.
                                                                   // �κ��丮�� ���������� �������Ƿ� ����.
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(isSlot == true)
            {             
                if(ItemReturn().type == Item.TYPE.KEY && DoorOpen.isLock)
                {
                    Debug.Log("KEY�� ����߽��ϴ�.");
                    ItemUse();
                    isLock = true;
                    this.LockS.GetComponent<AudioSource>().Play();
                }
                else if(ItemReturn().type == Item.TYPE.PROVISO)
                {
                    activeScroll = !activeScroll;
                    Scroll1.GetComponent<Image>().enabled = activeScroll;
                    Problem1.GetComponent<Image>().enabled = activeScroll;
                }
                else if (ItemReturn().type == Item.TYPE.PROVISO2)
                {
                    activeScroll = !activeScroll;
                    Scroll1.GetComponent<Image>().enabled = activeScroll;
                    Problem2.GetComponent<Image>().enabled = activeScroll;
                }
                else if (ItemReturn().type == Item.TYPE.PROVISO3)
                {
                    activeScroll = !activeScroll;
                    Scroll1.GetComponent<Image>().enabled = activeScroll;
                    Problem3.GetComponent<Image>().enabled = activeScroll;
                }
                else if (ItemReturn().type == Item.TYPE.PROVISO4)
                {
                    activeScroll = !activeScroll;
                    Scroll1.GetComponent<Image>().enabled = activeScroll;
                    Problem4.GetComponent<Image>().enabled = activeScroll;
                }
                else if(ItemReturn().type == Item.TYPE.PROVISO5)
                {
                    activeScroll = !activeScroll;
                    Scroll1.GetComponent<Image>().enabled = activeScroll;
                    Problem5.GetComponent<Image>().enabled = activeScroll;
                }

            }    
        }

    }
}
