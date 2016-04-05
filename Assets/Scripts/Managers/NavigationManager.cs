using UnityEngine;
using System.Collections;

public class NavigationManager : MonoBehaviour
{
    [SerializeField]
    System.Collections.Generic.List<Waypoint> _waypoints;
    int _currWaypointIndex;
    [SerializeField]
    Waypoint _currentWaypoint;



    #region properties
    public Waypoint CurrentWaypoint {get { return _currentWaypoint; } }
    #endregion

    // Use this for initialization
    void Start()
    {
        FetchCheckPoints();
    }

    // Update is called once per frame
    /*	void Update () {

        }*/
    

    /// <summary>
    /// This method will fetch all the waypoints on the scene and return them.
    /// </summary>
    void FetchCheckPoints()
    {
        float startTime = Time.time;
        _waypoints = new System.Collections.Generic.List<Waypoint>();

        Waypoint[] checkps = FindObjectsOfType<Waypoint>();

        foreach (Waypoint c in checkps)
        {
            _waypoints.Add(c);
        }

        if (_waypoints.Count > 0)
        {
            _currWaypointIndex = 0;
            _currentWaypoint = _waypoints[_currWaypointIndex];
        }
        else Debug.LogError("Error in initializing the Checkpoints list");
        Debug.Log("<color=magenta>Total time for fetching : </color>" + (Time.time - startTime).ToString());

    }



    /// <summary>
    /// This method will increment the current waypoint index.
    /// </summary>
    void IncrementWaypoint()
    {
        //making sure we won't try to access something empty.
        if (_waypoints.Count == 0)
        {
            Debug.LogError("Could not increment the waypoint counter - the list is empty.");
                return;
        }
        _currWaypointIndex++;
        //makre sure we don't need to reset the count.
        if ( (_currWaypointIndex + 1) == _waypoints.Count)
            _currWaypointIndex = 0;
        

        _currentWaypoint = _waypoints[_currWaypointIndex];
    } 
}
