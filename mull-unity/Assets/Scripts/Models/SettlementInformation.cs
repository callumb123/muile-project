using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Stores all relevant information on settlements*/
public class SettlementInformation : MonoBehaviour {
	public string headname = "jim";
	public string extent = "Pennyland";
	public string slug = "slug";
	private bool isFound = false;
	public bool isAnswer = false;

	SettlementLog settlementLog;

	void Awake() {
		settlementLog = GameObject.FindGameObjectWithTag ("God").GetComponent<SettlementLog> ();
	}

	/* Stores each value held in settlement inside the gameobject itself
	TODO: remove this step?*/
	public void setSettlementInfo(SettlementData settlementData) {
		headname = settlementData.headname;
		extent = settlementData.extent;
		slug = settlementData.slug;
	}

	public void findSettlement() {
		isFound = true;
		settlementLog.updateFoundSettlementCount ();
		settlementLog.addToFoundSettlements (this);

	}

	public bool getIsFound() {
		return isFound;
	}


}
