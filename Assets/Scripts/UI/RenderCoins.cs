using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RenderCoins : MonoBehaviour
{
    [SerializeField] private PlayerMoney _money;

    private TMP_Text _text;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void LateUpdate()
    {
        _text.text = _money.CountMoney.ToString();
    }
}
