using UnityEngine;
using TMPro;

public class CubeController : MonoBehaviour
{
    public TextMeshPro childTextMeshPro;

    void Start()
    {
        // Set the initial text
        SetText();
    }

    public void SetText()
    {
        // Update the text
        if (childTextMeshPro.text.Equals("1"))
        {
            childTextMeshPro.text = "0";
        }
        else
        {
            childTextMeshPro.text = "1";
        }
    }
}
