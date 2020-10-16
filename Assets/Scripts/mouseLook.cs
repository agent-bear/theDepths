using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public Transform Camera;
    public float mouseSensitivity = 5f;
    
    float xRotation = 0f;
    float yRotation = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(transform.up.y > 0){
            yRotation += mouseX;
        } else{
            yRotation -= mouseX;
        }

        xRotation -= mouseY;

        transform.localRotation = Quaternion.Euler(xRotation * mouseSensitivity, yRotation * mouseSensitivity, 0);

        if(Camera.transform.localPosition.z < -10){
            Camera.transform.localPosition = new Vector3(0, 0, -10);
        }

        if(Camera.transform.localPosition.z > 0){
            Camera.transform.localPosition = new Vector3(0, 0, 0);
        }
        
        Camera.transform.localPosition += new Vector3(0, 0, scroll * 10);


    }
}
