using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGetter : MonoBehaviour {

	[SerializeField] private ColorPicker cp;
	[SerializeField] private Transform colorSprite;

	private Color requiredColor;
	private Collider2D col;
	private bool active = true;

	private void Awake() {
		col = GetComponent<Collider2D>();

		if (col == null) {
			Debug.LogError("No Collider2D component found attached to this game object! [COLOR_GETTER.CS]");
		}
		
		if (colorSprite == null) {
			Debug.LogError("No color image found in children of this game object! [COLOR_GETTER.CS]");
		} else {
			colorSprite.gameObject.SetActive(false);
		}

		if (cp == null) {
			Debug.LogError("No Color Picker component attached to the script! [COLOR_GETTER.CS]");
		}

		requiredColor = cp.pickerColor;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetButtonDown("Fire1") 
			&& GameMaster.gm.touchColorState == requiredColor 
			&& Physics2D.Raycast(mousePosition, mousePosition, 0).collider == col
			&& active) {

			colorSprite.gameObject.SetActive(true);
			active = false;
		}
	}
}
