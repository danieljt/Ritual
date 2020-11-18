using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Defines functionality for a waypoint. A waypoint is a position in space defined by either nothing
/// or anything. When pathfinding, waypoint systems are a good alternative to grids
///</summary>
public interface IWaypoint
{
    ///<summary>
    /// A waypoint has a series of neighbour waypoints that connects it. This in turn creates 
    /// a possible system of waypoints. When implementing it 
    ///<summary>
    IWaypoint[] GetWayPointNeighbours();
}
