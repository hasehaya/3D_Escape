using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SetObjManager :MonoBehaviour
{
    private static SetObjManager instance;
    public static SetObjManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SetObjManager>();
            }
            return instance;
        }
    }
    SetObj[] setObjs;

    private void Awake()
    {
        setObjs = GameObject.FindObjectsOfType<SetObj>();
    }
    private void Start()
    {
        LoadSetObjClearStatus();
    }
    public void SaveSetObjClearStatus()
    {
        DataManager.Instance.Flag.setObjStatus.Clear();
        foreach (var setObj in setObjs)
        {
            DataManager.Instance.Flag.setObjStatus.Add(setObj.name, setObj.isSet);
        }
        DataManager.Instance.Save();
    }
    void LoadSetObjClearStatus()
    {
        foreach (var setObj in setObjs)
        {
            setObj.isSet = DataManager.Instance.Flag.setObjStatus[setObj.name];
        }
    }
    public void ResetSetObjClearStatus()
    {
        setObjs = GameObject.FindObjectsOfType<SetObj>();
        DataManager.Instance.Flag.setObjStatus.Clear();
        foreach (var setObj in setObjs)
        {
            DataManager.Instance.Flag.setObjStatus.Add(setObj.name, false);
        }
    }
}
