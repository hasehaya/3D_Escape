using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomedItem :MonoBehaviour
{
    [SerializeField] protected Item.Type type;
    protected bool canUseItem;
    protected bool isSynthesisItem = false;
    protected void Start()
    {
        var eventTrigger = gameObject.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickZoomedItem());
        onClick.callback.AddListener(x => ItemBox.instance.SortSlot());
        eventTrigger.triggers.Add(onClick);
    }
    protected virtual void OnClickZoomedItem()
    {
    }
}