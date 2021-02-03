using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour
{
    public GameObject FadePanal;

    private void Start()
    {
        if(FadePanal != null)
        {
            FadePanal.SetActive(false);
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex));
        //GameObject.Find("PlayerInfo").GetComponent<PlayerInfo>().ResetValues();

    }

    public void NextLevel()
    {
        //SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1)%SceneManager.sceneCountInBuildSettings);
        StartCoroutine(FadeEffect(SceneManager.GetActiveScene().buildIndex+1) );
    }

    IEnumerator FadeEffect(int SceneToLoad)
    {
        if(FadePanal != null)
        {
            FadePanal.SetActive(true);

            for (int i = 0; i < 100; i++)
            {
                FadePanal.GetComponent<CanvasGroup>().alpha = (float)i * 0.01f;
                yield return new WaitForSecondsRealtime(0.01f);

            }

            SceneManager.LoadScene(SceneToLoad % SceneManager.sceneCountInBuildSettings);
        }
    }
}
