using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private CubeController cubeController;

    private void Start()
    {
        cubeController = GetComponent<CubeController>();
    }

    public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        cubeController.SetText();
        yield return null;
    }
}
