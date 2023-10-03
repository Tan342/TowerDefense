using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") != 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X"), 0.0f, Input.GetAxisRaw("Mouse Y")) * Time.deltaTime * speed;
            }
        }
    }
    
}
