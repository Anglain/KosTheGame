using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	public Color touchColorState = Color.white;

	private void Awake() {
		if (gm == null) {
			gm = this;
		}
		if (gm != this) {
			Destroy(gm.gameObject);
		}
	}
}
