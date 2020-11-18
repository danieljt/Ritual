using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Defines a waypoint. 
///<summary>
public class WayPoint : MonoBehaviour, IWaypoint
{
    [Tooltip("A waypoint has an Id that can be used for identification, or connecting it to certain other waypoints, or other smart things")]
    public int id;
    public IWaypoint[] neighbours;

    public IWaypoint[] GetWayPointNeighbours()
    {
        return neighbours;
    }
}
