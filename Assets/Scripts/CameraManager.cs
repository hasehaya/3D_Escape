using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraManager :MonoBehaviour
{
    public static CameraManager instance;
    public string currentCameraName;
    public ZoomObj currentZoomObj;
    public ZoomObjManager zoomObjManager;
    public event Action changeCameraPos;
    [SerializeField] PasswordManager passwordManager;
    [SerializeField]
    GameObject rightButton,
        leftButton,
        backButton;
    [SerializeField] GameObject camerasParent;

    Dictionary<string, Transform> cameraDic = new Dictionary<string, Transform>();
    GameObject[] cameras;
    Transform[] cameraTransforms;
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
        SetCameraDic();
        ChangeCameraPosition("N");
    }
    public void SetCameraDic()
    {
        int cameraCount = camerasParent.transform.childCount;
        cameras = new GameObject[cameraCount];
        cameraTransforms = new Transform[cameraCount];
        for (int i = 0; i < cameraCount; i++)
        {
            cameraTransforms[i] = camerasParent.transform.GetChild(i).transform;
            cameras[i] = cameraTransforms[i].gameObject;
            cameraDic.Add(cameras[i].name, cameraTransforms[i].transform);
        }
    }
    public void ChangeCameraPosition(string cameraName)
    {
        currentCameraName = cameraName;
        transform.position = cameraDic[currentCameraName].position;
        transform.rotation = cameraDic[currentCameraName].rotation;
        UpdateButtonActive();
        zoomObjManager.UpdateAllCollider();
        passwordManager.UpdateAllCollider();
        changeCameraPos.Invoke();
    }
    public void LeftButton()
    {
        switch (currentCameraName)
        {
            case "N":
            currentCameraName = "W";
            ChangeCameraPosition("W");
            break;
            case "E":
            currentCameraName = "N";
            ChangeCameraPosition("N");
            break;
            case "W":
            currentCameraName = "S";
            ChangeCameraPosition("S");
            break;
            case "S":
            currentCameraName = "E";
            ChangeCameraPosition("E");
            break;
        }
    }
    public void RightButton()
    {
        switch (currentCameraName)
        {
            case "N":
            currentCameraName = "E";
            ChangeCameraPosition("E");
            break;
            case "E":
            currentCameraName = "S";
            ChangeCameraPosition("S");
            break;
            case "W":
            currentCameraName = "N";
            ChangeCameraPosition("N");
            break;
            case "S":
            currentCameraName = "W";
            ChangeCameraPosition("W");
            break;
        }
    }
    public bool isRotateCamera()
    {
        if (currentCameraName == "N")
            return true;
        if (currentCameraName == "E")
            return true;
        if (currentCameraName == "W")
            return true;
        if (currentCameraName == "S")
            return true;
        return false;
    }
    public void UpdateButtonActive()
    {
        if (!isRotateCamera() || Zoom.instance.isZoom)
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
            backButton.SetActive(true);
        }
        else
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
            backButton.SetActive(false);
        }
    }
    public void HideDirectionButton()
    {
        rightButton.SetActive(false);
        leftButton.SetActive(false);
        backButton.SetActive(false);
    }
}
