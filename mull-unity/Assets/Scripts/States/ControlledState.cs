using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/* Class for controlled state. In this state the camera is on the player - the player controller handles moving and looking around */
public class ControlledState : CameraState {

	Transform player;
	public ControlledState(CameraStateController camera) : base(camera) {}
	QuestionController qc;
	float timer;
	float totalTime = 3f;
	private CanvasGroup goingToQuizCanvas;
	private CanvasGroup discoveredCanvas;
	private Text goingToQuizText;
	private StatusController statusController;
	PlayerController playerController;
	GameObject options;
	bool isGaelic;

	/* Boilerplate setup - effectively the constructor for this script */
	public override void Init() {
		qc = GameObject.FindGameObjectWithTag ("God").GetComponent<QuestionController> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		statusController = GameObject.FindGameObjectWithTag ("Status").GetComponent<StatusController> ();
		discoveredCanvas = GameObject.FindGameObjectWithTag ("Status").GetComponent<CanvasGroup> ();
		goingToQuizCanvas = GameObject.FindGameObjectWithTag ("GoToQuiz").GetComponent<CanvasGroup> ();
		goingToQuizText = GameObject.FindGameObjectWithTag ("GoToQuiz").GetComponent<Text> ();
		playerController = player.GetComponent<PlayerController> ();
		options = GameObject.FindGameObjectWithTag ("Options");
		isGaelic = options != null ? options.GetComponent<OptionsManager> ().getIsGaelic () : false;

	}
	/* Initial code when entering state - move the camera to where the player is */
	public override void OnStateEnter() {
		camera.transform.position = player.position + Vector3.up * 4; //bodge to make camera be where player's eyes are
		camera.transform.SetParent (player);
		playerController.setIsControlled (true);

		timer = 0f;
	}

	/* Code happening on each frame -  handling case when player moves to quiz */
	public override void Tick() {
		if(qc.isQuizActive() && timer <= totalTime) {
			if(timer == 0f) {
				statusController.setCanDiscover(false);
				ZoomHelper.setUIVisibility(goingToQuizCanvas, true);
			}
			timer += Time.deltaTime;
			if (isGaelic) {
				goingToQuizText.text = "Ceistean ann an " + Math.Ceiling (totalTime - timer);
			} else {
				goingToQuizText.text = "Going to quiz in " + Math.Ceiling (totalTime - timer);
			}
		}
		else if(qc.isQuizActive() && timer > totalTime) {
			camera.SetState (new UnfocusingState (camera));
		}
	}

	public override void OnStateExit() {
		ZoomHelper.setUIVisibility(discoveredCanvas, false);
		ZoomHelper.setUIVisibility(goingToQuizCanvas, false);
		camera.transform.SetParent (null);
		playerController.setIsControlled (false);
		statusController.setCanDiscover(true);
	}

}
