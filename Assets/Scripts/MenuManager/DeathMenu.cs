using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;
    public Button pauseButton;

    private int activeScene;

    private float _gameTime;

    public static event Action OnDeath;

    void Start()
    {
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
        activeScene = SceneManager.GetActiveScene().buildIndex;
        FindTarget.OnPlayerTouch += LoseGame;
        _gameTime = 0f;
    }

    public void LoseGame()
    {
        //if(pauseButton != null)
        //    pauseButton.gameObject.SetActive(false);
        //deathMenu.SetActive(true);
        OnDeath?.Invoke();
        //Time.timeScale = 0f;
        RestartGame();
    }

    public void RestartGame()
    {
        OnDeath?.Invoke();

        StartCoroutine(RestartLevelAfterDelay());
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator RestartLevelAfterDelay()
    {
        // Ждем нужное количество времени
        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        FindTarget.OnPlayerTouch -= LoseGame;
    }
}
