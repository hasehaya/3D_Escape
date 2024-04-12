using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TitleManager :MonoBehaviour
{
    [SerializeField] ParticleSystem cloudNum;
    private void Start()
    {
        Time.timeScale = 1.0f;
        if (GameManager.isClearRemocon)
        {
            cloudNum.Play();
        }
    }
}
