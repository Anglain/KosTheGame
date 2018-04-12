using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker: MonoBehaviour {

	public Color pickerColor;

	private Collider2D col;

	private void Awake() {
		col = GetComponent<Collider2D>();

		if (col == null) {
			Debug.LogError("No Collider2D component found attached to this game object! [COLOR_PICKER.CS]");
		}
	}

	// Update is called once per frame
	private void Update() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetButtonDown("Fire1") && Physics2D.Raycast(mousePosition, mousePosition, 0).collider == col) {
			if (GameMaster.gm.touchColorState != pickerColor) {
				GameMaster.gm.touchColorState = pickerColor;
				Camera.main.backgroundColor = pickerColor;
			}
		}
	}
}
