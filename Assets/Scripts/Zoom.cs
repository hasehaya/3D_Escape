using UnityEngine;
public class Zoom :MonoBehaviour
{
    public static Zoom instance;
    public bool isZoom;
    [SerializeField] BoxCollider col;
    GameObject zoomItem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        col.enabled = false;
    }
    public void ZoomItem(Slot selectedSlot)
    {
        isZoom = true;
        col.enabled = true;
        zoomItem = ItemManager.Instance.GenerateZoomItem(selectedSlot.GetItem().type);
        ItemBox.instance.zoomedSlot = selectedSlot;
        CameraManager.instance.UpdateButtonActive();
    }
    public void ZoomCancel()
    {
        isZoom = false;
        col.enabled = false;
        Destroy(zoomItem);
        ItemBox.instance.zoomedSlot = null;
    }
}
