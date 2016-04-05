using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{

    [SerializeField]
    uint checkPointIndex;


    #region Properties
    public uint Index
    {
         get { return checkPointIndex; }
         set { checkPointIndex = (value >= 0) ? value : checkPointIndex; }
    }
    #endregion
}
