using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class for Unfocusing State. A transitionary state - the camera is slowly movedback to the unfocused state and when it's done the state changes*/
public class UnfocusingState : CameraState {

	private CanvasGroup infoBox;
	private CanvasGroup backButton;
	float speed;
	Terrain mull;
	GameObject hiker;

	public UnfocusingState(CameraStateController camera) : base(camera) {}

	public override void Init() {
		infoBox = GameObject.FindGameObjectWithTag ("INFOBOX").GetComponent<CanvasGroup> ();
		backButton = GameObject.FindGameObjectWithTag ("BackButton").GetComponent<CanvasGroup> ();
		speed = camera.zoomSpeed;
		mull = GameObject.FindGameObjectWithTag ("Land").GetComponent<Terrain> ();
		hiker = GameObject.FindGameObjectWithTag ("HikerIcon");
	}


	public override void OnStateEnter() {
		
		mull.treeDistance = 2f;


		ZoomHelper.setUIVisibility(infoBox, false);
		ZoomHelper.setUIVisibility (backButton, false);

		camera.transform.rotation = camera.getLastRotation();

		hiker.transform.rotation = hiker.GetComponent<OnHoverHiker> ().initialRotation;

	}

	public override void Tick() {
		camera.transform.position = Vector3.Lerp(camera.transform.position, camera.getLastPosition(), Time.deltaTime * speed);
		//once we're here, we're unfocused
		if (Vector3.Distance (camera.transform.position, camera.getLastPosition ()) < 4f) {
			camera.SetState (new UnfocusedState (camera));
		} 
	}

	public override void OnStateExit() {
		ZoomHelper.setMarkerVisibility(true);
	}


}
