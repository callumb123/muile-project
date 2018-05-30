using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class for focusing state. In this state the camera is zooming in on a given target, and changes state depending on what the target is, once it is done.*/
public class FocusingState : CameraState {

	private float speed;

	private GameObject cameraControlButtons;
	private Vector3 offset;
	private Transform target;
	RaycastHit collision;
	Terrain mull;

	public FocusingState(CameraStateController camera) : base(camera) {}

	public override void Init() {
		cameraControlButtons = GameObject.FindGameObjectWithTag ("CameraControlButtons");
		speed = camera.zoomSpeed;
		offset = camera.settlementOffset;
		target = camera.getTarget ();
		mull = GameObject.FindGameObjectWithTag ("Land").GetComponent<Terrain> ();

	}
	public override void OnStateEnter() {


		mull.treeDistance = 600f;


		ZoomHelper.setUIVisibility (cameraControlButtons.GetComponent<CanvasGroup>(), false);
		ZoomHelper.setMarkerVisibility (false);

	}

	public override void Tick() {
		Vector3 targetPosition = target.position - offset;
		// check how close we are to floor
		//move to floor while not being close
		if (!isNearFloor (10f) && !isNearTarget (targetPosition, 4f)) //TODO: MAKE ACTUAL (PUBLIC) VARIABLES INSTEAD OF NUMBERS
			camera.transform.position = Vector3.Lerp (camera.transform.position, targetPosition, Time.deltaTime * speed);
		else if (target.CompareTag ("Settlement")) {
			camera.SetState (new FocusedState (camera));
		} else {
			camera.SetState (new ControlledState (camera));
		}
		camera.transform.LookAt(target.position); //adds sick loopdeloops


	}

	public override void OnStateExit() {
		camera.setHeight (collision.distance);
	}

	/* checks if the camera is currently near a collider directly below it*/
	bool isNearFloor (float howNear)
	{
		Physics.Raycast (camera.transform.position, Vector3.down, out collision);
		return collision.distance <= howNear;
	}

	/*Checks if camera is currently near a given target*/
	bool isNearTarget (Vector3 targetPosition, float howNear)
	{
		return Vector3.Distance (camera.transform.position, targetPosition) <= howNear;
	}
}
