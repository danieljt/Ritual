using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

///<summary>
/// Every character in a game should have some sort og health. This interface defines the
/// standard contract that any class involving health should have.
///</summary>
public interface IHealth 
{
    // In the case where the health changes or character dies certain objects should be notified. This could be
    // the health bar, other enemies, a timer or anything else that you would want. Theese events
    // create a decoupled contract for that
    event Action<int> OnHealthChanged;
    event Action OnDied;

    // The character takes damage
    void OnDamageTaken(int damageTaken);
}
