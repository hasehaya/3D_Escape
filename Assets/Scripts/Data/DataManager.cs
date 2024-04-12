using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class DataManager :MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
            }
            return instance;
        }
    }
    private Flag flag;
    public Flag Flag
    {
        get
        {
            if (flag == null)
            {
                Load();
            }
            return flag;
        }
    }
    string fileName;
    private void Awake()
    {
        fileName = Application.persistentDataPath + "/savedata";
    }

    public void Save()
    {
        binarySaveLoad.Save(fileName, flag);
    }

    public void Load()
    {
        flag = new Flag();
        if (File.Exists(fileName))
        {
            binarySaveLoad.Load(fileName, out flag);
        }
        else
        {
            DataReset();
        }
    }
    public void DataReset()
    {
        flag = new Flag();
        ItemManager.Instance.ResetItemListEntity();
        PasswordManager.Instance.ResetPasswordsClearStatus();
        GimmickManager.Instance.ResetGimmicksClearStatus();
        SetObjManager.Instance.ResetSetObjClearStatus();
        flag.isTutorialCompleted = false;
        flag.isSeOn = true;
        flag.isBgmOn = true;
        flag.isMapOn = true;
        flag.isClearRemocon = false;
        flag.hasReadSynthesisInfo = false;
        flag.hasReadZoomInfo = false;
        flag.freeHintCount = 1;
        Save();
        SceneManager.Instance.GoToTitle();
    }
}
