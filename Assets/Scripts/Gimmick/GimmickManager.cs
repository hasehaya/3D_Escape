using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GimmickManager :MonoBehaviour
{
    private static GimmickManager instance;
    public static GimmickManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GimmickManager>();
            }
            return instance;
        }
    }
    Gimmick[] gimmicks;
    private void Awake()
    {
        gimmicks = GameObject.FindObjectsOfType<Gimmick>();
    }
    private void Start()
    {
        LoadGimmicksClearStatus();
    }
    public void SaveGimmicksClearStatus()
    {
        DataManager.Instance.Flag.gimmicksClearStatus.Clear();
        foreach (var gimmick in gimmicks)
        {
            if (!DataManager.Instance.Flag.gimmicksClearStatus.ContainsKey(gimmick.name))
            {
                DataManager.Instance.Flag.gimmicksClearStatus.Add(gimmick.name, gimmick.isGimmickClear);
            }
        }
        DataManager.Instance.Save();
    }
    void LoadGimmicksClearStatus()
    {
        foreach (var gimmick in gimmicks)
        {
            gimmick.isGimmickClear = DataManager.Instance.Flag.gimmicksClearStatus[gimmick.name];
        }
    }
    public void ResetGimmicksClearStatus()
    {
        gimmicks = GameObject.FindObjectsOfType<Gimmick>();
        foreach (var gimmick in gimmicks)
        {
            if (!DataManager.Instance.Flag.gimmicksClearStatus.ContainsKey(gimmick.name))
            {
                DataManager.Instance.Flag.gimmicksClearStatus.Add(gimmick.name, false);
            }
        }
    }
    public bool GetIsGimmickClear(string name)
    {
        return DataManager.Instance.Flag.gimmicksClearStatus[name];
    }
}