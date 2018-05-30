using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
	public string text_english;
	public string text_gaelic;
	public string answer;
	public int id;

	public override string ToString() {
		return "English Question " + text_english + ". Gaelic Question: " + text_gaelic + ". Answer is: " + answer + ". With id: " + id;
	}
}
