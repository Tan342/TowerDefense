using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] public bool isPlaceable;
    BuiltManager builtManager;
    public Node connectTo;


    void Start()
    {
        //builtManager = FindObjectOfType<BuiltManager>();
    }
    
    public Vector2Int GetCoordinate()
    {
        Vector2Int coordinate = new Vector2Int();
        coordinate.x = Mathf.RoundToInt(transform.position.x / 5);
        coordinate.y = Mathf.RoundToInt(transform.position.z / 5);
        return coordinate;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    /*void OnMouseDown()
    {
        Debug.Log(builtManager.IsBuilding());
        if (isPlaceable && builtManager.IsBuilding())
        {
            Debug.Log("df");
            builtManager.Build(transform.position);
            isPlaceable = false;
        }
    }*/


}
