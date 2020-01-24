using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private List<GameObject> doors = new List<GameObject>();


    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Door")
            {
                doors.Add(child.gameObject);
            }
        }
    }

    public void DoorOpen()
    {
        foreach (var door in doors)
        {
            //door.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow * 2);
            door.GetComponent<Animator>().SetBool("Open", true);
            door.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public void DoorClosed()
    {
        foreach (var door in doors)
        {
            //door.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red * 2);
            door.GetComponent<Animator>().SetBool("Open", false);
            door.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
