using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BackButton :MonoBehaviour
{
    public void OnClickBackButton()
    {
        //�Y�[���L�����Z���̖߂�{�^��
        if (Zoom.instance.isZoom)
        {
            Zoom.instance.ZoomCancel();
            CameraManager.instance.UpdateButtonActive();
            return;
        }
        //�X�e�[�W��̖߂�{�^��
        BackOnStage();
    }
    void BackOnStage()
    {
        string enableCameraName = CameraManager.instance.currentZoomObj.enableCameraName;
        CameraManager.instance.ChangeCameraPosition(enableCameraName);
        if (!CameraManager.instance.isRotateCamera())
        {
            CameraManager.instance.currentZoomObj = CameraManager.instance.zoomObjManager.GetZoomObj(enableCameraName);
        }
        CloseAllOpenObj();
    }
    void CloseAllOpenObj()
    {
        var allOpenObj = GameObject.FindObjectsByType<OpenObj>(FindObjectsSortMode.None);
        foreach (var obj in allOpenObj)
        {
            var openObj = obj.GetComponent<OpenObj>();
            openObj.CloseObject();
        }
    }
}
