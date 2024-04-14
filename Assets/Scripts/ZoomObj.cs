using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomObj :MonoBehaviour
{
    public string enableCameraName;
    [SerializeField] OpenObj openObj;
    private void Start()
    {
        var eventTrigger = gameObject.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickObj());

        eventTrigger.triggers.Add(onClick);
    }
    public void OnClickObj()
    {
        //drowerが開いているときはズームせずに開ける
        if (openObj != null && openObj.canOpen)
        {
            openObj.OnClickOpenObject();
        }
        else
        {
            CameraManager.instance.currentZoomObj = GetComponent<ZoomObj>();
            CameraManager.instance.ChangeCameraPosition(this.name);
        }
    }
    public void UpdateCollider()
    {
        if (openObj != null)
        {
            GetComponent<Collider>().enabled = true;
            return;
        }
        if (enableCameraName == CameraManager.instance.currentCameraName)
        {
            GetComponent<Collider>().enabled = true;
            return;
        }
        GetComponent<Collider>().enabled = false;
    }
}
