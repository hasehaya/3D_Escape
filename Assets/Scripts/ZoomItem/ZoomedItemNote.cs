using UnityEngine;

public class ZoomedItemNote :ZoomedItem
{
    new void Start()
    {
        base.Start();
        if (ItemManager.Instance.IsUsed(Item.Type.Pencil))
        {
            ChangeToWrittenMaterial();
        }
    }
    protected override void OnClickZoomedItem()
    {
        canUseItem = ItemBox.instance.TryUseItem(Item.Type.Pencil);
        if (canUseItem)
        {
            SE.Play("pencil");
            ChangeToWrittenMaterial();
        }
    }
    void ChangeToWrittenMaterial()
    {
        var mr = GetComponent<MeshRenderer>();
        var mat = mr.materials;
        mat[2] = mat[3];
        mr.materials = mat;
    }
}