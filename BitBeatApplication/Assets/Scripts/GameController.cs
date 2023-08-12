using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    public Button playButton;
    public GameObject menuUI;
    public GameObject displayUI;
    public GameObject cubePrefab;
    public GameObject player;
    public static bool isGameStarted = false;
    private List<GameObject> cubes= new List<GameObject>();
    private int currNum;
    private int score;
    public TextMeshPro scoreText;
    public TextMeshPro numberText;

    void Start()
    {
        displayUI.SetActive(false);
        playButton.onClick.AddListener(StartGame);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void StartGame()
    {
        // Here we lock the cursor and make it invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Disable menu UI and set game state to started.
        menuUI.SetActive(false);
        isGameStarted = true;

        GenerateCubes(8);
        Random rand = new Random();
        currNum = rand.Next(0, (int)Mathf.Pow(2, cubes.Count));

        UpdateUI();
        displayUI.SetActive(true);
    }

    void GenerateCubes(int numberOfCubes)
    {
        float length = (numberOfCubes - 1) * 1.0f;
        Vector3 start = player.transform.position + player.transform.forward * 20 - player.transform.right * length / 2;

        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 cubePosition = start + player.transform.right * i * 1.0f;
            cubePosition.y = 4.0f;
            GameObject newCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
            ReactiveTarget cubeScript = newCube.GetComponent<ReactiveTarget>();
            cubeScript.gameController = this;
            cubes.Add(newCube);
        }
    }

    public void CubeValuesChanged()
    {
        int newValue = GetCubesValue();
        if (newValue == currNum)
        {
            score++;
            Random rand = new Random();
            currNum = rand.Next(0, (int)Mathf.Pow(2, cubes.Count));
            ResetCubes();
            UpdateUI();
        }
    }

    int GetCubesValue()
    {
        int bitNumber = 1;
        int total = 0;
        for (int i = cubes.Count - 1; i >= 0; i--)
        {
            GameObject cube = cubes[i];
            TextMeshPro cubeValue = cube.GetComponentInChildren<TextMeshPro>();
            int value;
            if (int.TryParse(cubeValue.text, out value))
            {
                total += value * bitNumber;
            }
            bitNumber *= 2;
        }
        return total;
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();
        numberText.text = "Convert to Binary: " + currNum.ToString();
    }

    void ResetCubes()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            GameObject cube = cubes[i];
            if (cube.GetComponentInChildren<TextMeshPro>().text.Equals("1"))
            {
                CubeController cubeController = cube.GetComponent<CubeController>();
                cubeController.SetText();
            } 
        }
    }
}
