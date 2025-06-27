using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameLogicAI : MonoBehaviour
{
    private readonly string[] _symbols = new string[] { "O", "X" };
    private const int WinnerCheckCount = 3;
    private int _i = 0;
    private int[] _tileState = null;
    private int _turn = 0;
    [SerializeField] private SFX sfxManager;

    private void Awake()
    {
        ResetTileState();
    }

    private void Start()
    {
        GameStatus.Instance.SetCurrentTurn(_i);
    }

    private void ResetTileState()
    {
        // 0 = blank, 1 = O, 2 = X
        _tileState = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    public void OnTileClicked(GameObject tileButton)
    {
        sfxManager.ClickSound();
        
        TileDetails tileDetails = tileButton.GetComponent<TileDetails>();
        TMP_Text tileSymbol = tileButton.GetComponentInChildren<TMP_Text>();
        tileSymbol.text = _symbols[_i];
        tileDetails.setSymbol(_symbols[_i]);
        
        int idx = tileDetails.getIdx();
        _tileState[idx] = _i == 0 ? 1 : 2;
        _i = 1 - _i;
        
        GameStatus.Instance.SetCurrentTurn(_i);
        
        TilesInteractionUpdate(idx);
        
        _turn++;
        
        int gameJudge = WinnerCheck();
        if (gameJudge >= 0)
        {
            GameStatus.Instance.GameEndState(gameJudge);
            sfxManager.GameOverSound(gameJudge);
            
            // Optional: Allow player to restart the game.
            //      UI Button to restart the game.
            //      ResetTileState();
            //      GameStatus.Instance.ResetState();
        }
        else if (_i == 1)
        {
            GameStatus.Instance.DisableTiles();
            StartCoroutine(AITurn());
        }
    }

    private IEnumerator AITurn()
    {
        yield return new WaitForSeconds(2f);
        GameObject randomTile = GameStatus.Instance.GetAvailableTile();
        if (randomTile) OnTileClicked(randomTile);
    }

    private void TilesInteractionUpdate(int idx)
    {
        GameStatus.Instance.SetVisitedTile(idx);
        GameStatus.Instance.EnableTiles();
    }

    private int WinnerCheck()
    {
        for (int i = 0; i < WinnerCheckCount; i++)
        {
            // Checking column winner
            if (_tileState[i] > 0 &&
                _tileState[i] == _tileState[i + WinnerCheckCount] &&
                _tileState[i] == _tileState[i + (WinnerCheckCount * 2)])
            {
                GameStatus.Instance.HighlightTiles(i, i + WinnerCheckCount, i + (WinnerCheckCount * 2));
                return _tileState[i];
            }
            
            int x = WinnerCheckCount * i;
            
            // Checking row winner
            if (_tileState[x] > 0 &&
                _tileState[x] == _tileState[x + 1] &&
                _tileState[x] == _tileState[x + 2])
            {
                GameStatus.Instance.HighlightTiles(x, x + 1, x + 2);
                return _tileState[x];
            }
        }
        
        //Checking diagonal 1 winner
        if (_tileState[4] > 0 &&
            (_tileState[0] == _tileState[4] && _tileState[0] == _tileState[8]))
        {
            GameStatus.Instance.HighlightTiles(0, 4, 8);
            return _tileState[4];
        }
        
        //Checking diagonal 2 winner
        if (_tileState[4] > 0 &&
            (_tileState[2] == _tileState[4] && _tileState[2] == _tileState[6]))
        {
            GameStatus.Instance.HighlightTiles(2, 4, 6);
            return _tileState[4];
        }
        
        // Checking draw condition
        if (_turn == 9) return 0;
        return -1;
    }
}
