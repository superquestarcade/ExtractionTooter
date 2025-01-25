using System;
using UnityEngine;

public class DamageReciever : MonoBehaviour
{
    public Action<float, Transform> OnTakeDamage;
    
    public void TakeDamage(float _value, Transform _sourceTransform)
    {
        OnTakeDamage?.Invoke(_value,_sourceTransform);
    }
}
