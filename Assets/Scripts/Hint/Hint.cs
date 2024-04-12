using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Hint :MonoBehaviour
{
    public static Hint instance;
    [SerializeField] Text hintText;
    [SerializeField] Text comfirmText;
    [SerializeField] Text comfirmButtonText;
    [SerializeField] Text debugText;
    [SerializeField] GameObject hintConfirmationPanel;
    [SerializeField] GameObject hintPanel;
    string previousHintText = "";
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ChangeFreeHintCountText();
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (debugText != null)
        {
            debugText.text = GetHintText();
        }
#endif
    }
    public void OnClickHintButton()
    {
        if (previousHintText == GetHintText())
        {
            GetReward();
        }
        else
        {
            ChangeFreeHintCountText();
            hintConfirmationPanel.SetActive(true);
        }
    }
    void ChangeFreeHintCountText()
    {
        if (DataManager.Instance.Flag.freeHintCount >= 1)
        {
            comfirmText.text = "�q���g���݂�H\r\n(�����F�c��" + DataManager.Instance.Flag.freeHintCount + "��)";
            comfirmButtonText.text = "�q���g������";
        }
        else
        {
            comfirmText.text = "�݂������ǂ������݂�\r\n�q���g���݂�H";
            comfirmButtonText.text = "���������";
        }
    }
    public void OnClickHintAdButton()
    {

        if (DataManager.Instance.Flag.freeHintCount >= 1)
        {
            DataManager.Instance.Flag.freeHintCount--;
            DataManager.Instance.Save();
            GetReward();
        }
        else
        {
            AdMobReward.instance.ShowAdMobReward();
        }
    }
    public void GetReward()
    {
        hintConfirmationPanel.SetActive(false);
        hintPanel.SetActive(true);
        SetHintText();
    }
    void SetHintText()
    {
        hintText.text = GetHintText();
        previousHintText = GetHintText();
    }


    //--------------------�q���g�e�L�X�g�֌W-------------------
    bool isNotObtainItem(Item.Type type)
    {
        if (ItemManager.Instance.GetItemStatus(type) == Item.Status.NotObtain)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool isUsedItem(Item.Type type)
    {
        if (ItemManager.Instance.GetItemStatus(type) == Item.Status.Used)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool isClearGimmick(string name)
    {
        return GimmickManager.Instance.GetIsGimmickClear(name);
    }
    bool isClearPassword(string name)
    {
        return PasswordManager.Instance.GetIsPasswordClear(name);
    }
    string GetHintText()
    {
        //�X�e�[�W�����番����
        if (!isClearPassword("PassBall"))
        {
            return "�{�[���̐����p�X���[�h�̃q���g�ɂȂ��Ă��I";
        }
        if (isNotObtainItem(Item.Type.Pencil))
        {
            return "�{�[���̃p�X���[�h�̂Ƃ��납��A�A�C�e�����Ƃ�킷��Ă��I";
        }
        if (!isClearPassword("PassBin"))
        {
            return "�L�b�`���̃r���̂Ȃ�т��A�p�X���[�h�̃q���g�ɂȂ��Ă��I";
        }
        if (isNotObtainItem(Item.Type.Triangle))
        {
            return "�r���̃p�X���[�h�̂Ƃ��납��A�A�C�e�����Ƃ�킷��Ă��I";
        }
        if (!isClearPassword("PassBook"))
        {
            return "�ق�̂����ނ����A�p�X���[�h�̃q���g�ɂȂ��Ă��I";
        }
        if (isNotObtainItem(Item.Type.Note))
        {
            return "�ق�̂����ނ��̃p�X���[�h�̂Ƃ��납��A�A�C�e�����Ƃ�킷��Ă��I";
        }
        if (!isClearPassword("PassChair"))
        {
            return "�����̂�������̂ڂ����A���ꂼ�ꂷ���Ȃ���I";
        }
        if (isNotObtainItem(Item.Type.Square))
        {
            return "�����̂�������̃p�X���[�h�̂Ƃ��납��A�A�C�e�����Ƃ�킷��Ă��I";
        }
        if (!isClearPassword("PassClock"))
        {
            return "H��M�́A�Ƃ����̂͂������킵�Ă����I";
        }
        if (isNotObtainItem(Item.Type.Cylinder))
        {
            return "H��M�̃p�X���[�h�̂Ƃ��납��A�A�C�e�����Ƃ�킷��Ă��I";
        }
        //�X�e�[�W��
        if (isNotObtainItem(Item.Type.Sponge))
        {
            return "�L�b�`���ɃX�|���W�������I";
        }
        if (isNotObtainItem(Item.Type.Thread))
        {
            return "���Ȃ̂����ɁA���Ƃ������I";
        }
        //root1
        if (!isClearPassword("ShelfRightBottomPassword"))
        {
            return "��������A��������A������̂��̂��ǂ����ɂ͂߂��邩���H";
        }
        if (isNotObtainItem(Item.Type.BottleAndMagnet))
        {
            return "�{�g�����Ƃ�킷��Ă邩���H";
        }
        if (!isClearGimmick("Water"))
        {
            return "�{�g���ɂ݂�������āA�����Ⴍ���Ƃ肾���邩���H";
        }
        if (isNotObtainItem(Item.Type.MagnetAndThread))
        {
            return "�����Ⴍ�Ǝ������������邩���H";
        }
        if (!isClearGimmick("TrashBox"))
        {
            return "�����Ⴍ�Ǝ��ŁA�S�~�΂�����Ȃɂ��Ђ낦�邩���H";
        }
        if (!isClearGimmick("ToolBox"))
        {
            return "�J�M���A��������̂͂��Ɏg�����I";
        }
        if (isNotObtainItem(Item.Type.Driver))
        {
            return "�h���C�o�[��������������Ƃ�킷��Ă邩���H";
        }
        //root2
        if (!isUsedItem(Item.Type.Pencil))
        {
            return "����҂Ńm�[�g�ɂ����Ă݂悤�I";
        }
        if (!isClearPassword("PassNote"))
        {
            return "�m�[�g�̂��������A�p�X���[�h�ɂȂ��Ă��I";
        }
        if (isNotObtainItem(Item.Type.Sorp))
        {
            return "���񂴂����Ƃ�킷��Ă邩���H";
        }
        if (isNotObtainItem(Item.Type.SpongeWithSorp))
        {
            return "�X�|���W�ɂ��񂴂����������I";
        }
        if (!isClearGimmick("WhiteBoard"))
        {
            return "�X�|���W�Ńz���C�g�{�[�h�����ꂢ�ɂ��Ă݂悤�I";
        }
        if (!isClearPassword("PassWhiteboard"))
        {
            return "�z���C�g�{�[�h�̂��������A�p�X���[�h�ɂȂ��Ă��I";
        }
        if (isNotObtainItem(Item.Type.Battery))
        {
            return "�ł񂿂��Ƃ�킷��Ă邩���H";
        }
        //����
        if (!isClearPassword("PassHeight"))
        {
            return "�������͂��̂ӂ����A�p�X���[�h�̃q���g�ɂȂ��Ă��I";
        }
        if (isNotObtainItem(Item.Type.Remocon))
        {
            return "������̂܂�̃p�X���[�h�̂Ƃ��납��A�A�C�e�����Ƃ�킷��Ă��I";
        }
        if (!isUsedItem(Item.Type.Driver))
        {
            return "�����R�����^�b�v���Ă���A����̃l�W���h���C�o�[�łƂ��Ă݂悤�I";
        }
        if (!isUsedItem(Item.Type.Battery))
        {
            return "�����R���ɂł񂿂�����Ă����������I";
        }
        if (!isClearPassword("PassDoor"))
        {
            return "�^�C�g���ɂ��ǂ��Ă݂悤�I";
        }
        return "";
    }
}
