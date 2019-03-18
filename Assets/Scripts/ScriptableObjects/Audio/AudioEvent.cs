using UnityEngine;

public abstract class AudioEvent : ScriptableObject
{
#if UNITY_EDITOR
    [TextArea(3, 20)]
    public string DeveloperDescription = "";
#endif
    public abstract void Play(AudioSource source);
}
