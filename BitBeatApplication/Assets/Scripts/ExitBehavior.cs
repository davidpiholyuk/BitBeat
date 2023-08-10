using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    void Update()
    {
        // check if the Escape key was pressed
        if (Input.GetKey("escape"))
        {
            // if we are running in a standalone build of the game
            if (Application.platform == RuntimePlatform.WindowsPlayer ||
                Application.platform == RuntimePlatform.OSXPlayer ||
                Application.platform == RuntimePlatform.LinuxPlayer)
            {
                Application.Quit();
            }

            // if we are running in the editor
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
