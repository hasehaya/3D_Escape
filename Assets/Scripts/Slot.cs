using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot :MonoBehaviour
{
    Item item;
    Image image;
    Button button;
    //選択されていないときのカバー画像
    [SerializeField] Image hideImage;
    public bool isSelected = false;
    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        UpdateSlot();
        button.onClick.AddListener(OnClickSlot);
    }
    public bool IsItemExist()
    {
        return item != null;
    }
    public Item GetItem()
    {
        return item;
    }
    public void SetItem(Item _item)
    {
        item = _item;
        UpdateSlot();
    }
    public void UpdateSlot()
    {
        if (IsItemExist())
        {
            ShowSlot();
        }
        else
        {
            HideSlot();
        }
    }
    void ShowSlot()
    {
        image.enabled = true;
        hideImage.enabled = true;
        button.enabled = true;
        image.sprite = item.sprite;
    }
    public void HideSlot()
    {
        image.enabled = false;
        hideImage.enabled = false;
        button.enabled = false;
    }
    public void OnSelectedSlot()
    {
        isSelected = true;
        hideImage.enabled = false;
    }
    public void NotSelectedSlot()
    {
        isSelected = false;
        if (IsItemExist())
        {
            hideImage.enabled = true;
        }
        else
        {
            hideImage.enabled = false;
        }
    }

    void OnClickSlot()
    {
        int slotNum;
        string parentName = transform.parent.name;
        string numString = Regex.Match(parentName, @"\d+$").Value;
        int.TryParse(numString, out slotNum);
        ItemBox.instance.OnClickSlot(slotNum);
    }
}
