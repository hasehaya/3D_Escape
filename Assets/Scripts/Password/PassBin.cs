using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PassBin :PasswordButton
{
    [SerializeField]
    Material[] materials;
    public override void ChangeLooks()
    {
        var mr = GetComponent<MeshRenderer>();
        mr.material = materials[number];
    }
}
