using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker: MonoBehaviour
{
	public StoneColor pickerColor;

	void OnMouseDown()
	{
		if (GameMaster.gm.currentBrushColor != pickerColor)
		{
			GameMaster.gm.currentBrushColor = pickerColor;
		}
	}
}
