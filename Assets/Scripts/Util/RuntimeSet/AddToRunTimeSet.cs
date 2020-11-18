using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToRunTimeSet : MonoBehaviour
{
    public GameObjectRunTimeSet gameObjectRunTimeSet;

    private void OnEnable()
    {
        gameObjectRunTimeSet.Add(this.gameObject);
    }

    private void OnDisable()
    {
        gameObjectRunTimeSet.Remove(this.gameObject);
    }
}
