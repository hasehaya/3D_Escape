using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ZoomInfo :MonoBehaviour
{
    private float hasCombinationItemTime = 0f;
    [SerializeField] GameObject zoomHintPanel;

    private void Start()
    {
        if (DataManager.Instance.Flag.hasReadZoomInfo)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (!ItemBox.instance.HasAnyItem())
            return;
        hasCombinationItemTime += Time.deltaTime;
        if (hasCombinationItemTime > 120)
        {
            ActivateCombinationHint();
        }
    }

    private void ActivateCombinationHint()
    {
        DataManager.Instance.Flag.hasReadZoomInfo = true;
        zoomHintPanel.SetActive(true);
        SE.Play("piro");
        Destroy(gameObject);
    }
}
