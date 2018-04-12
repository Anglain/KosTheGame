using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour {

	[SerializeField] private GameObject go;

	private Collider2D goCollider;

	private void Awake() {
		goCollider = go.GetComponent<Collider2D>();
	}

	// Use this for initialization
	private void Start() {
		Input.multiTouchEnabled = false;
	}

	// Update is called once per frame
	private void Update() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetButton("Fire1")) {
			if (go.activeSelf == true && Physics2D.Raycast(mousePosition, mousePosition, 0).collider == goCollider) {
				go.SetActive(false);
			}
		} else {
			if (go.activeSelf == false) {
				go.SetActive(true);
			}
		}
	}
}
