using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
 
public class LinkToWebsite : MonoBehaviour {

	Button thisButton;

	void Awake() {

		thisButton = GetComponent<Button> ();

		// do this when user clicks on button
		thisButton.onClick.AddListener (delegate {

			// get the settlement info
			InfoFieldContainer allInfo = GetComponent<InfoFieldContainer> ();

			string url;
			string settlementPage = "settlement/" + allInfo.slug.text;

			url = URLHelper.GetCurrentURL();

			// open the URL
			#if !UNITY_EDITOR
        	openWindow(url + settlementPage);
        	#endif
		});
	}

	[DllImport("__Internal")]
    private static extern void openWindow(string url);

}
