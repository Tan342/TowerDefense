using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    [SerializeField] Transform castle;
    Node end;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    Vector2Int[] direction = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform tile in transform)
        {
            Node node = tile.GetComponent<Node>();
            grid.Add(node.GetCoordinate(), node);
        }
        Debug.Log(grid.Count);
        end = GetNodeFromPosition(castle.transform.position);
    }

    public void SetPlaceable(Vector3 pos, bool value)
    {
        Node temp = GetNodeFromPosition(pos);
        temp.isPlaceable = value;
    }

    public Vector3 RoundPos(Vector3 pos)
    {
        Vector3 p = new Vector3();
        p.x = RoundFloat(pos.x);
        p.y = RoundFloat(pos.y);
        p.z = RoundFloat(pos.z);
        return p;
    }

    float RoundFloat(float value)
    {
        float temp = value % 10;
        if (temp < 2.5)
        {
            value -= temp;
        }
        else if (temp >= 2.5 && temp <= 5)
        {
            value += (5 - temp);
        }
        else if (temp >= 5 && temp < 7.5) 
        {
            value -= (temp-5);
        }
        else
        {
            value += (10 - temp);
        }
        return value;
    }
   

    void ResetNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> kvp in grid)
        {
            kvp.Value.connectTo = null;
        }
    }

    public Node GetNode(Vector2Int pos)
    {
        if (grid.ContainsKey(pos))
        {
            Debug.Log(grid[pos].name);
            return grid[pos];
        }
        return null;
    }

    public Node GetNodeFromPosition(Vector3 pos)
    {
        Vector2Int coordinate = new Vector2Int();
        coordinate.x = Mathf.RoundToInt(pos.x / 5);
        coordinate.y = Mathf.RoundToInt(pos.z / 5);
        /*if (grid.ContainsKey(coordinate))
        {
            return grid[coordinate];
        }*/
        return grid[coordinate];
    }

    public List<Node> BFS(Node start)
    {
        Queue<Node> queue = new Queue<Node>();
        Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
        Dictionary<Vector2Int, Node> grid_copy = new Dictionary<Vector2Int, Node>();
        queue.Enqueue(start);
        reached.Add(start.GetCoordinate(), start);

        while (queue.Count > 0)
        {

            Node temp = queue.Dequeue();

            if (temp.GetCoordinate() == end.GetCoordinate())
            {
                break;
            }

            foreach (Vector2Int vector in direction)
            {
                Vector2Int nextCoordinate = temp.GetCoordinate() + vector;
                if (grid.ContainsKey(nextCoordinate) && !reached.ContainsKey(nextCoordinate)&& grid[nextCoordinate].isPlaceable)
                {
                    Node nextNode = grid[nextCoordinate];
                    nextNode.connectTo = temp;
                    queue.Enqueue(nextNode);
                    reached.Add(nextCoordinate, nextNode);
                }
            }
        }

        List<Node> result = new List<Node>();
        Node n = reached[end.GetCoordinate()];
        while(n!= null)
        {
            result.Add(n);
            n = n.connectTo;
        }
        result.Reverse();
        
        queue.Clear();
        reached.Clear();
        ResetNodes();
        return result;
    }
}
