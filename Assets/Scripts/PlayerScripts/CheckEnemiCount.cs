using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnemiCount : MonoBehaviour
{
    [SerializeField] private GameObject _TheEndLvl;

    private int _lvlCompleteCount = 0;
    private GameObject[] _enemiHealfs;

    public int lvlCompleteCount => _lvlCompleteCount;


    private void LateUpdate()
    {
        _enemiHealfs = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enemiHealfs.Length <= 0 && SceneManager.GetActiveScene().name != "Loby")
            _TheEndLvl.SetActive(true);
        else
            _TheEndLvl.SetActive(false);
    }

    public void GoToLoby()
    {
        _lvlCompleteCount++;
        _TheEndLvl.SetActive(false);
        SceneManager.LoadScene("Loby");
    }
}
