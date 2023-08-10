using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button playButton;
    public GameObject menuUI;
    public GameObject cubePrefab;
    public GameObject player;
    public static bool isGameStarted = false;

    void Start()
    {
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
    }

    void GenerateCubes(int numberOfCubes)
    {
        float length = (numberOfCubes - 1) * 1.0f;
        Vector3 start = player.transform.position + player.transform.forward * 20 - player.transform.right * length / 2;

        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 cubePosition = start + player.transform.right * i * 1.0f;
            cubePosition.y = 2.0f;
            Instantiate(cubePrefab, cubePosition, Quaternion.identity);
        }
    }
}
