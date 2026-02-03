using UnityEngine;

public class DataModel : MonoBehaviour
{
    // Eingabezeile (Q6 links bis Q0 rechts)
    public bool[] inputRow = new bool[7];

    // Raster: 10 Zeilen, 7 Spalten
    public bool[,] grid = new bool[10, 7];
}
