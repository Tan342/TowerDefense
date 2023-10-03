using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
//[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    [SerializeField] Color exploretColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    //GridManager gridManager;

    private void Awake()
    {
        label = GetComponentInChildren<TextMeshPro>();
        label.enabled = false;
        //gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();
        // SetLabelColor();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        // SetLabelColor();
        ToggleLabels();
    }

    // void SetLabelColor()
    // {
    //     if (gridManager == null)
    //     {
    //         return;
    //     }

    //     Node node = gridManager.GetNode(coordinates);

    //     if (node == null)
    //     {
    //         return;
    //     }

    //     if (!node.isWalkable)
    //     {
    //         label.color = blockedColor;
    //     }
    //     else if (node.isPath)
    //     {
    //         label.color = pathColor;
    //     }
    //     else if (node.isExplored)
    //     {
    //         label.color = exploretColor;
    //     }
    //     else
    //     {
    //         label.color = defaultColor;
    //     }

    // }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }

    void DisplayCoordinates()
    {
        // if (gridManager == null) { return;}
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 5);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 5);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}