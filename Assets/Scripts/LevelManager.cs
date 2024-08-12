using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log(gameObject.activeInHierarchy);
    }
    [SerializeField] float sceneLoadDelay = 2f;
    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("Game", sceneLoadDelay));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", sceneLoadDelay));
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
