using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Rotate :MonoBehaviour
{
    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, 0f, -timer * 20);
    }
}
