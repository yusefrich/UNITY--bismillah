using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsController : MonoBehaviour
{
    public Waypoint waypoint;
    // Start is called before the first frame update
    void ParseWaypointData()
    {
        if(waypoint != null)
            GameManager.instance.AddWaypoint(gameObject, waypoint);
        else
            Debug.LogError("waypoint not defined in: "+ gameObject.name);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameManager.instance.onRequestObjcts += ParseWaypointData;
    }

    private void OnDestroy() {
        GameManager.instance.onRequestObjcts -= ParseWaypointData;
    }


}
