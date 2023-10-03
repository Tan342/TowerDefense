using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI balanceText;
    // Start is called before the first frame update

    public void UpdateBalance(int amount)
    {
        balanceText.text = amount.ToString() + " $";
    }
}
