using UnityEngine;

public class DataModel : MonoBehaviour
{
    // Eingabezeile (Q6 links bis Q0 rechts)
    public bool[] inputRow = new bool[7];

    // Raster: 10 Zeilen, 7 Spalten
    public bool[,] grid = new bool[10, 7];

    // -----------------------------
    // Feature 7: FIFO-Shift der Eingabezeile ins Raster
    // -----------------------------
    public void ShiftInputLineToGrid()
    {
        // 1. Alle Zeilen nach oben verschieben
        for (int row = 0; row < grid.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
            {
                grid[row, col] = grid[row + 1, col];
            }
        }

        // 2. Eingabezeile unten einfügen
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            grid[grid.GetLength(0) - 1, col] = inputRow[col];
        }

        // 3. Eingabezeile zurücksetzen
        for (int col = 0; col < inputRow.Length; col++)
        {
            inputRow[col] = false;
        }
    }
}
