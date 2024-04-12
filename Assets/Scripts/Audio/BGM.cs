using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BGM :Audio
{
    protected override void Start()
    {
        isSoundOn = DataManager.Instance.Flag.isBgmOn;
        base.Start();
        foreach (var sound in sounds)
        {
            sound.audioSource.loop = true;
        }
        Play("1");
    }
    void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.audioSource.Play();
    }

    protected override void SaveIsSoundOn()
    {
        DataManager.Instance.Flag.isBgmOn = isSoundOn;
        DataManager.Instance.Save();
    }
}
