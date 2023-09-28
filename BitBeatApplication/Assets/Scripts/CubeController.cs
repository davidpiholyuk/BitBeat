using UnityEngine;
using TMPro;

public class CubeController : MonoBehaviour
{
    

    public TextMeshPro childTextMeshPro;
    public TextMeshPro guideText;

    void Start()
    {
        // Set the initial text
        SetText();
    }

    public void setGuideText(double id){
        guideText.text = id.ToString();
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
