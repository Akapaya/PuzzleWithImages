using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    private List<Transform> _pieces;
    private int _rows;
    private int _cols;

    public void ShufflePieces(List<Transform> pieces, int rows, int cols)
    {
        _pieces = pieces;
        _rows = rows;
        _cols = cols;

        Shuffle();
    }

    void Shuffle()
    {
        for (int i = 0; i < _rows * _cols * _rows; i++)
        {
            int rnd1 = Random.Range(0, _rows * _cols);
            int rnd2 = Random.Range(0, _rows * _cols);
            Swap(rnd1, rnd2);
        }
    }

    void Swap(int index1, int index2)
    {
        (_pieces[index1], _pieces[index2]) = (_pieces[index2], _pieces[index1]);
        (_pieces[index1].localPosition, _pieces[index2].localPosition) = (_pieces[index2].localPosition, _pieces[index1].localPosition);
    }
}
