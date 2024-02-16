using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionLife : MonoBehaviour
{
    [SerializeField] private int _forgePotion;
    [SerializeField] private TMP_Text _text;
    private PlayerHealf _playerHealf;
    private int _countPotion = 5;

    private void Start()
    {
        _playerHealf = GameObject.FindObjectOfType<PlayerHealf>();
        _text.text = _countPotion.ToString();
    }

    private bool ChackPlayerHealf()
    {
        if (_playerHealf.Healf < 99)
           return true;

        return false;
    }

    public void Drink()
    {
        if (ChackPlayerHealf() && _countPotion > 0)
        {
            _playerHealf.GetPotion(_forgePotion);
            _countPotion--;
            _text.text = _countPotion.ToString();   
        }
    }

    public void GetPotion()
    {
        _countPotion++;
        _text.text = _countPotion.ToString();
    }

}
