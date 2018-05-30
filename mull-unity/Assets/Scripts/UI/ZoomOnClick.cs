using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


/** Small script to handle behaviour on any map icon
 *  **/
public class ZoomOnClick : MonoBehaviour {

	Toggle thisToggle;// Current object being used TODO: change from toggle to buttons
	CameraStateController cc; //Camera controller - used to force zoom on click
	AudioSource zoomSound; //Sound that players when marker or player is clicked
	QuestionController qc;
	Transform target;


	void Awake() {
		//Finding and initialising variables containing components I need to access
		zoomSound = GetComponent<AudioSource> ();
		qc = GameObject.FindGameObjectWithTag ("God").GetComponent<QuestionController> ();
		thisToggle = GetComponent<Toggle> ();
		cc = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraStateController>();
	}

	void Start() {
		

		//on Click, zoom in, stop displaying markers and display the panel
		thisToggle.onValueChanged.AddListener (delegate {
			target = transform.parent.parent;
			if (cc.GetState().GetType() == typeof(UnfocusedState)) {
				zoomSound.Play();
				setTextData();
				cc.focus(target);
			}else if (cc.GetState().GetType() == typeof(QuestionState) && gameObject.CompareTag("SettlementMarker")) {
				qc.answerQuestion(target.gameObject);

			}

		});
	}

	//TODO: implement button to swap between gaelic + english translations
	//TODO: add labels and prettify ui
	/**A boilerplate function to assign the current clicked settlement details to each and every ui element **/
	public void setTextData() {

		SettlementInformation allInfo = transform.root.GetComponent<SettlementInformation> ();
		if (allInfo == null)
			return;
		InfoFieldContainer fields = GameObject.FindGameObjectWithTag ("God").GetComponent<InfoFieldContainer> ();

		fields.headnameOriginal.text = allInfo.headname;
		fields.slug.text = allInfo.slug;
	}



}
