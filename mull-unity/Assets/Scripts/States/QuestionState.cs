using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* State that handles logic in the questioning stage - moves the camera to the correct position, sets everything up and triggers the questioning, etc */
public class QuestionState : CameraState {

	QuestionController questionController;
	public QuestionState(CameraStateController camera) : base(camera) {}
	private CanvasGroup player;
	private CanvasGroup questionGroup;
	private CanvasGroup answersLeftGroup;
	private Text questionText;
	private Text answersLeft;
	GameObject options;
	bool isGaelic;

	// Use this for initialization
	public override void Init() {
		options = GameObject.FindGameObjectWithTag ("Options");
		isGaelic = options != null ? options.GetComponent<OptionsManager> ().getIsGaelic () : false;
		questionController = GameObject.FindGameObjectWithTag ("God").GetComponent<QuestionController> ();
		player = GameObject.FindGameObjectWithTag ("HikerIcon").GetComponent<CanvasGroup> ();
		questionText = GameObject.FindGameObjectWithTag ("Question").GetComponent<Text> ();
		questionGroup = questionText.GetComponent<CanvasGroup> ();
		answersLeft = GameObject.FindGameObjectWithTag ("AnswersLeft").GetComponent<Text>();

		answersLeftGroup = answersLeft.GetComponent<CanvasGroup> ();

	}

	public override void OnStateEnter() {
		
		
		questionController.setCurrentQuestion();
		if (isGaelic) {
			questionText.text = questionController.getCurrentQuestion ().text_gaelic;
			answersLeft.text = "" + questionController.questionsLeftToAnswer() + " freagairtean ceart air fhàgail";
		} else {
			questionText.text = questionController.getCurrentQuestion ().text_english;
			answersLeft.text = "" + questionController.questionsLeftToAnswer() + " correct answers remaining!";

		} 

		camera.transform.position = camera.getBasePosition ();	
		ZoomHelper.setUIVisibility (questionGroup, true);
		ZoomHelper.setUIVisibility (answersLeftGroup, true);
		ZoomHelper.setUIVisibility (player, false);
	}
	public override void Tick() {
		if (questionController.getIsAnswered()) {
			camera.SetState (new AnsweredState (camera));
		}

	}

	public override void OnStateExit() {
		if (!questionController.isQuestionRemaining()) {
			ZoomHelper.setUIVisibility (player, true);
		}
	}
}
