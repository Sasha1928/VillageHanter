using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakeVisible : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        _button.SetActive(false);
    }

    public void ButtonClick()
    {
        _shop.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadSene(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
}
