using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxColour : MonoBehaviour
{
   public void Red()
    {
        //changes material colour when function is called
        GetComponent<Renderer>().material.color = Color.red;
        } 

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

}
