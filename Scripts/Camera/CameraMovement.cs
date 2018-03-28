using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform cameraTransform;
    private Vector3 movement;
    private GameObject camera;

    public float height;
    public float speed;

    private Vector3 rotationAxis;
    public float rotationAngle;
    public float rotationDistance;
    public float rotationSpeed;


    // Use this for initialization
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        cameraTransform.position = new Vector3(0, 0, 0);
        cameraTransform.eulerAngles = new Vector3(0, 45, 0);

        camera = GameObject.Find("Main Camera");
        camera.transform.localPosition = new Vector3(0, height, -rotationDistance);
        camera.transform.localEulerAngles = new Vector3(rotationAngle, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -speed;
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                movement.x = speed;
            }
            else
            {
                movement.x = 0;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement.z = -speed;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                movement.z = speed;
            }
            else
            {
                movement.z = 0;
            }
        }

        if(Input.GetKey(KeyCode.Q))
        {
            cameraTransform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.E))
        {
            cameraTransform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }

        cameraTransform.Translate(movement * Time.deltaTime);
    }
}
