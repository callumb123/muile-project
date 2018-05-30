using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour {

	Text statusText;
	CanvasGroup statusGroup;

	[SerializeField]
	private float screenTime = 3f;
	float timer;
	bool canDiscover = true;

	// Use this for initialization
	void Awake () {
		statusText = GetComponent<Text> ();
		statusGroup = GetComponent<CanvasGroup> ();
		timer = screenTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= screenTime) {
			ZoomHelper.setUIVisibility (statusGroup, false);

		} else {
			timer += Time.deltaTime;
		}
	}

	public void setStatus(string status, Color color) {
		statusText.text = status;
		statusText.color = color;
		timer = 0f;
		ZoomHelper.setUIVisibility (statusGroup, true);
	}

	public void setDiscovered(SettlementInformation settlement, Color color) {
		setStatus (settlement.headname, color);
	}
	
	public void setTimer(float timeToStay) {
		screenTime = timeToStay;
	}

	public void setAnswer(SettlementInformation settlement) {
		setStatus ("Answer: " + settlement.headname, statusText.color);
	}
	
	public void setCanDiscover(bool canDisc) {
		canDiscover = canDisc;
	}
	
	public bool getCanDiscover() {
		return canDiscover;
	}
}
