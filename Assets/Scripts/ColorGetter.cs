using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGetter : MonoBehaviour {

	public Sprite stoneSimple;
	public Sprite stoneLightBlue;
	public Sprite stoneYellow;
	public Sprite stoneRed;
	public Sprite stoneBlue;
	public StoneColor trueColor;

	private bool blocked = false;
	private SpriteRenderer sr;
	private StoneColor _currentStoneColor;
	private StoneColor currentStoneColor
	{
		get
		{
			return _currentStoneColor;
		}

		set
		{
			_currentStoneColor = value;

			if (_currentStoneColor == StoneColor.Default)
			{
				sr.sprite = stoneSimple;
			}
			else if (_currentStoneColor == StoneColor.LightBlue)
			{
				sr.sprite = stoneLightBlue;
			}
			else if (_currentStoneColor == StoneColor.Yellow)
			{
				sr.sprite = stoneYellow;
			}
			else if (_currentStoneColor == StoneColor.Red)
			{
				sr.sprite = stoneRed;
			}
			else if (_currentStoneColor == StoneColor.Blue)
			{
				sr.sprite = stoneBlue;
			}

			if (_currentStoneColor == trueColor && !blocked)
			{
				blocked = true;
				GameMaster.winCondition--;
			}
		}
	}

	private void Awake()
	{
		if (GameMaster.stones != null)
		{
			GameMaster.stones.Add(this);
		}
		else
		{
			GameMaster.stones = new List<ColorGetter>();
		}

		sr = GetComponent<SpriteRenderer>();

		if (sr == null) Debug.LogError("No SpriteRenderer component found attached to this gameObject! [COLOR_GETTER.CS]");

		currentStoneColor = StoneColor.Default;
		blocked = false;
	}

	void OnMouseDown()
	{
		if (currentStoneColor != GameMaster.gm.currentBrushColor && !blocked)
			currentStoneColor = GameMaster.gm.currentBrushColor;
	}
}
