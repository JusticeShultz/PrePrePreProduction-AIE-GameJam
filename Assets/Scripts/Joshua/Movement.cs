using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed = .1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position += new Vector3 (Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")) * speed;

    }
}
