using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WinPoint : MonoBehaviour
{
    public string nextLevel;

    public static event Action OnWin;
    public GameObject endMenu;

    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Level5")
            {
                Time.timeScale = 0f;
                endMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 0f;
                OnWin?.Invoke();
                StartCoroutine(LoadNewSceneAfter());
            }   
        }
    }

    private IEnumerator LoadNewSceneAfter()
    {
        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }
}
