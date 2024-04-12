using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PassBook :PasswordButton
{
    [SerializeField] GameObject bar;
    public override void ChangeLooks()
    {
        bar.transform.localRotation = Quaternion.Euler(0, number * 45, 0);
    }
}