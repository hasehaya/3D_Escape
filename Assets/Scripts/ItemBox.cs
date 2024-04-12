using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.Windows;

public class ItemBox :MonoBehaviour
{
    public static ItemBox instance;
    public Slot selectedSlot = null;
    public Slot zoomedSlot = null;
    [SerializeField] Slot[] slots;
    [SerializeField] Transform zoomCanvasTransform;
    int selectedSlotIndex = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        if (ItemManager.Instance.GetObtainedItems() != null)
        {
            foreach (var type in ItemManager.Instance.GetObtainedItems())
            {
                SetSlot(type);
            }
        }
    }
    public void SetSlot(Item.Type type)
    {
        var item = ItemManager.Instance.Spawn(type);
        ItemManager.Instance.ItemObtained(type);
        foreach (Slot slot in slots)
        {
            if (!slot.IsItemExist())
            {
                slot.SetItem(item);
                break;
            }
        }
    }
    public void SortSlot()
    {
        List<Item> existItem = new List<Item>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsItemExist())
            {
                existItem.Add(slots[i].GetItem());
                slots[i].SetItem(null);
            }
        }
        for (int i = 0; i < existItem.Count; i++)
        {
            slots[i].SetItem(existItem[i]);
        }
    }
    public void DeleteSlot(Slot slot)
    {
        slot.SetItem(null);
        slot.NotSelectedSlot();
    }
    public void DeleteSelectedSlot()
    {
        selectedSlot.SetItem(null);
        selectedSlot.NotSelectedSlot();
        selectedSlot = null;
        selectedSlotIndex = -1;
    }
    public void OnClickSlot(int slotNum)
    {
        SE.Play("pe");
        if (selectedSlotIndex == slotNum)
        {
            if (Zoom.instance.isZoom)
            {
                Zoom.instance.ZoomCancel();
            }
            Zoom.instance.ZoomItem(selectedSlot);
        }
        else
        {
            SelectSlot(slotNum);
        }
    }
    void SelectSlot(int slotNum)
    {
        foreach (Slot slot in slots)
        {
            slot.NotSelectedSlot();
        }
        slots[slotNum].OnSelectedSlot();
        selectedSlot = slots[slotNum];
        selectedSlotIndex = slotNum;
    }
    public bool TryUseItem(Item.Type type)
    {
        if (selectedSlot == null)
        {
            return false;
        }
        if (selectedSlot.GetItem().type == type)
        {
            ItemManager.Instance.ItemUsed(type);
            DeleteSelectedSlot();
            SortSlot();
            DataManager.Instance.Save();
            return true;
        }
        return false;
    }
    public void DeleteItemToSlot(Item.Type type)
    {
        foreach (Slot slot in slots)
        {
            if (slot.GetItem().type == type)
            {
                ItemManager.Instance.ItemUsed(type);
                DeleteSlot(slot);
                SortSlot();
                break;
            }
        }
    }

    public bool HasAnyItem()
    {
        foreach (Slot slot in slots)
        {
            if (slot.IsItemExist())
            {
                return true;
            }
        }
        return false;
    }

    public bool HasItem(Item.Type type)
    {
        foreach (Slot slot in slots)
        {
            if (slot.GetItem() == null)
            {
                return false;
            }
            if (slot.GetItem().type == type)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasSynthesisItem()
    {
        if (HasItem(Item.Type.Sorp) && HasItem(Item.Type.Sponge))
        {
            return true;
        }
        if (HasItem(Item.Type.Note) && HasItem(Item.Type.Pencil))
        {
            return true;
        }
        return false;
    }

    public void HideItemBox()
    {
        gameObject.SetActive(false);
    }
}
