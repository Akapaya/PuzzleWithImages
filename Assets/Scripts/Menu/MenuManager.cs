using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _prefabButton;
    [SerializeField] private Transform _viewPlayTransform;
    [SerializeField] private Transform _viewGalleryTransform;
    #endregion

    #region Start Methods
    private void Start()
    {
        InstantiateLevelsButtons();
        InstantiateGalleryButtons();
    }
    #endregion

    #region Instantiate Methods
    void InstantiateLevelsButtons()
    {
        for(int i = 0; i < ImageManager.Instance.SplashSprites.Count; i++)
        {
            GameObject spriteFab = Instantiate(_prefabButton, _viewPlayTransform.position, Quaternion.identity);

            spriteFab.transform.SetParent(_viewPlayTransform);

            spriteFab.GetComponent<MenuButtons>().IniciateToLevel(ImageManager.Instance.SplashSprites[i], i);
        }
    }

    void InstantiateGalleryButtons()
    {
        for (int i = 0; i < ImageManager.Instance.SplashSprites.Count; i++)
        {
            GameObject spriteFab = Instantiate(_prefabButton, _viewGalleryTransform.position, Quaternion.identity);

            spriteFab.transform.SetParent(_viewGalleryTransform);

            spriteFab.GetComponent<MenuButtons>().IniciateToGallery(ImageManager.Instance.SplashSprites[i], i);
        }
    }
    #endregion

    #region CloseApp
    public void CloseApp()
    {
        Application.Quit();
    }
    #endregion
}