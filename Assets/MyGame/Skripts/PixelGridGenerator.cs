using UnityEngine;
using UnityEngine.UI;

public class PixelGridGenerator : MonoBehaviour
{
    public GameObject pixelPrefab;
    public int rows = 10;
    public int columns = 7;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        int totalPixels = rows * columns;

        for (int i = 0; i < totalPixels; i++)
        {
            GameObject pixel = Instantiate(pixelPrefab, transform);
            pixel.GetComponent<Image>().color = Color.black;

        }
    }
}
