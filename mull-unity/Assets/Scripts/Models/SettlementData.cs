using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettlementData
{
	public string headname;
	public string anglicised;
	public string grid_ref;
	public string extent;
	public string eastings;
	public string northings;
	public string gaelic_trans;
	public string english_trans;
	public string lang_of_origin;
	public string certainty;
	public string categories;
	public string gaelic_desc;
	public string english_desc;
	public string slug;

	public override string ToString() {
		return "Settlement " + headname + " is at grid ref " + grid_ref + ", has gaelic translation " + gaelic_trans + " and categories " + categories + "\n";

	}

}
