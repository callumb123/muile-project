using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Class containing all code required for the Unfocused state. In this state, the camera can be moved to where the player right clicks, and zoomed with the scroll wheel*/
public class UnfocusedState : CameraState{



	private CanvasGroup cameraControlButtons;
	private QuestionController qc;

	public UnfocusedState(CameraStateController camera) : base(camera) {}

	public override void Init() {
		qc = GameObject.FindGameObjectWithTag ("God").GetComponent<QuestionController> ();
		cameraControlButtons = GameObject.FindGameObjectWithTag ("CameraControlButtons").GetComponent<CanvasGroup> ();
	}
	public override void OnStateEnter() {

		if (qc.isQuizActive()) {
			camera.SetState (new QuestionState (camera));
		}

		ZoomHelper.setUIVisibility (cameraControlButtons, true);
	}
	public override void Tick() {

	}

	public override void OnStateExit() {
		//stores where we were for when we come back to this state
		camera.updateLastPosition ();
		camera.updateLastRotation ();
	}




}
