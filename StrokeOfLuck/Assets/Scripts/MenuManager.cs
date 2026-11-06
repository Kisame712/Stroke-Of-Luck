using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;

    [SerializeField] private Button optionsButton;

    [SerializeField] private Button exitButton;

    [SerializeField] private Button backButton;

    [SerializeField] private GameObject mainMenuParent;
    [SerializeField] private GameObject optionsMenuParent;

    [SerializeField] private float delayTime;
    private void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            StartCoroutine(DelayedCall(delayTime, PlayButtonAction));
        });

        optionsButton.onClick.AddListener(() =>
        {
            StartCoroutine(DelayedCall(delayTime, OptionsButtonAction));
        });

        backButton.onClick.AddListener(() =>
        {
            StartCoroutine(DelayedCall(delayTime, BackButtonAction));
        });

        exitButton.onClick.AddListener(() =>
        {
            StartCoroutine(DelayedCall(delayTime, ExitButtonAction));
        });
    }


    private IEnumerator DelayedCall(float delayTime, Action delayedFunction)
    {
        yield return new WaitForSeconds(delayTime);
        delayedFunction();

    }

    private void PlayButtonAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OptionsButtonAction()
    {
        mainMenuParent.SetActive(false);
        optionsMenuParent.SetActive(true);
    }

    private void BackButtonAction()
    {
        mainMenuParent.SetActive(true);
        optionsMenuParent.SetActive(false);
    }

    private void ExitButtonAction()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    
    }
}
