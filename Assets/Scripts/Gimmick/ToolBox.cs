using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class ToolBox :Gimmick
{
    [SerializeField] OpenObj openObj;
    [SerializeField] GameObject key;
    [SerializeField] GameObject toolBox;
    protected new void Start()
    {
        var eventTrigger1 = GetComponent<EventTrigger>();
        var eventTrigger2 = toolBox.GetComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickObj());
        eventTrigger1.triggers.Add(onClick);
        eventTrigger2.triggers.Add(onClick);

        if (GimmickManager.Instance.GetIsGimmickClear(name))
        {
            openObj.CanOpenObject();
        }
    }
    protected override void OnClickObj()
    {
        isItemSelected = ItemBox.instance.TryUseItem(Item.Type.Key);
        if (isItemSelected)
        {
            StartCoroutine(KeyOpen());
            ClearGimmick();
        }
    }
    IEnumerator KeyOpen()
    {
        SE.Play("keyOpen");
        key.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        SE.Play("crrect");
        Destroy(key);
        openObj.CanOpenObject();
        openObj.AutoBackCamera();
    }
}