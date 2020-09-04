using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Triggerable : MonoBehaviour, ITriggerable
{
    public abstract void OnNotify(int id);
}
