using System.Collections;
using System.Threading;

using UnityEngine;
using UnityEngine.EventSystems;

public class Water :Gimmick
{
    [SerializeField] ParticleSystem waterEffect;
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject otherWaterObj;
    private new void Start()
    {
        base.Start();
        var eventTrigger = otherWaterObj.AddComponent<EventTrigger>();
        var onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(x => OnClickObj());

        eventTrigger.triggers.Add(onClick);
    }
    IEnumerator WaterEffect(int time)
    {
        waterEffect.Play();
        bottle.SetActive(true);
        yield return new WaitForSeconds(time);
        waterEffect.Stop();
        bottle.SetActive(false);
    }
    protected override void OnClickObj()
    {
        isItemSelected = ItemBox.instance.TryUseItem(Item.Type.BottleAndMagnet);
        if (isItemSelected)
        {
            SE.Play("water");
            StartCoroutine(WaterEffect(2));
            StartCoroutine(WaitToSet(2.5f, Item.Type.Magnet));
            ClearGimmick();
        }
    }
}
