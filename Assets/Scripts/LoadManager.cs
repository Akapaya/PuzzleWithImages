using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private int _sceneIndex = 0;

    #region Delegate
    public delegate void LoadLevelEvent();
    public static LoadLevelEvent LoadLevelHandle;
    #endregion

    #region Start Methods
    private void OnEnable()
    {
        LoadLevelHandle += LoadScene;
    }

    private void OnDisable()
    {
        LoadLevelHandle -= LoadScene;
    }
    #endregion

    #region LoadScene
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
    #endregion
}