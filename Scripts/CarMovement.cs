using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float turnSpeed = 2f;
    [SerializeField] float maxForwardSpeed = 20f;

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 rotationRight = new Vector3(0, 30, 0);
    Vector3 rotationLeft = new Vector3(0, -30, 0);
    Vector3 cameraOffset = new Vector3(0.5f, 3.5f, -15);

    float minRotation = 12;
    float maxRotation = 348;
    Vector3 currentRotation;

    Rigidbody rigidbody;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(forward * forwardSpeed * Time.deltaTime);
            
        }
        if (Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotationRight);
        }
        if (Input.GetKey("a"))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotationLeft);
        }

        mainCamera.transform.position = transform.position + cameraOffset;
        //Quaternion clamprotation = Mathf.Clamp(transform.rotation, -12, 12);

        //print(transform.rotation.eulerAngles.y);

        currentRotation = transform.localRotation.eulerAngles;
        print(currentRotation.y);
        currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
       // mainCamera.transform.localRotation = Quaternion.Euler(currentRotation);
        //print(mainCamera.transform.localRotation.y);

    }
}
