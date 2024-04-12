using UnityEngine;
[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public float volume;
    [HideInInspector]
    public string name;
    [HideInInspector]
    public AudioSource audioSource;
}
