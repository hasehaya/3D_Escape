using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SE :Audio
{
    protected override void Start()
    {
        isSoundOn = DataManager.Instance.Flag.isSeOn;
        base.Start();
        instance = this;
    }
    public static void Play(string seName)
    {
        Sound sound = Array.Find(SE.instance.sounds, sound => sound.name == seName);
        sound.audioSource.Play();
    }

    protected override void SaveIsSoundOn()
    {
        DataManager.Instance.Flag.isSeOn = isSoundOn;
        DataManager.Instance.Save();
    }
}