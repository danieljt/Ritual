using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

///<summary>
/// The camera manager is responsible for controlling the camera system and the
/// cinemachine virtual camera.
///</summary>
public class CameraManager : MonoBehaviour
{
    // Get refrence to the player or players
    // Set camera to follow them

    // The virtual camera for this scene
    public GameObject virtualCameraGameObject;

    [Tooltip("Player run time set. This is the set with the players")]
    public GameObjectRunTimeSet playerRunTimeSet;

    private GameObject[] players;

    private void Awake()
    {
        // Set up this script
    }

    private void OnEnable()
    {
        // Get the players from the runtimeset
        // Listen to player events.
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        // UnListen to the player events
        // remove players from runtimeset
    }
}
