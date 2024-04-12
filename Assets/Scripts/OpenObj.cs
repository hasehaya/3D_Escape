using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenObj :MonoBehaviour
{
    [SerializeField] bool needsToSwithRearCamera;
    [SerializeField] bool isPassword;
    [SerializeField] ObjType type;
    public bool canOpen;
    bool isOpen = false;
    Animator anim;
    enum ObjType
    {
        drawer,
        box,
        shelf,
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        AddEventTrigger();
        if (isPassword)
        {
            anim.SetBool("canOpen", false);
            canOpen = false;
        }
        else
        {
            anim.SetBool("canOpen", true);
            canOpen = true;
        }
    }
    void AddEventTrigger()
    {
        var zoomObj = GetComponent<ZoomObj>();
        if (zoomObj == null)
        {
            var eventTrigger = gameObject.AddComponent<EventTrigger>();
            var onClick = new EventTrigger.Entry();
            onClick.eventID = EventTriggerType.PointerClick;
            onClick.callback.AddListener(x => OnClickOpenObject());
            eventTrigger.triggers.Add(onClick);
        }
    }
    public void AutoBackCamera()
    {
        if (needsToSwithRearCamera)
        {
            string _enableCameraName = CameraManager.instance.currentZoomObj.enableCameraName;
            CameraManager.instance.ChangeCameraPosition(_enableCameraName);
        }
    }
    public void CanOpenObject()
    {
        anim.SetBool("canOpen", true);
        canOpen = true;
        OpenObject();
    }
    public void OnClickOpenObject()
    {
        if (!canOpen)
        {
            return;
        }
        if (isOpen)
        {
            CloseObject();
            PlaySE();
        }
        else
        {
            OpenObject();
            PlaySE();
        }
    }
    public void OpenObject()
    {
        anim.SetBool("isOpen", true);
        isOpen = true;
    }
    public void CloseObject()
    {
        anim.SetBool("isOpen", false);
        isOpen = false;
    }
    void PlaySE()
    {
        switch (type)
        {
            case ObjType.drawer:
            SE.Play("drawer");
            break;
            case ObjType.box:
            SE.Play("passOpen");
            break;
            case ObjType.shelf:
            SE.Play("open");
            break;
        }
    }
}
