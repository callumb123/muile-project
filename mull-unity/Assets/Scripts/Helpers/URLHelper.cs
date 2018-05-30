using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Basic class to pull the url being used from the current context */

public static class URLHelper {

	public static string GetCurrentURL() {
		if (Application.absoluteURL.Length > 0) {
			var uri = new System.Uri (Application.absoluteURL); //get url of whatever page we're running in (note: will not work if endpoint is not on same url as client)
			return uri.GetLeftPart (System.UriPartial.Authority) + "/"; //strip out the bit saying "map"
		} else {
			return "http://localhost:8000/";
		}
	}
}
