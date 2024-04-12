using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Map :MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject map;
    public bool isMapOn = true;
    private void Start()
    {
        isMapOn = DataManager.Instance.Flag.isMapOn;
        if (isMapOn)
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
    }
    public void OnClickMapButton()
    {
        if (isMapOn)
        {
            isMapOn = false;
            map.SetActive(false);
            slider.value = 0;
        }
        else
        {
            isMapOn = true;
            map.SetActive(true);
            slider.value = 1;
        }
        SaveIsMapOn();
    }
    void SaveIsMapOn()
    {
        DataManager.Instance.Flag.isMapOn = isMapOn;
        DataManager.Instance.Save();
    }
}
