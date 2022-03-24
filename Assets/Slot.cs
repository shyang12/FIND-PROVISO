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
    public Stack<Item> slot;       // 슬롯을 스택으로 만든다.
    public Sprite DefaultImg; // 슬롯에 있는 아이템을 다 사용할 경우 아무것도 없는 이미지를 넣어줄 필요가 있다.

    public DoorOpen door;

    private Image ItemImg;
    private bool isSlot;   // 현재 슬롯이 비어있는지?
    public static bool isDoor;
    public static bool isLock;

    public Item ItemReturn() { return slot.Peek(); } // 슬롯에 존재하는 아이템이 뭔지 반환.
    public bool ItemMax(Item item) { return ItemReturn().MaxCount > slot.Count; } // 겹칠수 있는 한계치를 넘으면.   
    public bool isSlots() { return isSlot; } // 슬롯이 현재 비어있는지? 에 대한 플래그 반환.
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

        // 스택 메모리 할당.
        slot = new Stack<Item>();

        // 맨 처음엔 슬롯이 비어있다.
        isSlot = false;
        isDoor = false;
        isLock = false;

        // 텍스트 컴포넌트의 RectTransform을 가져온다.
        // 텍스트 객체의 부모 객체의 x지름을 가져온다.
        // 폰트의 크기를 부모 객체의 x지름 / 2 만큼으로 지정해준다.
        ItemImg = transform.GetChild(0).GetComponent<Image>();
    }

    public void AddItem(Item item)
    {
        // 스택에 아이템 추가.
        slot.Push(item);
        UpdateInfo(true, item.DefaultImg);
    }

    // 아이템 사용.
    public void ItemUse()
    {
        // 슬롯이 비어있으면 함수를 종료.
        if (!isSlot)
            return;

        // 슬롯에 아이템이 1개인 경우.
        // 아이템이 1개일 때 사용하게 되면 0개가 된다.
        if (slot.Count == 1)
        {
            // 혹시 모를 오류를 방지하기 위해 slot리스트를 Clear해준다
            slot.Clear();
            // 아이템 사용으로 인해 아이템 개수를 표현하는 텍스트가 달라졌으므로 업데이트 시켜준다.
            UpdateInfo(false, DefaultImg);
            return;
        }
        Debug.Log(ItemReturn().type);
        slot.Pop();
       
        UpdateInfo(isSlot, ItemImg.sprite);
        
    }

    // 슬롯에 대한 각종 정보 업데이트.
    public void UpdateInfo(bool isSlot, Sprite sprite)
    {
        SetSlots(isSlot);                                          // 슬롯이 비어있다면 false 아니면 true 셋팅.
        ItemImg.sprite = sprite;                                   // 슬롯안에 들어있는 아이템의 이미지를 셋팅.
                                                                   // 인벤토리에 변동사항이 생겼으므로 저장.
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(isSlot == true)
            {             
                if(ItemReturn().type == Item.TYPE.KEY && DoorOpen.isLock)
                {
                    Debug.Log("KEY를 사용했습니다.");
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
