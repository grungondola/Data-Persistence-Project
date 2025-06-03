using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartNew()
    {
        GameManager.Instance.PlayerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
