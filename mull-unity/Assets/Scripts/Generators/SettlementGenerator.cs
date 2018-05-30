using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Unfinished class to plot all points on map
TODO: Move into own gameobject */
public class SettlementGenerator : MonoBehaviour {
	[SerializeField]
	private GameObject settlementPrefab;
	private SettlementData[] settlementData;

	private SettlementService settlementService;


	void Awake() {
		settlementService = new SettlementService ();
		StartCoroutine (settlementService.RequestSettlementData (placeSettlements));

	}

	/*Handles fetching the settlement data from the web. Then attempts to place every settlement.
	Returns true if it works*/

	/* given an array of settlement data, places prefab settlements for each piece of data
	 */
	void placeSettlements(SettlementData[] settlementData) {
		this.settlementData = settlementData;
		for (int i = 0; i < settlementData.Length; i++) {
			placeSettlement (settlementData[i]);
		}
		ZoomHelper.setMarkerVisibility (false);
	}
	/* Given data on a settlement, places a settlement at its position and
	Does not place settlement if it's waaaay outside the map's bounds*/
	void placeSettlement (SettlementData settlementData)
	{
		string x = settlementData.eastings;
		string y = settlementData.northings;


		Vector2 gridReference = new Vector2 (float.Parse (x), float.Parse (y));
		float rayHeight = 1000f; //height to fire ray from
		RaycastHit settlementPosition;
		Vector2 islandPoint = ConversionHelper.GridReferenceToUnityCoords (gridReference); //converting world point to an island point

		//fire ray directly downwards from above the given point, place settlement where it lands
		Vector3 rayOrigin = new Vector3 (islandPoint.x, rayHeight, islandPoint.y);
		if (Physics.Raycast (rayOrigin, Vector3.down, out settlementPosition)) {
			GameObject placedSettlement = (GameObject)Instantiate(settlementPrefab, settlementPosition.point, Quaternion.identity);

			SettlementInformation settlementInfo = placedSettlement.GetComponent<SettlementInformation> ();
			settlementInfo.setSettlementInfo (settlementData);
            settlementModifier(placedSettlement, settlementData);
        }
	}

	/* Stores each value held in settlement inside the gameobject itself
    /* reads settlement data and uses to determine settlement colour and scale
     */
	private void settlementModifier(GameObject placedSettlement, SettlementData data)
    {

		placedSettlement.name = data.headname;


        GameObject settlementModel = placedSettlement.transform.GetChild(0).gameObject;

        float newScale = settlementModel.transform.localScale.x * checkScale(data.extent);
        settlementModel.transform.localScale += new Vector3(newScale, newScale, newScale);
    }

    /* sets settlement properties based on attributes retrieved from settlement data
     */
    private float checkScale(string scale)
    {
        switch (scale)
        {
            case "Two Pennylands":
                return 1;
            case "Pennyland":
                return 0.75f;
            case "Half-Pennyland":
                return 0.5f;
            default:
                return 0;
        }
    }

	public SettlementData[] getSettlements() {
		return settlementData;
	}

	public bool isFetched() {
		return settlementService.isFetched;
	}


}
