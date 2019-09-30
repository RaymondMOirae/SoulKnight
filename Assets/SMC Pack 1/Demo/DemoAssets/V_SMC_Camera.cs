using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visyde{
	public class V_SMC_Camera : MonoBehaviour {

		// The handler of crosshair sprites:
		public V_SMC_Handler crosshairHandler;

		// For the FPS mouse look:
		float rotationX = 0F;
		float rotationY = 0F;

		// For the raycasting function:
		Vector3 fireDirection;
		Vector3 firePoint;

		// Use this for initialization
		void Start () {
			// Lock and hide the cursor:
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		// Update is called once per frame
		void Update () {

			// FPS mouse look:
			rotationX += Input.GetAxis("Mouse X") * 2;
			rotationY -= Input.GetAxis("Mouse Y") * 2;
			Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
			transform.rotation = rotation;

			// Call raycast method:
			Hit ();
		}

		void Hit(){
			// Raycasting variables:
			RaycastHit hit;
			fireDirection = transform.TransformDirection(Vector3.forward) * 10;
			firePoint = transform.position;

			// Do raycasting:
			if (Physics.Raycast (firePoint, (fireDirection), out hit, Mathf.Infinity)) {
				// Change the color based on what object is under the crosshair:
				if (hit.transform.name == "Friendly") {
					crosshairHandler.ChangeColor (Color.green);
				} else if (hit.transform.name == "Enemy") {
					crosshairHandler.ChangeColor (Color.red);
				} else {
					crosshairHandler.ChangeColor (Color.white);
				}
			} else {
				crosshairHandler.ChangeColor (Color.white);
			}

			// Debug the ray out in the editor:
			Debug.DrawRay(firePoint, fireDirection, Color.green);
		}
	}
}
