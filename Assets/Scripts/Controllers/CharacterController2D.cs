/*
Property of StupidGirlGames @Daniel James Tarplett.
Copying or redistribution is prohibited without written concent.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// This is the base class from which all controllers inherit from. A charactercontroller
/// defines the interface between a player/ai and their behaviours. A behaviour in this sense is
/// a statemachinebehaviour in the animator component meaning that the charactercontroller is
/// based on finite state machine implementations for player and AI controllers. This class is 
/// abstract and must be extended to the situation required.
///</summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class CharacterController2D : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rBody;
}
