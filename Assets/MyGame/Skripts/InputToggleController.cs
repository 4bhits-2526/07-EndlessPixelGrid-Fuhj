using UnityEngine;
using UnityEngine.UI;

public class InputToggleController : MonoBehaviour
{
    [Header("Datenmodell")]
    public DataModel dataModel;          // Referenz auf dein bestehendes DataModel

    [Header("UI Images")]
    public Image[] inputImages;          // 7 UI-Images für Eingabezeile (Q6 → Q0)
    public Image[] gridImages;           // 10x7 = 70 UI-Images für Raster

    private int rows = 10;               // Rasterzeilen
    private int cols = 7;                // Rasterspalten

    void Update()
    {
        // -----------------------------
        // Feature 6: Pixel-Toggles Q-U
        // -----------------------------
        if (Input.GetKeyDown(KeyCode.Q)) { TogglePixel(6); RenderInputLine(); }
        if (Input.GetKeyDown(KeyCode.W)) { TogglePixel(5); RenderInputLine(); }
        if (Input.GetKeyDown(KeyCode.E)) { TogglePixel(4); RenderInputLine(); }
        if (Input.GetKeyDown(KeyCode.R)) { TogglePixel(3); RenderInputLine(); }
        if (Input.GetKeyDown(KeyCode.T)) { TogglePixel(2); RenderInputLine(); }
        if (Input.GetKeyDown(KeyCode.Y)) { TogglePixel(1); RenderInputLine(); }
        if (Input.GetKeyDown(KeyCode.U)) { TogglePixel(0); RenderInputLine(); }

        // -----------------------------
        // Feature 7: FIFO-Shift D
        // -----------------------------
        if (Input.GetKeyDown(KeyCode.D))
        {
            dataModel.ShiftInputLineToGrid(); // Datenmodell updaten
            RenderGrid();                     // Raster UI rendern
            RenderInputLine();                // Eingabezeile UI rendern
        }

        // -----------------------------
        // Feature 9: Reset G
        // -----------------------------
        if (Input.GetKeyDown(KeyCode.G))
        {
            ResetGridAndInput();              // Datenmodell zurücksetzen
            RenderGrid();                     // UI aktualisieren
            RenderInputLine();                // UI aktualisieren
        }
    }

    // -----------------------------
    // Pixel in der Eingabezeile toggeln
    // -----------------------------
    void TogglePixel(int index)
    {
        dataModel.inputRow[index] = !dataModel.inputRow[index];
    }

    // -----------------------------
    // Feature 8: Eingabezeile rendern
    // -----------------------------
    public void RenderInputLine()
    {
        for (int i = 0; i < inputImages.Length; i++)
        {
            inputImages[i].color = dataModel.inputRow[i] ? Color.white : Color.black;
        }
    }

    // -----------------------------
    // Feature 8: Raster rendern
    // -----------------------------
    public void RenderGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int index = row * cols + col; // 1D-Array Index
                if (gridImages[index] != null)
                {
                    gridImages[index].color = dataModel.grid[row, col] ? Color.white : Color.black;
                }
            }
        }
    }

    // -----------------------------
    // Feature 9: Datenmodell zurücksetzen
    // -----------------------------
    void ResetGridAndInput()
    {
        // Raster leeren
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                dataModel.grid[row, col] = false;
            }
        }

        // Eingabezeile leeren
        for (int i = 0; i < dataModel.inputRow.Length; i++)
        {
            dataModel.inputRow[i] = false;
        }
    }
}
