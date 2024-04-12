
using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class PasswordButton :MonoBehaviour
{
    Password password;
    [SerializeField] int changeNum;
    [NonSerialized] public int number = 0;
    void Start()
    {
        password = GetComponentInParent<Password>();
        var eventTrigger = gameObject.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickPasswordButton());
        eventTrigger.triggers.Add(onClick);

        ChangeLooks();
    }
    public void UnablePassword()
    {
        var boxCol = GetComponent<Collider>();
        boxCol.enabled = false;
    }
    void OnClickPasswordButton()
    {
        ChangeNum();
        ChangeLooks();
        CheckClear();
    }
    void ChangeNum()
    {
        if (number == changeNum)
        {
            number = 0;
        }
        else
        {
            number++;
        }
    }
    public virtual void ChangeLooks()
    {
    }
    public void CheckClear()
    {
        password.CheckClear();
    }
    public void InitCheckClear()
    {
        password.InitCheckClear();
    }
}
