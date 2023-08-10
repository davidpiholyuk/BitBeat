using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    public bool gameStarted = false;
    private Camera _camera;
    public GameObject bulletPrefab;
    public float bulletSpeed = 2000.0f;

    // Start is called before the first frame update
    void Start()
    {
        _camera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
                Ray ray = _camera.ScreenPointToRay(point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null)
                    {
                        target.ReactToHit();
                    }
                }
            }
        }
    }

    void OnGUI()
    {
        int size = 50;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
