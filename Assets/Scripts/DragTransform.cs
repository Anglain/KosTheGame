using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTransform : MonoBehaviour {

	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.yellow;
	private bool dragging = false;
	private float distance;
	private new SpriteRenderer renderer;

	private void Awake() {
		renderer = GetComponent<SpriteRenderer>();

		if (renderer == null) {
			Debug.LogError("No SpriteRenderer component found attached to this game object! [DRAG_TRANSFORM.CS]");
		}
	}

	void OnMouseDown() {
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp() {
		dragging = false;
	}

	void Update() {
		if (dragging) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}
