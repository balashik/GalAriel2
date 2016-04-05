using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    Transform targetTransform;
    [SerializeField]
    float distance;
    [SerializeField]
    float height;

    Transform selfTransform;

    void Start()
    {
        selfTransform = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        selfTransform.position = new Vector3(targetTransform.position.x, targetTransform.position.y + height, targetTransform.position.z  - distance);
        selfTransform.rotation = targetTransform.rotation;
        selfTransform.LookAt(targetTransform);
        
    }
}
