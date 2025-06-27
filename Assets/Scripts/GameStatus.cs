using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public static GameStatus Instance { get; private set; }
    [SerializeField] private GameObject[] tiles;
    private bool[] _visitedTile;
    private Button[] _tileButtons;
    private TMP_Text[] _tileSymbol;
    private TileDetails[] _tileDetails;
    [SerializeField] private PromptTexts promptTexts;

    private void Awake()
    {
        Instance = this;
        _tileButtons = new Button[tiles.Length];
        _tileSymbol = new TMP_Text[tiles.Length];
        _tileDetails = new TileDetails[tiles.Length];
        _visitedTile = new bool[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            _tileButtons[i] = tiles[i].GetComponent<Button>();
            _tileSymbol[i] = tiles[i].GetComponentInChildren<TMP_Text>();
            _tileDetails[i] = tiles[i].GetComponent<TileDetails>();
            _visitedTile[i] = false;
        }
    }

    private void Start()
    {
        ResetState();
    }

    internal void DisableTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            _tileButtons[i].interactable = false;
        }
    }

    internal void EnableTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if(_visitedTile[i] == false) _tileButtons[i].interactable = true;
            else _tileButtons[i].interactable = false;
        }
    }

    internal void SetVisitedTile(int idx)
    {
        _visitedTile[idx] = true;
    }

    internal GameObject GetAvailableTile()
    {
        HashSet<int> checkRandom = new HashSet<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8};
        while (checkRandom.Count != 0)
        {
            int x = Random.Range(0, 9);
            if (checkRandom.Contains(x) && _visitedTile[x] == false)
            {
                Debug.Log(x + " is available for AI");
                return tiles[x];
            }
            if (checkRandom.Contains(x)) checkRandom.Remove(x);
        }
        return null;
    }

    internal void ResetState()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            _tileButtons[i].interactable = true;
            _tileSymbol[i].text = "";
            _tileDetails[i].setSymbol("");
            promptTexts.Reset();
        }
    }

    internal void GameEndState(int result)
    {
        if (result == 0)
        {
            promptTexts.SetResult("Draw!");
            return;
        }
        
        promptTexts.SetResult(result == 1 ? "O Wins!" : "X Wins!");
        
        for (int i = 0; i < tiles.Length; i++)
        {
            _tileButtons[i].interactable = false;
        }
    }

    internal void SetCurrentTurn(int idx)
    {
        string symbol = idx == 0 ? "O" : "X";
        promptTexts.SetCurrentTurn(symbol);
    }
    
    internal GameObject GetTile(int idx)
    {
        return tiles[idx];
    }
    
    internal void HighlightTiles(int i, int j, int k)
    {
        _tileButtons[i].GetComponent<Image>().color = Color.greenYellow;
        _tileButtons[j].GetComponent<Image>().color = Color.greenYellow;
        _tileButtons[k].GetComponent<Image>().color = Color.greenYellow;
    }
}
