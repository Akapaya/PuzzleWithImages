using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageManager : MonoBehaviour
{
    #region Variables
    public int Index;
    public List<Sprite> SplashSprites;
    public Material PieceMaterial;
    #endregion

    #region Static Variables
    public static ImageManager Instance;
    #endregion

    #region Start Methods
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region Setter Methods
    public void SetImageToPlay(int index)
    {
        this.Index = index;
        PieceMaterial.mainTexture = SplashSprites[index].texture;
    }
    #endregion
}