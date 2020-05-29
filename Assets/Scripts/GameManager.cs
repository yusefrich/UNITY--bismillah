using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Dictionary <GameObject, Waypoint> waypoints =  new Dictionary <GameObject, Waypoint>();

    void Awake()
    {
        instance = this;
    }

    //! FUNCTIONS ==>
    //TODO (NULL)

    //! EVENT FUNCTIONS ==>
    public void AddWaypoint(GameObject holder, Waypoint waypointToAdd){
        waypoints.Add(holder, waypointToAdd);
    }

    //! EVENTS ==>
    public event Action onRequestObjcts;

    public Dictionary <GameObject, Waypoint> RequestObjcts(){
        waypoints =  new Dictionary <GameObject, Waypoint>();

        if( onRequestObjcts != null){
            onRequestObjcts();
        }

        return waypoints;
    }
}
