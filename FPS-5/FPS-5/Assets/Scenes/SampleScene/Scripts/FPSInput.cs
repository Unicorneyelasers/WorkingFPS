using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour

{
    // Start is called before the first frame update
    private float speed = 9.0f;
    private float horizontal;
    private float vertical;

    private float gravity = -9.8f;


    [SerializeField]
    private CharacterController charController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement.y = gravity;
        movement *= speed;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }
    private void FixedUpdate()
    {
       // float force = speed * 100;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        transform.Translate(movement);
        
    }
}
