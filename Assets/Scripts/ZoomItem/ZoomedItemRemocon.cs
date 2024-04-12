using UnityEngine;

public class ZoomedItemRemocon :ZoomedItem
{
    [SerializeField] GameObject battery;
    [SerializeField] GameObject bolt;
    [SerializeField] GameObject cover;
    [SerializeField] ParticleSystem coolorEffect;
    Cat cat;
    new void Start()
    {
        base.Start();
        battery.SetActive(false);
        cat = GameObject.FindGameObjectWithTag("Cat").GetComponent<Cat>();
        if (ItemManager.Instance.IsUsed(Item.Type.Driver))
        {
            Destroy(bolt);
        }
    }
    protected override void OnClickZoomedItem()
    {
        if (transform.localRotation.y == 0)
        {
            if (ItemManager.Instance.IsUsed(Item.Type.Driver))
            {
                if (cover != null)
                {
                    Destroy(cover);
                }
                else
                {
                    canUseItem = ItemBox.instance.TryUseItem(Item.Type.Battery);
                    if (canUseItem)
                    {
                        Clear();
                    }
                }
            }
            else
            {
                canUseItem = ItemBox.instance.TryUseItem(Item.Type.Driver);
                if (canUseItem)
                {
                    Destroy(bolt);
                }
            }
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Clear()
    {
        SE.Play("pi");
        var newCoolorEffect = Instantiate(coolorEffect);
        newCoolorEffect.Play();
        cat.UseRemocon();
        ItemBox.instance.DeleteItemToSlot(type);
        Zoom.instance.ZoomCancel();
        CameraManager.instance.UpdateButtonActive();
        GameManager.Instance.ClearRemocon();
        DataManager.Instance.Save();
        Destroy(gameObject);
    }
}