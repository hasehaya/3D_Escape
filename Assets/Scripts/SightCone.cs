using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SightCone :MonoBehaviour
{
    [SerializeField] Transform mainCameraTransform;
    private void Start()
    {
        CameraManager.instance.changeCameraPos += LookForwardAlways;
    }
    void LookForwardAlways()
    {
        transform.position = new Vector3(mainCameraTransform.position.x, 5, mainCameraTransform.position.z);
        transform.rotation = Quaternion.Euler(0, mainCameraTransform.localEulerAngles.y, 0);
    }
}
