using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Waypoint", menuName = "Waypoint")]
public class Waypoint : ScriptableObject
{
    public WaypointData.types wtype;

}



public class WaypointData{
    public enum types{
        Water,
        Dungeon,
    }
} 