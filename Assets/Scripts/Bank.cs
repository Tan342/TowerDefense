using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] BankUI bankUI;

    public int CurrentBalance { get { return currentBalance; } }

     private void Awake()
    {
        currentBalance = startingBalance;
        bankUI.UpdateBalance(currentBalance);
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        bankUI.UpdateBalance(currentBalance);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        bankUI.UpdateBalance(currentBalance);
        // if (currentBalance < 0)
        // {
        //     ReloadScene();
        // }
    }
}
