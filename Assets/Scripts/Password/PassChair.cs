using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassChair :PasswordButton
{
    [SerializeField] GameObject[] passObjs;
    public override void ChangeLooks()
    {
        for (int i = 0; i < passObjs.Length; i++)
        {
            if (i == number)
            {
                passObjs[i].gameObject.SetActive(false);
            }
            else
            {
                passObjs[i].gameObject.SetActive(true);
            }
        }
    }
}
