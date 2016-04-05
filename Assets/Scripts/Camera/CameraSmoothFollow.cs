using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour {

    [SerializeField]
    Transform target;
    [SerializeField]
    float distance = 5.0f;
    [SerializeField]
    float height = 4.0f;
    
    float rotationDamping = 3.0f;


    //we're tracking a rigidbody, using this to avoid jitter.
    void FixedUpdate()
    {
        if (!target)
            return;

       float  wantedRotationAngleSide = target.eulerAngles.y;
       float  currentRotationAngleSide = transform.eulerAngles.y;

       float wantedRotationAngleUp = target.eulerAngles.x;
       float  currentRotationAngleUp = transform.eulerAngles.x;

        currentRotationAngleSide = Mathf.LerpAngle(currentRotationAngleSide, wantedRotationAngleSide, rotationDamping * Time.deltaTime);

        currentRotationAngleUp = Mathf.LerpAngle(currentRotationAngleUp, wantedRotationAngleUp, rotationDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(currentRotationAngleUp, currentRotationAngleSide, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.LookAt(target);

        transform.position += transform.up * height;
    }
}