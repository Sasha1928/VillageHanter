using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLvl : MonoBehaviour
{
    [SerializeField] private GameObject[] _lvl;

    private CheckEnemiCount _enemiCount;

    private void Start()
    {
        _enemiCount = GameObject.FindAnyObjectByType<CheckEnemiCount>();
        _lvl[_enemiCount.lvlCompleteCount].SetActive(true);
    }
}
