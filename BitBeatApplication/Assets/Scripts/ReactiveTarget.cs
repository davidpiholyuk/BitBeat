using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private CubeController cubeController;
    public GameController gameController;

    private void Start()
    {
        cubeController = GetComponent<CubeController>();
    }

    public void ReactToHit()
    {
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText()
    {
        cubeController.SetText();
        gameController.CubeValuesChanged();
        yield return null;
    }
}
