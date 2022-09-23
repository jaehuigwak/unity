using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void Damage(float value,Vector3 hitPoint,Vector3 hitNormal);
}
