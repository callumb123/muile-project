using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

	bool isGaelic;


	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	public void setIsGaelic(bool value) {
		isGaelic = value;
	}

	public bool getIsGaelic() {
		return isGaelic;
	}

	public void enterMull() {
		SceneManager.LoadSceneAsync("MULL");
	}
}
