using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class Flag
{
    public Dictionary<Item.Type, Item.Status> itemStatusDictionary;
    public Dictionary<string, bool> passwordsClearStatus;
    public Dictionary<string, bool> gimmicksClearStatus;
    public Dictionary<string, bool> setObjStatus;
    public bool isTutorialCompleted;
    public bool isSeOn;
    public bool isBgmOn;
    public bool isMapOn;
    public bool isClearRemocon;
    public bool hasReadSynthesisInfo;
    public bool hasReadZoomInfo;
    public int freeHintCount;

    public Flag()
    {
        itemStatusDictionary = new Dictionary<Item.Type, Item.Status>();
        passwordsClearStatus = new Dictionary<string, bool>();
        gimmicksClearStatus = new Dictionary<string, bool>();
        setObjStatus = new Dictionary<string, bool>();
        isTutorialCompleted = false;
        isSeOn = true;
        isBgmOn = true;
        isMapOn = true;
        isClearRemocon = false;
        hasReadSynthesisInfo = false;
        hasReadZoomInfo = false;
    }
    public void PrintContents()
    {
        Debug.Log("Item Status Dictionary:");
        foreach (KeyValuePair<Item.Type, Item.Status> entry in itemStatusDictionary)
        {
            Debug.Log("Type: " + entry.Key + ", Status: " + entry.Value);
        }

        Debug.Log("Passwords Clear Status:");
        foreach (KeyValuePair<string, bool> entry in passwordsClearStatus)
        {
            Debug.Log("Password: " + entry.Key + ", Status: " + entry.Value);
        }

        Debug.Log("Gimmicks Clear Status:");
        foreach (KeyValuePair<string, bool> entry in gimmicksClearStatus)
        {
            Debug.Log("Gimmick: " + entry.Key + ", Status: " + entry.Value);
        }

        Debug.Log("Set Object Status:");
        foreach (KeyValuePair<string, bool> entry in setObjStatus)
        {
            Debug.Log("Object: " + entry.Key + ", Status: " + entry.Value);
        }

        Debug.Log("Is Tutorial Completed: " + isTutorialCompleted);
    }
}