using System;
using UnityEngine;

[Serializable]
public class FloatReference : ScriptableObject
{
#if UNITY_EDITOR
    [TextArea(3, 20)]
    public string DeveloperDescription = "";
#endif

    public bool useConstant = true;
    public float constantValue;
    public FloatVariable variable;

    public FloatReference()
    {

    }

    public FloatReference(float value)
    {
        useConstant = true;
        constantValue = value;
    }

    public float Value
    {
        get { return useConstant ? constantValue : variable.value; }
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}
