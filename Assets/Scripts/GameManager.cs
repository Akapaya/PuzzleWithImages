using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Settings Variables
    [SerializeField] private Transform _gameTransform;
    [SerializeField] private GameObject _piecePrefab;
    [SerializeField] private Material _pieceMaterial;
    #endregion

    public UnityEvent OnCompletedImage = new UnityEvent();

    public List<Transform> Pieces = new List<Transform>();
    bool _completed = false;

    #region Mecanic Swap Method
    public void SwapPieces(Transform piece1, Transform piece2)
    {
        if (_completed == false)
        {
            int index1 = Pieces.IndexOf(piece1);
            int index2 = Pieces.IndexOf(piece2);

            Vector3 tempPosition = piece1.localPosition;
            piece1.localPosition = piece2.localPosition;
            piece2.localPosition = tempPosition;

            Pieces[index1] = piece2;
            Pieces[index2] = piece1;

            CheckCompletion();
        }
    }
    #endregion

    #region Check Completion
    private bool CheckCompletion()
    {
        for (int i = 0; i < Pieces.Count; i++)
        {
            if (Pieces[i].name != $"{i}")
            {
                Debug.Log("Not Yet");
                return false;
            }
        }
        _completed = true;
        SaveManager.SaveImageHandle?.Invoke(ImageManager.Instance.Index);
        OnCompletedImage.Invoke();
        return true;
    }
    #endregion
}
