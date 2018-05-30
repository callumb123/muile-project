using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* State that handles logic in the answering stage - displays correct, incorrect answer */
public class AnsweredState : CameraState {

	GameObject guess;
	SettlementInformation answer;
	QuestionController qc;
	ModifyColour guessColour;
	ModifyColour answerColour;
	InfoFieldContainer infoContainer;
	CanvasGroup answerGroup;
	CanvasGroup questionGroup;
	CanvasGroup answersLeftGroup;
	AudioSource[] guessSounds;

	GameObject options;
	bool isGaelic;
	Text moveOn;

	
	public AnsweredState(CameraStateController camera) : base(camera) {}

	public override void Init() {
		answerGroup = GameObject.FindGameObjectWithTag ("AnswerUI").GetComponent<CanvasGroup> ();
		questionGroup = GameObject.FindGameObjectWithTag ("Question").GetComponent<CanvasGroup> ();
		answersLeftGroup = GameObject.FindGameObjectWithTag ("AnswersLeft").GetComponent<CanvasGroup> ();
		infoContainer = GameObject.FindGameObjectWithTag ("God").GetComponent<InfoFieldContainer> ();
		qc = GameObject.FindGameObjectWithTag ("God").GetComponent<QuestionController> ();
		guessSounds = answerGroup.GetComponents<AudioSource> ();
		answer = qc.getAnswer ().GetComponent<SettlementInformation> ();
		guess = qc.getCurrentGuess();
		moveOn = GameObject.FindGameObjectWithTag ("MoveOn").GetComponent<Text> ();

		guessColour = guess.GetComponentInChildren<ModifyColour> ();
		answerColour = answer.GetComponentInChildren<ModifyColour> ();

		options = GameObject.FindGameObjectWithTag ("Options");
		isGaelic = options != null ? options.GetComponent<OptionsManager> ().getIsGaelic () : false;
	}
	public override void OnStateEnter() {
		
		AudioSource correctGuessSound = guessSounds[0];
		AudioSource incorrectGuessSound = guessSounds[1];


		guessColour.guessedColour ();
		answerColour.correctColour ();

		if (isGaelic) {
			infoContainer.answerText.text = "An Fhreagairt Cheart: " + answer.headname;
			infoContainer.guessText.text = "Do Fhreagairt: " + guess.GetComponent<SettlementInformation> ().headname;
			moveOn.text = "Air aghaidh";
		} else {
			infoContainer.answerText.text = "The correct answer: " + answer.headname;
			infoContainer.guessText.text = "Your answer: " + guess.GetComponent<SettlementInformation> ().headname;
			moveOn.text = "Continue";
		}

		if (qc.isCorrect ()) {
			if (isGaelic) {
				infoContainer.answerStatus.text = "Ceart!";
			} else {
				infoContainer.answerStatus.text = "Correct!";
			}
			infoContainer.answerStatus.color = Color.green;
			correctGuessSound.Play();
		} else {
			if (isGaelic) {
				infoContainer.answerStatus.text = "Ceàrr!";
			} else {
				infoContainer.answerStatus.text = "Wrong!";
			}
			infoContainer.answerStatus.color = new Color32(255, 53, 53, 255);
			incorrectGuessSound.Play();
		}

		ZoomHelper.setUIVisibility (answerGroup, true);
	}

	public override void Tick() {

	}

	public override void OnStateExit() {
		guessColour.reset();
		answerColour.reset ();
		ZoomHelper.setUIVisibility (answerGroup, false);
		ZoomHelper.setUIVisibility (questionGroup, false);
		ZoomHelper.setUIVisibility (answersLeftGroup, false);
	}

}
