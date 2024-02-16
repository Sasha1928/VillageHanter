using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiHealf : MonoBehaviour
{
    [SerializeField] private float _healf;
    [SerializeField] private int _money;
    [SerializeField] private Slider _slider;

    private Animator _animator;
    private PlayerMoney _playerMoney;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMoney = FindAnyObjectByType<PlayerMoney>();
        if(_slider != null)
        {
            _slider.maxValue = _healf;
        }
    }

    public void GetDamage(float Damage)
    {
        _healf -= Damage;
        if (_healf > 0)
            _animator.SetTrigger("Hurt");
        else
            _animator.SetTrigger("Death");
        if (_slider != null)
        {
            _slider.value = _healf;
        }
    }

    private void Death()
    {
        _playerMoney.GetMoney(_money);
        Destroy(gameObject);
    }
    
}
