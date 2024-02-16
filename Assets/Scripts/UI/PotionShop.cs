using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionShop : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _textName, _textPrise;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _prise;
    [SerializeField] private string _name;

    private PlayerMoney _playerMoney;
    private PotionLife _potion;

    private bool _bought = false;

    private void Start()
    {
        _icon.sprite = _sprite;
        _textName.text = _name;
        _textPrise.text = "Prise: " + _prise.ToString();
        _playerMoney = GameObject.FindObjectOfType<PlayerMoney>();
        _potion = GameObject.FindObjectOfType<PotionLife>();

    }

    public void Sell()
    {
        if (_playerMoney.CountMoney >= _prise)
        {
            _playerMoney.WithdrawMoney(_prise);
            _potion.GetPotion();
        }
    }
}
