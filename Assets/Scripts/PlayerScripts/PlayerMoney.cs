using Cainos.LucidEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _countMoney;
    public int CountMoney => _countMoney;

    public void WithdrawMoney(int WeaponPrise)
    {
        _countMoney -= WeaponPrise;
    }

    public void GetMoney(int EnemyPrise)
    {
        _countMoney += EnemyPrise;
    }
}