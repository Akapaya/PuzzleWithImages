using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    #region Settings
    [SerializeField] private Image _sprite;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _index;
    [SerializeField] private bool _blockable = false;
    [SerializeField] private Image _lock;
    [SerializeField] private Button _Button;
    #endregion

    #region Start Methods
    private void OnDisable()
    {
        _Button.onClick.RemoveAllListeners();
    }
    #endregion

    #region Gallery Methods
    public void IniciateToGallery(Sprite sprite, int index)
    {
        this._index = index;
        _text.text = "Level: " + (index.ToString());
        this._sprite.sprite = sprite;
        _Button.onClick.AddListener(SetImage);
        CheckBlockToGallery();
    }

    private void SetImage()
    {
        GalleryManager.SetImageHandle?.Invoke(_index);
    }

    void CheckBlockToGallery()
    {
        if (SaveManager.LevelsBlock[_index] == true)
        {
            _blockable = true;
            _lock.enabled = true;
            _Button.interactable = false;

            Color currentColor = _sprite.color;
            Color.RGBToHSV(currentColor, out float h, out float s, out float v);
            v *= 0.5f;
            v = Mathf.Clamp01(v);
            Color newColor = Color.HSVToRGB(h, s, v);
            _sprite.color = newColor;
        }
    }
    #endregion

    #region Play Methods
    public void IniciateToLevel(Sprite sprite, int index)
    {
        this._index = index;
        _text.text = "Level: " + (index.ToString());
        this._sprite.sprite = sprite;
        _Button.onClick.AddListener(SetImageToPlay); 
        CheckBlockToLevel();
    }

    private void SetImageToPlay()
    {
        ImageManager.Instance.SetImageToPlay(_index);
        LoadManager.LoadLevelHandle?.Invoke();
    }

    void CheckBlockToLevel()
    {
        if(SaveManager.LevelsBlock[_index] == true)
        {
            _blockable = true;
            _lock.enabled = true;

            Color currentColor = _sprite.color;
            Color.RGBToHSV(currentColor, out float h, out float s, out float v);
            v *= 0.5f;
            v = Mathf.Clamp01(v);
            Color newColor = Color.HSVToRGB(h, s, v);
            _sprite.color = newColor;
        }
    }
    #endregion
}