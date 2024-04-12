using UnityEngine;
using UnityEngine.EventSystems;

public class Cat :MonoBehaviour
{
    [SerializeField]
    GameObject
        catCameraCollider,
        doorCameraCollider,
        passDoorCameraCollider;

    private void Start()
    {
        var eventTrigger = gameObject.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => CatMeow());
        eventTrigger.triggers.Add(onClick);
        if (GameManager.isClearRemocon)
        {
            UseRemocon();
        }
    }
    void CatMeow()
    {
        SE.Play("nya");
    }
    public void UseRemocon()
    {
        CatMove();
        DeleteCatCameraCollider();
        ActiveDoorCameraCollider();
    }
    void CatMove()
    {
        transform.position = new Vector3(6.56f, 0.1551025f, 6.266f);
        transform.rotation = Quaternion.Euler(-90, 0, 90);
    }
    void DeleteCatCameraCollider()
    {
        Destroy(catCameraCollider);
    }
    void ActiveDoorCameraCollider()
    {
        doorCameraCollider.SetActive(true);
        passDoorCameraCollider.SetActive(true);
        ZoomObjManager.instance.SetZoomObj();
    }
}
