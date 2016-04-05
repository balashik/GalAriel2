using UnityEngine;
using System.Collections;

public class WaypointVisualizer : MonoBehaviour
{

    [SerializeField]
    Sprite image_indicator;         //the image of the waypoint indicator.

    NavigationManager navManager;

    // Use this for initialization
    void Start ()
    {
        navManager = GetComponent<NavigationManager>();
	}


    //fix, move to update registry.
    void LateUpdate()
    {

    }
}
