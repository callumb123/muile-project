using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Class pulls question models from Django Database and stores them in a dictionary to be used in Unity*/
public class QuestionGenerator : MonoBehaviour {

	string questionUrl;
	string questionEndPoint = "question_api";
	public Dictionary<string, List<QuestionData>> questionDict = new Dictionary<string, List<QuestionData>>();
	SettlementGenerator settlementGenerator;

	void Start() {
		
		//Adds 'question_api' to the end of whatever the current URL is
		questionUrl = URLHelper.GetCurrentURL();
		StartCoroutine(WaitForContentJSON(questionUrl + questionEndPoint));
		settlementGenerator = GetComponent<SettlementGenerator> ();
	}


	IEnumerator WaitForContentJSON(String givenUrl) {
		
		//Requests and gets the Json text stored at the given URL
		WWW www = new WWW(givenUrl);
		yield return www;
		string json_string = www.text;
		json_string = JsonHelper.FixJson(json_string);
		
		//Puts question data into array then list (simplier to add to in dict)
		QuestionData[] questionArray = JsonHelper.FromJson<QuestionData> (json_string);
		List<QuestionData> allQuestions = new List<QuestionData>(questionArray);
		yield return new WaitUntil (() => settlementGenerator.isFetched ());

		storeQuestions(allQuestions);
	}

	
	/* Takes in a list of questionData objects and adds them to a dictionary
      with headnames as keys and a list of QuestionData objects as values*/
	void storeQuestions(List<QuestionData> allQuestions) {
		//Gets the settlements that have already been obtained by PointGenerator
		SettlementData[] allSettlements = settlementGenerator.getSettlements();
		
		//Loops through all the settlements and then the list of questions
		for (int i = 0; i < allSettlements.Length; i++) {
			String settlementHeadname = allSettlements[i].headname;
			for(int j = 0; j < allQuestions.Count; j++) {
				/* If there are questions that have the current settlement as an answer, then
				   add it into the question dictionary */
				if(settlementHeadname == allQuestions[j].answer) {
					addQuestionToDict(settlementHeadname, allQuestions[j]);
				}
			}
		}
			
	}
	
	//Add the current question into the question dictionary
	void addQuestionToDict(String settlementHeadname, QuestionData currentQ) {
		
		/* If the dictionary doesn't have any questions associated with the settlement
		   then it adds it in along with an empty list */
		if(!questionDict.ContainsKey(settlementHeadname)) {
			questionDict.Add(settlementHeadname, new List<QuestionData>());
		}
		
		// Then adds the question onto the list associated with the settlement
		questionDict[settlementHeadname].Add(currentQ);
	}
	
}
