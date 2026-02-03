using UnityEngine;
using UnityEngine.UI;

public class InputToggleController : MonoBehaviour
{
    public DataModel dataModel;      // Referenz auf dein bestehendes DataModel
    public Image[] inputImages;      // 7 UI-Images für die Eingabezeile (Q6 → Q0)

    void Update()
    {
        // -----------------------------
        // Feature 6: Pixel-Toggles Q-U
        // -----------------------------
        if (Input.GetKeyDown(KeyCode.Q)) TogglePixel(6);
        if (Input.GetKeyDown(KeyCode.W)) TogglePixel(5);
        if (Input.GetKeyDown(KeyCode.E)) TogglePixel(4);
        if (Input.GetKeyDown(KeyCode.R)) TogglePixel(3);
        if (Input.GetKeyDown(KeyCode.T)) TogglePixel(2);
        if (Input.GetKeyDown(KeyCode.Y)) TogglePixel(1);
        if (Input.GetKeyDown(KeyCode.U)) TogglePixel(0);

        // -----------------------------
        // Feature 7: FIFO-Shift D
        // -----------------------------
        if (Input.GetKeyDown(KeyCode.D))
        {
            dataModel.ShiftInputLineToGrid(); // ruft die neue Funktion in DataModel auf
            UpdateInputUI(); // UI der Eingabezeile zurücksetzen
        }
    }

    void TogglePixel(int index)
    {
        // Pixel toggeln
        dataModel.inputRow[index] = !dataModel.inputRow[index];
        UpdateInputUI();
    }

    void UpdateInputUI()
    {
        // Eingabezeilen-UI aktualisieren (weiß = an, schwarz = aus)
        for (int i = 0; i < inputImages.Length; i++)
        {
            inputImages[i].color = dataModel.inputRow[i] ? Color.white : Color.black;
        }
    }
}
