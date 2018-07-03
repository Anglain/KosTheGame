using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

	[Space(5)]
	[Header("Music")]
	public AudioClip mainMenuTheme;
	public AudioClip gameplayTheme;

	[Space(10)]
	[Header("Sounds")]
	public AudioClip applaudSound;
	public AudioClip stoneSuccessfullSound;

	[HideInInspector] public static AudioController ac;

	private AudioSource musicSource;
	private AudioSource efxSource;
	private int currentSceneIndex = -1;

	void Awake()
	{
		if (ac == null) ac = this;
		if (ac != this) Destroy(this.gameObject);

		AudioSource[] audioSources = GetComponents<AudioSource>();
		if (audioSources == null) Debug.LogError("No AudioSource components found attached to this gameObject! [AUDIO_CONTROLLER.CS]");
		if (audioSources.Length == 1) Debug.LogError("Only 1 AudioSource component found! (should be 2) [AUDIO_CONTROLLER.CS]");

		musicSource = audioSources[0];
		Debug.Log(musicSource);
		efxSource = audioSources[1];
		Debug.Log(efxSource);

		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		SetMusicClip(SceneManager.GetActiveScene().buildIndex);
	}

	void Update()
	{
		SetMusicClip(SceneManager.GetActiveScene().buildIndex);
	}

	void SetMusicClip(int sceneIndex)
	{
		if (currentSceneIndex != sceneIndex)
		{
			if (sceneIndex == 0)
			{
				musicSource.Stop();
				efxSource.Stop();
				musicSource.clip = mainMenuTheme;
				musicSource.Play();
			}
			else
			{
				musicSource.Stop();
				efxSource.Stop();
				musicSource.clip = gameplayTheme;
				musicSource.Play();
			}

			currentSceneIndex = sceneIndex;
		}
	}

	public void PlayApplaud()
	{
		efxSource.Stop();
		efxSource.clip = applaudSound;
		efxSource.Play();
	}

	public void PlayStoneSuccessfull()
	{
		efxSource.Stop();
		efxSource.clip = stoneSuccessfullSound;
		efxSource.Play();
	}
}
