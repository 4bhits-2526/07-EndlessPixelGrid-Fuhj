using UnityEngine;
using UnityEngine.UI;

public class InputToggleController : MonoBehaviour
{
    public DataModel dataModel;      // Referenz auf Feature 5
    public Image[] inputImages;      // 7 UI Images (Q6 → Q0)

    void Update()
    {
        // Q6 (links)
        if (Input.GetKeyDown(KeyCode.Q))
            TogglePixel(6);

        if (Input.GetKeyDown(KeyCode.W))
            TogglePixel(5);

        if (Input.GetKeyDown(KeyCode.E))
            TogglePixel(4);

        if (Input.GetKeyDown(KeyCode.R))
            TogglePixel(3);

        if (Input.GetKeyDown(KeyCode.T))
            TogglePixel(2);

        if (Input.GetKeyDown(KeyCode.Y))
            TogglePixel(1);

        if (Input.GetKeyDown(KeyCode.U))
            TogglePixel(0);
    }

    void TogglePixel(int index)
    {
        // bool toggeln
        dataModel.inputRow[index] = !dataModel.inputRow[index];

        // UI aktualisieren
        inputImages[index].color =
            dataModel.inputRow[index] ? Color.white : Color.black;
    }
}
