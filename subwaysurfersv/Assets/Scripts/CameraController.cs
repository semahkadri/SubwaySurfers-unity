using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private UnityEngine.Vector3 offset;
    void Start()
    {
      
        offset = transform.position - target.position;
       

    }

   // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 newPosition = new UnityEngine.Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
     
        transform.position = newPosition;
      
    }
}