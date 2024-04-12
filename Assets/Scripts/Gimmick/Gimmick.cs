using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class Gimmick :MonoBehaviour
{
    protected bool isItemSelected;
    public bool isGimmickClear;
    protected void Start()
    {
        var eventTrigger = gameObject.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickObj());

        eventTrigger.triggers.Add(onClick);
    }
    protected IEnumerator WaitToSet(float time, Item.Type type)
    {
        yield return new WaitForSeconds(time);
        SE.Play("pon");
        ItemBox.instance.SetSlot(type);
        ClearGimmick();
    }
    protected virtual void OnClickObj()
    {
    }
    protected void ClearGimmick()
    {
        isGimmickClear = true;
        GimmickManager.Instance.SaveGimmicksClearStatus();
        DataManager.Instance.Save();
    }
}
