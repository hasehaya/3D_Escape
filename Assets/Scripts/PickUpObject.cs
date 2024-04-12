using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpObject :MonoBehaviour
{
    public Item.Type type;

    private void Start()
    {
        var eventTrigger = gameObject.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickObj());
        eventTrigger.triggers.Add(onClick);

        if (ItemManager.Instance.GetItemStatus(type) != Item.Status.NotObtain)
        {
            gameObject.SetActive(false);
        }
    }
    public void OnClickObj()
    {
        SE.Play("pon");
        ItemBox.instance.SetSlot(type);
        gameObject.SetActive(false);
        DataManager.Instance.Save();
    }
}
