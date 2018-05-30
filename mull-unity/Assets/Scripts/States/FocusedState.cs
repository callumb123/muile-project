using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Class for focused state. In this state the camera is rotated a settlement that has been focused on, pedestal style */
public class FocusedState : CameraState {
	private CanvasGroup infoBox;
	private Transform target;
	float speed;
	private CanvasGroup backButton;

	public FocusedState(CameraStateController camera): base(camera) {}

	public override void Init() {
		backButton = GameObject.FindGameObjectWithTag ("BackButton").GetComponent<CanvasGroup> ();
		infoBox = GameObject.FindGameObjectWithTag ("INFOBOX").GetComponent<CanvasGroup> ();
		target = camera.getTarget ();
		speed = camera.turnSpeed;
	}
	public override void OnStateEnter() {
		
		ZoomHelper.setUIVisibility(infoBox, true);
		ZoomHelper.setUIVisibility (backButton, true);
	}

	public override void Tick() {
		//repeatedly look at settlement
		camera.transform.LookAt(target.position);

		//rotates around settlement when mouse is dragged
		if (Input.GetMouseButton(Mouse.LEFT_CLICK) || Input.GetMouseButton(Mouse.RIGHT_CLICK))
		{
			float cameraVelocity = Input.GetAxis("Mouse X") * speed;
			camera.transform.RotateAround(target.position, Vector3.up, cameraVelocity);
			groundCollisionCheck();
		
		}

	}



	/* checks camera height above ground and prevents clipping by maintaining height */
	private void groundCollisionCheck () {
		RaycastHit groundCollision;
		Physics.Raycast(camera.transform.position, Vector3.down, out groundCollision);

		if (groundCollision.distance != camera.getHeight()) {//if camera is not at height set on focus, move towards cameraHeight
				camera.transform.position = new Vector3 (camera.transform.position.x,
				Mathf.Lerp(camera.transform.position.y, groundCollision.point.y + camera.getHeight(), Time.deltaTime * 10),
				camera.transform.position.z);
		}
	}
}
