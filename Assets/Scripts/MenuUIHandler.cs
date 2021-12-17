using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI playerNameInputField;

    public void StartGame()
	{
		GameManager.Instance.PlayerName = playerNameInputField.text;

		SceneManager.LoadScene(1);
	}

	public void ExitApplication()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}
}
