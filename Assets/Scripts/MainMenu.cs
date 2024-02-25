using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private bool istitleScreen = true;
    public GameObject titleScreen;
    public GameObject MenuScreen;
    public GameObject LoadingScreen;
    public Slider slider;

    private void Update()
    {
        if (istitleScreen && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(loadMenu());
        }
    }

    public void NewGame()
    {
        StartCoroutine(LoadAsynchronously("Brunch"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsynchronously(string SceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        LoadingScreen.SetActive(true);
        MenuScreen.SetActive(false);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    private IEnumerator loadMenu()
    {
        titleScreen.GetComponent<Animator>().Play("TitleScreenFadeOut");
        yield return new WaitForSeconds(0.6f);
        titleScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }
}
