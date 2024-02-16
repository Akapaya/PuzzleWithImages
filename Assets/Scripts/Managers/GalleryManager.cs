using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    #region Settings
    [SerializeField] private Image _splashArt;
    [SerializeField] private GameObject _splashArtPanel;
    [SerializeField] private GameObject _blurSprite;

    #endregion
    private int _indexImage;

    #region Delegates
    public delegate void SetImageEvent(int index);
    public static SetImageEvent SetImageHandle;
    #endregion


    #region StartMethods
    private void OnEnable()
    {
        SetImageHandle += SetImage;
    }

    private void OnDisable()
    {
        SetImageHandle -= SetImage;
    }
    #endregion

    #region Images Methods
    public void SetImage(int index)
    {
        _splashArtPanel.SetActive(true);
        _indexImage = index;
        _splashArt.sprite = ImageManager.Instance.SplashSprites[_indexImage];
    }

    public void NextImage()
    {
        if((_indexImage + 1) < ImageManager.Instance.SplashSprites.Count)
        {
            _indexImage++;
            _splashArt.sprite = ImageManager.Instance.SplashSprites[_indexImage];
        }
        ActivateOrDeactivateBlurPanel();
    }

    public void PreviousImage()
    {
        if((_indexImage - 1) >= 0) 
        {
            _indexImage--;
            _splashArt.sprite = ImageManager.Instance.SplashSprites[_indexImage];
        }
        ActivateOrDeactivateBlurPanel();
    }

    private void ActivateOrDeactivateBlurPanel()
    {
        if (SaveManager.LevelsBlock[_indexImage] == true)
        {
            _blurSprite.SetActive(true);
        }
        else
        {
            _blurSprite.SetActive(false);
        }
    }
    #endregion
}