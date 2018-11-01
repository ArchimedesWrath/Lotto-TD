using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	//private float scrollSpeed = 5f;
	private float panBorderThickness = 8f;
	private float minY = 5f;
	private float maxY = 10f;
	private bool moveCamera = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("y")) moveCamera = !moveCamera;
		if (!moveCamera) return;
		// We are going to check for input in two ways: 
		// Keyboard input and Mouse position
		// TODO: Set a clamp for camera movement on the x-axis and z-axis.
		if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = this.transform.position;

		pos.y -= scroll * 1000 * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		transform.position = pos;
	}
}
