using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementLog : MonoBehaviour {

	private List<SettlementInformation> foundSettlements = new List<SettlementInformation>();
	private int foundSettlementCount = 0;

	public int getFoundSettlementCount() {
		return foundSettlementCount;
	}

	public void updateFoundSettlementCount() {
		foundSettlementCount++;
	}

	public List<SettlementInformation> getFoundSettlements() {
		return foundSettlements;
	}

	public void addToFoundSettlements(SettlementInformation settlement) {
		foundSettlements.Add (settlement);
	}
}
