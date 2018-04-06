using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool allowMovement = true;

    public float Speed = 30f;
	void Update ()
    {

        if (GameManager.gameEnded)
        {
            enabled = false;
            return;
        }

        if (Input.GetKeyDown ("q"))
        {
            allowMovement = !allowMovement;
        }

        if (!allowMovement)
        {
            return;
        }

	   if (Input.GetKey("w"))
        {
            transform.Translate(Speed * Vector3.forward * Time.deltaTime, Space.World);
        }

       if (Input.GetKey("s"))
        {
            transform.Translate(Speed * Vector3.back * Time.deltaTime, Space.World);
        }
       
       if (Input.GetKey("d"))
        {
            transform.Translate(Speed * Vector3.right * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Speed * Vector3.left * Time.deltaTime, Space.World);
        }


    }
	}

