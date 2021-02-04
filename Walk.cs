using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    public int playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    // When the player inputs on their device, have the camera move using the playerSpeed variable.
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
    }

}
