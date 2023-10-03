using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPos;
    [SerializeField] GameObject ballista;
    [SerializeField] GameObject house;
    [SerializeField] int ballistaPrice;
    [SerializeField] int housePrice;
    [SerializeField] GridManager gridManager;
    [SerializeField] GameObject temp;

    Bank bank;
    GameObject tower;
    Node node;
    LayerMask layermask;
    int price;
    bool isBuilding = false;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
        temp.SetActive(false);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProcessMouseClick();
        }
        if(Input.GetMouseButtonDown(1))
        {
            SetIsBuilding(false);
        }
        if(isBuilding)
        {
            DisplayMousePos();
        }

    }

    void DisplayMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
        {

            Vector3 pos = gridManager.RoundPos(raycastHit.point);
            temp.transform.position = new Vector3(pos.x, 1, pos.z);
        }
    }

    void ProcessMouseClick()
    {
        node = gridManager.GetNodeFromPosition(temp.transform.position);
        if (node != null && isBuilding && node.isPlaceable)
        {
            Build(node.transform.position);
            gridManager.SetPlaceable(node.transform.position, false);
        }
    }


    void BuiltBallista()
    {
        if(bank.CurrentBalance < ballistaPrice)
        {
            return;
        }

        tower = ballista;
        price = ballistaPrice;
        SetIsBuilding(true);
    }

    void BuiltHouse()
    {
        if (bank.CurrentBalance < housePrice)
        {
            return;
        }

        tower = house;
        price = housePrice;
        SetIsBuilding(true);
    }

    void Build(Vector3 pos)
    {
        GameObject t = Instantiate(tower,pos,Quaternion.identity);
        t.transform.parent = spawnPos.transform;
        bank.Withdraw(price);
        SetIsBuilding(false);
    }

    void SetIsBuilding(bool value)
    {
        isBuilding = value;
        temp.SetActive(value);
    }

}
