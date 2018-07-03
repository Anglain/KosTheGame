using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker: MonoBehaviour
{
	[HideInInspector] public static bool pickersEnabled = true;
	public StoneColor pickerColor;

	void Awake()
	{
		if (!pickersEnabled) pickersEnabled = true;
	}

	void OnMouseDown()
	{
		if (GameMaster.gm.currentBrushColor != pickerColor && pickersEnabled)
		{
			GameMaster.gm.currentBrushColor = pickerColor;
		}
	}
}
