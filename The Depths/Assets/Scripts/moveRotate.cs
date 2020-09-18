using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRotate : MonoBehaviour
{
    public Transform camTransform;
    public Transform meshTransform;

    public CharacterController controller;

    public float turnSpeed = 1f;

    public float moveSpeed = 12f;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Lerps the rotation of the mesh to the camera
        Quaternion camRotation = camTransform.transform.localRotation;
        Quaternion meshRotation = Quaternion.Lerp(meshTransform.transform.localRotation, camRotation, Time.deltaTime * turnSpeed);
        meshTransform.transform.localRotation = meshRotation;

        //gets the input from the keyboard
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 meshDir =  camTransform.transform.right * x + camTransform.transform.forward * y;

        controller.Move(meshDir * moveSpeed * Time.deltaTime);
        
    
    
    }
}
