using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Container for all methods accessed by UI elements to control the camera */
public class CameraController : MonoBehaviour {

	[SerializeField]
	float moveAmount = 50f;
	[SerializeField]
	Vector4 limits = new Vector4(3800f, 3800f, 700f, 300f);
	[SerializeField]
	Vector2 zoomLimits = new Vector2(300f, 3500f);

	/* Moves the camera left by a given amount */
	public void moveLeft() {
		if (transform.position.x > limits.w) {
			transform.Translate(new Vector3(-1,0,0) * moveAmount);
		}
	}

	/* Moves the camera right by a given amount */
	public void moveRight() {
		if (transform.position.x < limits.y) {
			transform.Translate(new Vector3(1,0,0) * moveAmount);
		}
	}

	/* Moves the camera down by a given amount */
	public void moveDown() {
		if (transform.position.z > limits.z) {
			transform.Translate(new Vector3(0,-1,0) * moveAmount);
		}
	}

	/* Moves the camera up by a given amount */
	public void moveUp() {
		if (transform.position.z < limits.x) {
			transform.Translate(new Vector3(0,1,0) * moveAmount);
		}
	}

	/* Zooms the camera in by a given amount */
	public void zoomIn() {
		if (transform.position.y > zoomLimits.x) {
			transform.Translate(new Vector3 (0, 0, 1) * moveAmount);
		}
	}

	/* Zooms the camera out by a given amount */
	public void zoomOut() {
		if (transform.position.y < zoomLimits.y) {
			transform.Translate(new Vector3 (0, 0, -1) * moveAmount);
		}
	}

}
