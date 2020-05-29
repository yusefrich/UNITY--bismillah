using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Dictionary <GameObject, Waypoint> waypoints = GameManager.instance.RequestObjcts();

            foreach (KeyValuePair <GameObject, Waypoint> waypoint in waypoints)
            {
                Debug.Log(waypoint.Key.transform.position);
            }
        }
    }
}