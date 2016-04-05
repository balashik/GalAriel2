using UnityEngine;
using System.Collections;

public class ShipInput : MonoBehaviour 
{

		[SerializeField] float speed;
	    [SerializeField] float tilt;
         float hInput;
         float vInput;
         float aInput;
         float acceleration = 0;
         float sMax = 10;
         float sMin = -10;

	    
		Rigidbody _rb;


		void Start()
		{
			_rb = GetComponent<Rigidbody>();
		}

		
		void FixedUpdate ()
		{
        /*if (Input.GetKey(KeyCode.Space)) {
            aInput = Time.time * speed;
        }*/
        aInput = Mathf.Clamp(Input.GetAxis("Jump")*Time.time, sMin, sMax);

            hInput = Input.GetAxis ("Horizontal");
			vInput = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (hInput, vInput, aInput);
			//_rb.velocity = movement * speed;

			_rb.AddForce(movement * speed, ForceMode.Acceleration);
			
			_rb.rotation = Quaternion.Euler (_rb.velocity.y * - tilt, 0.0f, _rb.velocity.x * -tilt);
		}

}
