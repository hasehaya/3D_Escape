
using UnityEngine;

public class Password :MonoBehaviour
{
    [SerializeField] string enableCameraName;
    [SerializeField] int[] correctPasswords;
    [SerializeField] OpenObj openObj;
    [SerializeField] Item.Type clearItemType;
    public PasswordButton[] passwords;
    public bool isPasswordClear;
    Collider[] cols;

    private void Awake()
    {
        passwords = GetComponentsInChildren<PasswordButton>();
        cols = GetComponentsInChildren<Collider>();
    }
    private void Start()
    {
        CheckClearStatus();
        UpdateCollider();
    }
    bool isClear()
    {
        for (int i = 0; i < correctPasswords.Length; i++)
        {
            if (passwords[i].number != correctPasswords[i])
            {
                return false;
            }
        }
        return true;
    }
    void CheckClearStatus()
    {
        if (isPasswordClear)
        {
            for (int i = 0; i < correctPasswords.Length; i++)
            {
                passwords[i].number = correctPasswords[i];
            }
            foreach (var pass in passwords)
            {
                pass.ChangeLooks();
                pass.UnablePassword();
            }
            openObj.CanOpenObject();
            openObj.CloseObject();
        }
    }
    public void CheckClear()
    {
        if (isClear())
        {
            SE.Play("crrect");
            foreach (var pass in passwords)
            {
                pass.UnablePassword();
            }
            isPasswordClear = true;
            PasswordManager.Instance.SavePasswordsClearStatus();
            openObj.AutoBackCamera();
            openObj.CanOpenObject();
            DeleteClearItem();
            GameClear();
        }
        SE.Play("poka");
    }
    public void InitCheckClear()
    {
        if (isClear())
        {
            foreach (var pass in passwords)
            {
                pass.UnablePassword();
            }
            isPasswordClear = true;
            openObj.CanOpenObject();
            openObj.CloseObject();
        }
    }
    public void UpdateCollider()
    {
        if (enableCameraName == CameraManager.instance.currentCameraName && !isPasswordClear)
        {
            foreach (var col in cols)
            {
                col.enabled = true;
            }
        }
        else
        {
            foreach (var col in cols)
            {
                col.enabled = false;
            }
        }
    }
    void DeleteClearItem()
    {
        switch (clearItemType)
        {
            case Item.Type.Note:
            ItemBox.instance.DeleteItemToSlot(clearItemType);
            break;
        }
    }
    void GameClear()
    {
        if (name == "PassDoor")
        {
            var gameClear = GetComponent<GameClear>();
            gameClear.ClearProcess();
        }
    }
}