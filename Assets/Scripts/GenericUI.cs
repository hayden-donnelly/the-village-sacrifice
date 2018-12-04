using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericUI : MonoBehaviour 
{
	public void LoadScene(int sceneID)
	{
		SceneManager.LoadScene(sceneID);
	}

	public void ReloadCurrentScene()
	{
		SceneManager.LoadScene(GameState.currentSceneID);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
