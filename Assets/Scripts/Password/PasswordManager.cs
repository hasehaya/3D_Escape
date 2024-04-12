using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PasswordManager :MonoBehaviour
{
    private static PasswordManager instance;
    public static PasswordManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PasswordManager>();
            }
            return instance;
        }
    }
    Password[] passwords;

    private void Awake()
    {
        //èâä˙âªÇç≈èâÇ…Ç‚ÇÁÇ»Ç¢Ç∆ÇŸÇ©Ç≈UpdateAllCollideråƒÇ—èoÇ≥ÇÍÇƒÉoÉOÇÈ
        passwords = GameObject.FindObjectsOfType<Password>();
    }
    private void Start()
    {
        LoadPasswordsClearStatus();
    }
    public void UpdateAllCollider()
    {
        foreach (var password in passwords)
        {
            password.UpdateCollider();
        }
    }
    public void SavePasswordsClearStatus()
    {
        DataManager.Instance.Flag.passwordsClearStatus.Clear();
        foreach (var password in passwords)
        {
            DataManager.Instance.Flag.passwordsClearStatus.Add(password.name, password.isPasswordClear);
        }
        DataManager.Instance.Save();
    }
    void LoadPasswordsClearStatus()
    {
        foreach (var password in passwords)
        {
            password.isPasswordClear = DataManager.Instance.Flag.passwordsClearStatus[password.name];
        }
    }
    public void ResetPasswordsClearStatus()
    {
        passwords = GameObject.FindObjectsOfType<Password>();
        foreach (var password in passwords)
        {
            DataManager.Instance.Flag.passwordsClearStatus.Add(password.name, false);
        }
    }
    public bool GetIsPasswordClear(string name)
    {
        return DataManager.Instance.Flag.passwordsClearStatus[name];
    }
}
