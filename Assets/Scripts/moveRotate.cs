using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRotate : MonoBehaviour
{
    public Transform camTransform;
    public Transform meshTransform;
    public Transform waterLevel;

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
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");
        float up = Input.GetAxis("Jump");

        Vector3 meshDir = camTransform.transform.right * sideways + camTransform.transform.forward * forward + camTransform.transform.up * up;

        controller.Move(meshDir * moveSpeed * Time.deltaTime);

        //limits the player movement to the water level.
        if(transform.position.y - 0.2f > waterLevel.transform.position.y){
            Vector3 newPosition = new Vector3(transform.position.x, waterLevel.transform.position.y + 0.2f, transform.position.z);
            transform.position = newPosition;
        }
        
    
    }
}
