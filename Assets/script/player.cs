using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    private float inputdirection;
    private CharacterController controller;
    private Vector3 moveVector;
    private Vector3 lastmotion;
    private float gravity = 30.0f;
    private float verticalVelocity;//x value of move vektor
    private float speed = 5.0f;
    private bool secondjump = false;
    private float jumpforce = 10.0f;

    void Start () {
        controller = GetComponent< CharacterController >();
	}


    void Update () {
        IsControllerGrounded();
       inputdirection = Input.GetAxis("horizontal")*speed;

        moveVector = Vector3.zero;

        if (IsControllerGrounded())
        {
            verticalVelocity = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {

                verticalVelocity = jumpforce;
                secondjump = true;
            }
            moveVector.x = inputdirection;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (secondjump)
                {
                    verticalVelocity = jumpforce;

                    secondjump = false;
                }
            }
            moveVector.x = lastmotion.x;

            verticalVelocity -=  gravity*Time.deltaTime;
        }
        moveVector.y = verticalVelocity;
        //moveVector = new Vector3(inputdirection, verticalVelocity, 0);
        lastmotion = moveVector;
        controller.Move(moveVector*Time.deltaTime);
    }

    private bool IsControllerGrounded()
    {
        Vector3 leftrayStart;
        Vector3 rightrayStart;
        leftrayStart = controller.bounds.center;
        rightrayStart = controller.bounds.center;
        leftrayStart.x -= controller.bounds.extents.x;
        rightrayStart.x += controller.bounds.extents.x;

        if (Physics.Raycast(leftrayStart, Vector3.down, (controller.height / 2) + 0.1f))
        {
            return true;
        }
        if (Physics.Raycast(rightrayStart, Vector3.down, (controller.height / 2) + 0.1f))
        {
            return true;
        }

        return false;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveVector = hit.normal*speed;
                verticalVelocity = jumpforce;
                secondjump = true;
            }
            }
        //collision
        switch (hit.gameObject.tag)
        {
            case "Coin":
                Destroy(hit.gameObject);
                break;
            case "jumppad":
                verticalVelocity = jumpforce * 2;
                break;
            case "teleport":
               transform.position= hit.transform.GetChild(0).position;

                break;

        }
    }
   
}

