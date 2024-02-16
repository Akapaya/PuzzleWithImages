using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    #region Settings Variables
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ShuffleManager _shuffleManager;

    [SerializeField] private Transform _gameTransform;
    [SerializeField] private GameObject _piecePrefab;

    [SerializeField] private int _rows;
    [SerializeField] private int _cols;
    [SerializeField] private float _gapThickness;
    private Vector2 _textureResolution;
    #endregion

    #region Start Methods
    private void Start()
    {
        CreatePieces();
        _shuffleManager.ShufflePieces(_gameManager.Pieces, _rows, _cols);
    }
    #endregion

    #region Create Pieces
    public void CreatePieces()
    {
        _textureResolution = new Vector2(ImageManager.Instance.PieceMaterial.mainTexture.width, ImageManager.Instance.PieceMaterial.mainTexture.height);
        CreateGamePieces();
    }

    private void CreateGamePieces()
    {
        float imageAspectRatio = _textureResolution.x / _textureResolution.y;
        float gameTransformWidth = _gameTransform.localScale.x;
        float gameTransformHeight = _gameTransform.localScale.y;

        float pieceWidth = gameTransformWidth / _cols;
        float pieceHeight = pieceWidth / imageAspectRatio;

        float gap = _gapThickness; // Ajustado para o tamanho do gap real

        int pieceCount = 0;

        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _cols; col++)
            {
                GameObject piece = Instantiate(_piecePrefab, _gameTransform);
                _gameManager.Pieces.Add(piece.transform);

                float posX = -gameTransformWidth / 2 + pieceWidth * (col + 0.5f) + gap * col; // Ajuste para o gap
                float posY = gameTransformHeight / 2 - pieceHeight * (row + 0.5f) - gap * row; // Ajuste para o gap em Y
                piece.transform.localPosition = new Vector3(posX, -posY, 0); // Invertendo a coordenada Y

                // Ajustando a escala das peças com base no gap
                float adjustedWidth = pieceWidth - gap;
                float adjustedHeight = pieceHeight - gap;
                piece.transform.localScale = new Vector3(adjustedWidth, adjustedHeight, 1f);

                piece.name = $"{pieceCount}";
                pieceCount++;

                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                Vector2[] uv = new Vector2[4];

                uv[0] = new Vector2(col / (float)_cols, row / (float)_rows);
                uv[1] = new Vector2((col + 1) / (float)_cols, row / (float)_rows);
                uv[2] = new Vector2(col / (float)_cols, (row + 1) / (float)_rows);
                uv[3] = new Vector2((col + 1) / (float)_cols, (row + 1) / (float)_rows);

                mesh.uv = uv;
            }
        }
    }
    #endregion
}
