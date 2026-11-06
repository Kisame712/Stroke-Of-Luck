using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using MoreMountains.Feedbacks;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;

    [SerializeField] private Button optionsButton;

    [SerializeField] private Button exitButton;

    [SerializeField] private Button backButton;

    [Header("Menus")]

    [SerializeField] private GameObject mainMenuParent;
    [SerializeField] private GameObject optionsMenuParent;

    [SerializeField] private float delayTime;


    [Header("Feedbacks")]

    [SerializeField] private MMF_Player optionsHoverFeedback;
    [SerializeField] private MMF_Player backHoverFeedback;
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
        optionsHoverFeedback.RestoreInitialValues();
        optionsHoverFeedback.StopFeedbacks();
        mainMenuParent.SetActive(false);
        optionsMenuParent.SetActive(true);
    }

    private void BackButtonAction()
    {
        backHoverFeedback.RestoreInitialValues();
        backHoverFeedback.StopFeedbacks();
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
