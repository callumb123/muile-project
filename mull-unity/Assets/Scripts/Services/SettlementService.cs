using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Class to pull settlements from server */
public class SettlementService {
	string url = URLHelper.GetCurrentURL();
	string settlementEndPoint = "settlement_api";
	SettlementData[] settlements_fetched;
	public bool isFetched = false;


	/* Fetches settlement data from server. Pass a callback function in order to do things with said settlement data */
	public IEnumerator RequestSettlementData(System.Action<SettlementData[]> callback) {
		using (WWW www = new WWW (url + settlementEndPoint)) {
			yield return www;
			string jsonString = JsonHelper.FixJson (www.text);
			settlements_fetched = JsonHelper.FromJson<SettlementData> (jsonString);
			isFetched = true;
			callback (settlements_fetched);
		}


	}

	/* Allows settlement data to be fetched */
	public SettlementData[] getSettlements() {
		if (isFetched)
			return settlements_fetched;
		else
			return null;
	}


}
