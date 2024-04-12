using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SynthesisInfo :MonoBehaviour
{
    private float hasCombinationItemTime = 0f;
    [SerializeField] GameObject combinationHintPanel;

    private void Start()
    {
        if (DataManager.Instance.Flag.hasReadSynthesisInfo)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (!ItemBox.instance.HasSynthesisItem())
            return;
        hasCombinationItemTime += Time.deltaTime;
        if (hasCombinationItemTime > 100)
        {
            ActivateCombinationHint();
        }
    }

    private void ActivateCombinationHint()
    {
        DataManager.Instance.Flag.hasReadSynthesisInfo = true;
        combinationHintPanel.SetActive(true);
        SE.Play("piro");
        Destroy(gameObject);
    }
}
