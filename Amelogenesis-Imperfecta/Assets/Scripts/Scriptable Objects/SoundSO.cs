using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Scriptable Objects/Sound")]
public class SoundSO : ScriptableObject
{
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool playOnAwake;
    public bool loop;
    [HideInInspector]
    public AudioSource source;
}