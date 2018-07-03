using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StoneColor
{
	Default, LightBlue, Yellow, Red, Blue
}

public class GameMaster : MonoBehaviour
{
	[HideInInspector] public static GameMaster gm;

	public SpriteRenderer brushSr;
	public Sprite lightBlueBrush;
	public Sprite yellowBrush;
	public Sprite redBrush;
	public Sprite blueBrush;

	private StoneColor _currentBrushColor;
	public StoneColor currentBrushColor
	{
		get
		{
			return _currentBrushColor;
		}

		set
		{
			_currentBrushColor = value;

			if (_currentBrushColor == StoneColor.LightBlue)
			{
				brushSr.sprite = lightBlueBrush;
			}
			else if (_currentBrushColor == StoneColor.Yellow)
			{
				brushSr.sprite = yellowBrush;
			}
			else if (_currentBrushColor == StoneColor.Red)
			{
				brushSr.sprite = redBrush;
			}
			else if (_currentBrushColor == StoneColor.Blue)
			{
				brushSr.sprite = blueBrush;
			}
		}
	}

	void Awake()
	{
		if (gm == null) gm = this;
		if (gm != this)	Destroy(this.gameObject);

		Input.multiTouchEnabled = false;

		if (brushSr == null) Debug.LogError("No SpriteRenderer component of the brush found attached to this gameObject! [GAME_MASTER.CS]");
	}

	void Start()
	{
		currentBrushColor = StoneColor.LightBlue;
	}
}
