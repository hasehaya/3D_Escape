using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class SetObj :MonoBehaviour
{
    public bool isSet;
    [SerializeField] Item.Type setItem;
    [SerializeField] int passNum;
    [SerializeField] PasswordButton passButton;
    EventTrigger eventTrigger;
    private void Start()
    {
        StartCoroutine(AddEventtrigger());
        CheckSetStatus();
    }
    IEnumerator AddEventtrigger()
    {
        yield return new WaitForSeconds(1);
        eventTrigger = gameObject.GetComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClick());

        eventTrigger.triggers.Add(onClick);
    }
    public void OnClick()
    {
        bool isItemSelected = ItemBox.instance.TryUseItem(setItem);
        if (isItemSelected)
        {
            SetObject();
            passButton.number = passNum;
            passButton.CheckClear();
            eventTrigger.triggers.Clear();
            isSet = true;
            SetObjManager.Instance.SaveSetObjClearStatus();
        }
    }
    public void SetObject()
    {
        var mr = GetComponent<MeshRenderer>();
        mr.enabled = true;
    }
    void CheckSetStatus()
    {
        if (isSet)
        {
            SetObject();
            passButton.number = passNum;
            passButton.InitCheckClear();
        }
    }
}