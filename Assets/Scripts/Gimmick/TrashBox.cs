using System.Collections;

using UnityEngine;

public class TrashBox :Gimmick
{
    [SerializeField] GameObject magnetAndThread;
    protected override void OnClickObj()
    {
        isItemSelected = ItemBox.instance.TryUseItem(Item.Type.MagnetAndThread);
        if (isItemSelected)
        {
            StartCoroutine(KeyUp());
            StartCoroutine(WaitToSet(2.2f, Item.Type.Key));
            ClearGimmick();
        }
    }
    IEnumerator KeyUp()
    {
        magnetAndThread.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(magnetAndThread);
    }
}
