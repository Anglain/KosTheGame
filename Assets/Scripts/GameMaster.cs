using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StoneColor
{
	Default, LightBlue, Yellow, Red, Blue
}

public class GameMaster : MonoBehaviour
{
	[HideInInspector] public static List<ColorGetter> stones;
	[HideInInspector] public LevelLoader ll;
	public static GameMaster gm;
	[Space(5)]
	[Header("Brush graphics")]
	public SpriteRenderer brushSr;
	public Sprite lightBlueBrush;
	public Sprite yellowBrush;
	public Sprite redBrush;
	public Sprite blueBrush;

	[Space(10)]
	[Header("Win canvas")]
	public Canvas winCanvas;

	public static int winCondition;
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

		if (brushSr == null) Debug.LogError("No SpriteRenderer component of the brush found attached to this gameObject! [GAME_MASTER.CS]");
		if (winCanvas == null) Debug.LogError("No Canvas found attached to the winCanvas variable of this gameObject! [GAME_MASTER.CS]");
		else winCanvas.enabled = false;

		ll = GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>();
		if (ll == null) Debug.LogError("No LevelLoader object found in the scene! [GAME_MASTER.CS]");
	}

	void Start()
	{
		Input.multiTouchEnabled = false;
		currentBrushColor = StoneColor.LightBlue;
		winCondition = stones.Count + 1;
	}

	void Update()
	{
		if (winCondition == 0)
		{
			ColorPicker.pickersEnabled = false;
			winCanvas.enabled = true;
		}
	}

	public void ChangeScene(int sceneIndex)
	{
		ll.LoadScene(sceneIndex);
	}
}
