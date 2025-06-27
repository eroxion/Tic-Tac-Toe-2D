using UnityEngine;

public class TileDetails : MonoBehaviour
{
    [SerializeField] private TileMeta _tileMeta;
    
    internal int getIdx() { return _tileMeta.idx; }  
    internal string getSymbol() { return _tileMeta.symbol; }
    internal void setIdx(int idx) { _tileMeta.idx = idx; }
    internal void setSymbol(string symbol) { _tileMeta.symbol = symbol; }
    
}
