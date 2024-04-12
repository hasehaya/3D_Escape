using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ZoomedItemSynthesis :ZoomedItem
{
    Item.Type partnerType;
    Item.Type synthesisedType;
    new void Start()
    {
        base.Start();
        partnerType = ItemCombinationData.instance.GetPartnerType(type);
        synthesisedType = ItemCombinationData.instance.GetSynthesisedType(type);
    }
    protected override void OnClickZoomedItem()
    {
        ItemSynthesis();
    }
    void ItemSynthesis()
    {
        canUseItem = ItemBox.instance.TryUseItem(partnerType);
        if (canUseItem)
        {
            if (type == Item.Type.Sorp || type == Item.Type.Sponge)
            {
                SE.Play("buble");
            }
            else
            {
                SE.Play("pon");
            }
            ItemManager.Instance.ItemUsed(type);
            ItemBox.instance.DeleteItemToSlot(type);
            ItemBox.instance.SetSlot(synthesisedType);
            ItemBox.instance.SortSlot();
            Zoom.instance.ZoomCancel();
            DataManager.Instance.Save();
            Destroy(gameObject);
        }
    }
}