using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private Transform _selectedPiece;

    #region Update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                if (_selectedPiece == null)
                {
                    _selectedPiece = hit.transform;
                    Debug.Log(hit.transform.gameObject.name);
                }
                else
                {
                    _gameManager.SwapPieces(_selectedPiece, hit.transform);
                    _selectedPiece = null;
                }
            }
        }
    }
    #endregion
}
