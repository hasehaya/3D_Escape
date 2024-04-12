using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class ZoomObjManager :MonoBehaviour
{
    public static ZoomObjManager instance;
    ZoomObj[] zoomObjs;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetZoomObj();
        UpdateAllCollider();
    }
    public void SetZoomObj()
    {
        zoomObjs = GameObject.FindObjectsOfType<ZoomObj>();
    }
    public void UpdateAllCollider()
    {
        foreach (var zoomObj in zoomObjs)
        {
            zoomObj.UpdateCollider();
        }
    }
    public ZoomObj GetZoomObj(string zoomObjName)
    {
        var zoomObj = transform.Find(zoomObjName).GetComponent<ZoomObj>();
        return zoomObj;
    }
}
