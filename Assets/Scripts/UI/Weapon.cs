using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _textName, _textPrise, _textDamage, _buttonText;
    [SerializeField] private Sprite _spriteIcon, _spriteButtonPay, _spriteButtonUsed;
    [SerializeField] private int _prise, _damage;
    [SerializeField] private string _name;

    private PlayerMoney _playerMoney;
    private PlayerAttack _playerAttack;
    private GameObject[] _butons;

    private bool _bought = false;

    private void Start()
    {
        _buttonText.text = "Pay";
        _button.image.sprite = _spriteButtonPay;
        _icon.sprite = _spriteIcon;
        _textName.text = _name;
        _textDamage.text = "Damage: " + _damage.ToString();
        _textPrise.text = "Prise: " + _prise.ToString();
        _playerMoney = GameObject.FindObjectOfType<PlayerMoney>();
        _playerAttack = GameObject.FindObjectOfType<PlayerAttack>();
        _butons = GameObject.FindGameObjectsWithTag("WeaponButton");
    }

    public void Sell()
    {
        if (!_bought)
        {
            if (_playerMoney.CountMoney >= _prise)
            {
                _playerMoney.WithdrawMoney(_prise);
                _playerAttack.ChangeWeapon(_damage);
                _bought = true;
                CheckSpriteButton();
                _button.image.sprite = _spriteButtonUsed;
                _buttonText.text = "Used";
            }
        }
        else
        {
            _playerAttack.ChangeWeapon(_damage);
            CheckSpriteButton();
            _button.image.sprite = _spriteButtonUsed;
            _buttonText.text = "Used";
        }
    }

    private void CheckSpriteButton()
    {
        foreach (GameObject buton in _butons)
        {
            Button button = buton.GetComponent<Button>();
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            button.image.sprite = _spriteButtonPay;
            if (text.text != "Pay")
                text.text = "Bought";
        }
    }
}
