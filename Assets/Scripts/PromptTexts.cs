using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptTexts : MonoBehaviour
{
    [SerializeField] private TMP_Text currentTurnOutput;
    [SerializeField] private TMP_Text[] resultOutput;

    private void Awake()
    {
        Reset();
    }

    internal void SetCurrentTurn(string currentTurn)
    {
        currentTurnOutput.text = currentTurn;
    }
    
    internal void SetResult(string result)
    {
        resultOutput[0].text = "Result";
        resultOutput[1].text = result;
    }
    
    internal void Reset()
    {
        currentTurnOutput.text = "O";
        resultOutput[0].text = "";
        resultOutput[1].text = "";
    }
}
