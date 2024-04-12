
using TMPro;
using UnityEngine;

public class PassNum :PasswordButton
{
    [SerializeField] TextMeshPro text;
    public override void ChangeLooks()
    {
        text.text = number.ToString();
    }
}
