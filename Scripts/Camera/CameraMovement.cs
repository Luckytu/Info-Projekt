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
    public float rotationAngleX;
    public float rotationDistance;
    public float rotationDuration;
    public int rotationSteps;


    // Use this for initialization
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        cameraTransform.position = new Vector3(0, 0, 0);
        cameraTransform.eulerAngles = new Vector3(0, 45, 0);

        camera = GameObject.Find("Main Camera");
        camera.transform.localPosition = new Vector3(0, height, -rotationDistance);
        camera.transform.localEulerAngles = new Vector3(rotationAngleX, 0, 0);
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

        if(Input.GetKeyDown(KeyCode.Q))
        {
            rotateInitialize(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            rotateInitialize(true);
        }

        cameraTransform.Translate(movement * Time.deltaTime);
    }

    private void rotateInitialize(bool clockWise)
    {
        float rotationAngleY = 360 / (float)rotationSteps;

        print(rotationAngleY);

        Quaternion start = cameraTransform.rotation;
        Quaternion end = clockWise? Quaternion.Euler(0, start.eulerAngles.y - rotationAngleY, 0) : Quaternion.Euler(0, start.eulerAngles.y + rotationAngleY, 0);

        print("Start: " + start.eulerAngles.y);
        print("End: " + end.eulerAngles.y);

        StartCoroutine(rotate(start, end));
    }

    private IEnumerator rotate(Quaternion start, Quaternion end)
    {
        float timePassed = 0;

        while(timePassed <= rotationDuration)
        {
            cameraTransform.rotation = Quaternion.Slerp(start, end, timePassed / rotationDuration);            
            yield return null;
            timePassed += Time.deltaTime;
        }

        cameraTransform.rotation = end;
    }
}
