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
                // ������ �ڽ��� �����̹����� RectTransform�� �����´�.
                RectTransform item = slot.transform.GetChild(0).GetComponent<RectTransform>();

                slot.name = "slot_" + y + "_" + x; // ���� �̸� ����.
                slot.transform.parent = transform; // ������ �θ� ����. (Inventory��ü�� �θ���.)

                // ������ ������ ��ġ �����ϱ�.
                slotRect.localPosition = new Vector3((slotSize * x) + (slotGap * (x + 1)),
                                                   -((slotSize * y) + (slotGap * (y + 1))),
                                                      0);

                // ������ �ڽ��� �����̹����� ������ �����ϱ�.
                slotRect.localScale = Vector3.one;
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize); // ����
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);   // ����.

                // ������ ������ �����ϱ�.
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize - slotSize * 0.3f); // ����.
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize - slotSize * 0.3f);   // ����.

                // ����Ʈ�� ������ �߰�.
                AllSlot.Add(slot);
            }
        }
        EmptySlot = AllSlot.Count;
    }
    // �������� �ֱ����� ��� ������ �˻�.
    public bool AddItem(Item item)
    {
        // ���Կ� �� ����.
        int slotCount = AllSlot.Count;

        // �ֱ����� �������� ���Կ� �����ϴ��� �˻�.
        for (int i = 0; i < slotCount; i++)
        {
            // �� ������ ��ũ��Ʈ�� �����´�.
            Slot slot = AllSlot[i].GetComponent<Slot>();

            // ������ ��������� ���.
            if (!slot.isSlots())
                continue;

            // ���Կ� �����ϴ� �������� Ÿ�԰� �������� �������� Ÿ���� ����.
            // ���Կ� �����ϴ� �������� ��ĥ�� �ִ� �ִ�ġ�� �����ʾ��� ��. (true�� ��)
            if (slot.ItemReturn().type == item.type && slot.ItemMax(item))
            {
                // ���Կ� �������� �ִ´�.
                slot.AddItem(item);
                return true;
            }
        }

        // �� ���Կ� �������� �ֱ����� �˻�.
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = AllSlot[i].GetComponent<Slot>();

            // ������ ������� ������ ���
            if (slot.isSlots())
                continue;

            slot.AddItem(item);
            return true;
        }

        // ���� ���ǿ� �ش�Ǵ� ���� ���� �� �������� ���� ����.
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
