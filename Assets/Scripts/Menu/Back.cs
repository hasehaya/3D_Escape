using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Back :MonoBehaviour
{
    [SerializeField] GameObject deleteObject;
    private void Start()
    {
        var button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(OnClickBackButton);
    }
    public void OnClickBackButton()
    {
        deleteObject.SetActive(false);
    }
}