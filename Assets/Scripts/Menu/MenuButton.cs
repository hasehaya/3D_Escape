using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MenuButton :MonoBehaviour
{
    [SerializeField] GameObject settingCanvas;
    public void OnClickMenuButton()
    {
        settingCanvas.SetActive(true);
    }
}