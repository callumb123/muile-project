using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Class for handling pulling a question out, grabbing its answer and the attempted guess */
public class QuestionController : MonoBehaviour {

	[SerializeField]
	private int settlementThreshold = 5;
	[SerializeField]
	private int questionThreshold = 3;
	private int answeredQuestions = 0;


	private SettlementLog settlementLog;
	private Dictionary<string, List<QuestionData>> questionDict;
	bool isAnswered = false;
	QuestionData currentQuestion;
	GameObject currentGuess;
	GameObject answer;
	float distance;
	List<QuestionData> correctQuestions;
	CameraStateController cc;



	// Use this for initialization
	void Awake () {
		settlementLog = GetComponent<SettlementLog> ();
		//TODO: have this called way later (because coroutines)
		questionDict = GetComponent<QuestionGenerator> ().questionDict;
		correctQuestions = new List<QuestionData> ();
		cc = Camera.main.GetComponent<CameraStateController> ();
	}

	public QuestionData getCurrentQuestion() {
		return currentQuestion;
	}

	public void setCurrentQuestion() {
		List<QuestionData> possibleQuestions = chooseSettlement ();
		int choice = Random.Range (0, possibleQuestions.Count);

		currentQuestion = possibleQuestions [choice];

		isAnswered = false;

		//Keep doing until we find a question we've not answered correctly yet
		if (correctQuestions.Contains(currentQuestion)) {
			setCurrentQuestion();
		}
	}

	private List<QuestionData> chooseSettlement() {
		int count = settlementLog.getFoundSettlementCount ();
		int choice = Random.Range(0, count);
		string settlement = settlementLog.getFoundSettlements () [choice].headname;
		return questionDict [settlement];

	}

	public void answerQuestion(GameObject guess) {
		isAnswered = true;
		currentGuess = guess;
		answer = GameObject.Find (currentQuestion.answer);
		if (isCorrect()) {
			answeredQuestions++;
			correctQuestions.Add (currentQuestion);

		}
	}

	public bool getIsAnswered() {
		return isAnswered;
	}
		

	public GameObject getAnswer() {
		return answer;
	}

	public GameObject getCurrentGuess() {
		return currentGuess;
	}

	public bool isCorrect() {
		return currentGuess.GetComponent<SettlementInformation> ().headname == answer.GetComponent<SettlementInformation> ().headname;
	}

	public bool isQuestionRemaining() {
		return answeredQuestions < questionThreshold;
	}
	
	public int questionsLeftToAnswer() {
		return questionThreshold - answeredQuestions;
	}

	public void reset() {
		correctQuestions.Clear ();
		answeredQuestions = 0;
		settlementThreshold += 5;
	}

	public bool isQuizActive() {
		return settlementLog.getFoundSettlementCount () >= settlementThreshold;
	}

	public void moveOn() {
		if (isQuestionRemaining ()) {
			cc.SetState (new QuestionState (cc));
		} else {
			reset ();
			cc.SetState (new UnfocusedState (cc));
		}

	}
		
}
