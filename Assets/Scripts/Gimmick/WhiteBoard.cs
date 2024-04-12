using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WhiteBoard :Gimmick
{
    [SerializeField] Material writtenMaterial;
    private new void Start()
    {
        base.Start();
        if (GimmickManager.Instance.GetIsGimmickClear(name))
        {
            ChangeToWrittenMaterial();
        }
    }
    protected override void OnClickObj()
    {
        isItemSelected = ItemBox.instance.TryUseItem(Item.Type.SpongeWithSorp);
        if (isItemSelected)
        {
            ChangeToWrittenMaterial();
            ClearGimmick();
            SE.Play("kyukyu");
        }
    }
    void ChangeToWrittenMaterial()
    {
        var mr = GetComponent<MeshRenderer>();
        var mat = mr.materials;
        mat[1] = writtenMaterial;
        mr.materials = mat;
    }
}