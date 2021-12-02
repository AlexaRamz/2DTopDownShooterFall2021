using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuManager : MonoBehaviour
{
    public void onClickPlayGame()
	{
		GameStateManager.PlayGame();
	}

	public void onClickQuitGame()
	{
		Application.Quit();
	}
}
