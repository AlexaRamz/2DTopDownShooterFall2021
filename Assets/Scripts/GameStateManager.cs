using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
	[SerializeField] private List<string> m_Levels = new List<string>();
	[SerializeField] private string m_TitleScreenName;

	public static GameStateManager m_instance;
	private static GAMESTATE m_GameState;

	enum GAMESTATE{
		MENU,
		PLAYING,
	}

	private void Awake()
	{
		//Create the instance
		if(m_instance == null)
		{
			m_instance = this;
			DontDestroyOnLoad(m_instance);
		}
		else
		{
			Destroy(this);
		}
	}

	public static void PlayGame()
	{
		m_GameState = GAMESTATE.PLAYING;
		if(m_instance.m_Levels.Count > 0)
		{
			SceneManager.LoadScene(m_instance.m_Levels[0]);
		}
	}
}
