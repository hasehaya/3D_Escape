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
            comfirmText.text = "ヒントをみる？\r\n(無料：残り" + DataManager.Instance.Flag.freeHintCount + "回)";
            comfirmButtonText.text = "ヒントを見る";
        }
        else
        {
            comfirmText.text = "みじかいどうがをみて\r\nヒントをみる？";
            comfirmButtonText.text = "動画を見る";
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


    //--------------------ヒントテキスト関係-------------------
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
        //ステージ見たら分かる
        if (!isClearPassword("PassBall"))
        {
            return "ボールの数がパスワードのヒントになってるよ！";
        }
        if (isNotObtainItem(Item.Type.Pencil))
        {
            return "ボールのパスワードのところから、アイテムをとりわすれてるよ！";
        }
        if (!isClearPassword("PassBin"))
        {
            return "キッチンのビンのならびが、パスワードのヒントになってるよ！";
        }
        if (isNotObtainItem(Item.Type.Triangle))
        {
            return "ビンのパスワードのところから、アイテムをとりわすれてるよ！";
        }
        if (!isClearPassword("PassBook"))
        {
            return "ほんのかたむきが、パスワードのヒントになってるよ！";
        }
        if (isNotObtainItem(Item.Type.Note))
        {
            return "ほんのかたむきのパスワードのところから、アイテムをとりわすれてるよ！";
        }
        if (!isClearPassword("PassChair"))
        {
            return "いすのせもたれのぼうが、それぞれすくないよ！";
        }
        if (isNotObtainItem(Item.Type.Square))
        {
            return "いすのせもたれのパスワードのところから、アイテムをとりわすれてるよ！";
        }
        if (!isClearPassword("PassClock"))
        {
            return "HとMは、とけいのはりをあらわしているよ！";
        }
        if (isNotObtainItem(Item.Type.Cylinder))
        {
            return "HとMのパスワードのところから、アイテムをとりわすれてるよ！";
        }
        //ステージ上
        if (isNotObtainItem(Item.Type.Sponge))
        {
            return "キッチンにスポンジがあるよ！";
        }
        if (isNotObtainItem(Item.Type.Thread))
        {
            return "たなのしたに、いとがあるよ！";
        }
        //root1
        if (!isClearPassword("ShelfRightBottomPassword"))
        {
            return "あかいろ、あおいろ、きいろのものをどこかにはめられるかも？";
        }
        if (isNotObtainItem(Item.Type.BottleAndMagnet))
        {
            return "ボトルをとりわすれてるかも？";
        }
        if (!isClearGimmick("Water"))
        {
            return "ボトルにみずをいれて、じしゃくをとりだせるかも？";
        }
        if (isNotObtainItem(Item.Type.MagnetAndThread))
        {
            return "じしゃくと糸をくっつけられるかも？";
        }
        if (!isClearGimmick("TrashBox"))
        {
            return "じしゃくと糸で、ゴミばこからなにかひろえるかも？";
        }
        if (!isClearGimmick("ToolBox"))
        {
            return "カギが、あかいろのはこに使えるよ！";
        }
        if (isNotObtainItem(Item.Type.Driver))
        {
            return "ドライバーをあかい箱からとりわすれてるかも？";
        }
        //root2
        if (!isUsedItem(Item.Type.Pencil))
        {
            return "えんぴつでノートにかいてみよう！";
        }
        if (!isClearPassword("PassNote"))
        {
            return "ノートのすうじが、パスワードになってるよ！";
        }
        if (isNotObtainItem(Item.Type.Sorp))
        {
            return "せんざいをとりわすれてるかも？";
        }
        if (isNotObtainItem(Item.Type.SpongeWithSorp))
        {
            return "スポンジにせんざいをつけられるよ！";
        }
        if (!isClearGimmick("WhiteBoard"))
        {
            return "スポンジでホワイトボードをきれいにしてみよう！";
        }
        if (!isClearPassword("PassWhiteboard"))
        {
            return "ホワイトボードのすうじが、パスワードになってるよ！";
        }
        if (isNotObtainItem(Item.Type.Battery))
        {
            return "でんちをとりわすれてるかも？";
        }
        //合流
        if (!isClearPassword("PassHeight"))
        {
            return "あかいはこのふたが、パスワードのヒントになってるよ！";
        }
        if (isNotObtainItem(Item.Type.Remocon))
        {
            return "きいろのまるのパスワードのところから、アイテムをとりわすれてるよ！";
        }
        if (!isUsedItem(Item.Type.Driver))
        {
            return "リモコンをタップしてから、うらのネジをドライバーでとってみよう！";
        }
        if (!isUsedItem(Item.Type.Battery))
        {
            return "リモコンにでんちをいれてうごかそう！";
        }
        if (!isClearPassword("PassDoor"))
        {
            return "タイトルにもどってみよう！";
        }
        return "";
    }
}
