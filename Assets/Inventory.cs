using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> AllSlot;
    public RectTransform InvenRect;
    public GameObject Slot;

    public float slotSize;
    public float slotGap;
    public float slotCountX;
    public float slotCountY;

    private float InvenWidth;
    private float InvenHeight;
    private float EmptySlot;
    private void Awake()
    {
        InvenWidth = (slotCountX * slotSize) + (slotCountX * slotGap) + slotGap;
        InvenHeight = (slotCountY * slotSize) + (slotCountY * slotGap) + slotGap;

        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, InvenWidth);
        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, InvenHeight);

        for(int y = 0; y < slotCountY; y++)
        {
            for(int x = 0; x < slotCountX; x++)
            {
                GameObject slot = Instantiate(Slot) as GameObject;
                RectTransform slotRect = slot.GetComponent<RectTransform>();
                // 슬롯의 자식인 투명이미지의 RectTransform을 가져온다.
                RectTransform item = slot.transform.GetChild(0).GetComponent<RectTransform>();

                slot.name = "slot_" + y + "_" + x; // 슬롯 이름 설정.
                slot.transform.parent = transform; // 슬롯의 부모를 설정. (Inventory객체가 부모임.)

                // 슬롯이 생성될 위치 설정하기.
                slotRect.localPosition = new Vector3((slotSize * x) + (slotGap * (x + 1)),
                                                   -((slotSize * y) + (slotGap * (y + 1))),
                                                      0);

                // 슬롯의 자식인 투명이미지의 사이즈 설정하기.
                slotRect.localScale = Vector3.one;
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize); // 가로
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);   // 세로.

                // 슬롯의 사이즈 설정하기.
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize - slotSize * 0.3f); // 가로.
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize - slotSize * 0.3f);   // 세로.

                // 리스트에 슬롯을 추가.
                AllSlot.Add(slot);
            }
        }
        EmptySlot = AllSlot.Count;
    }
    // 아이템을 넣기위해 모든 슬롯을 검사.
    public bool AddItem(Item item)
    {
        // 슬롯에 총 개수.
        int slotCount = AllSlot.Count;

        // 넣기위한 아이템이 슬롯에 존재하는지 검사.
        for (int i = 0; i < slotCount; i++)
        {
            // 그 슬롯의 스크립트를 가져온다.
            Slot slot = AllSlot[i].GetComponent<Slot>();

            // 슬롯이 비어있으면 통과.
            if (!slot.isSlots())
                continue;

            // 슬롯에 존재하는 아이템의 타입과 넣을려는 아이템의 타입이 같고.
            // 슬롯에 존재하는 아이템의 겹칠수 있는 최대치가 넘지않았을 때. (true일 때)
            if (slot.ItemReturn().type == item.type && slot.ItemMax(item))
            {
                // 슬롯에 아이템을 넣는다.
                slot.AddItem(item);
                return true;
            }
        }

        // 빈 슬롯에 아이템을 넣기위한 검사.
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = AllSlot[i].GetComponent<Slot>();

            // 슬롯이 비어있지 않으면 통과
            if (slot.isSlots())
                continue;

            slot.AddItem(item);
            return true;
        }

        // 위에 조건에 해당되는 것이 없을 때 아이템을 먹지 못함.
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
