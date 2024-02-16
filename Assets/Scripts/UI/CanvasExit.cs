using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasExit : MonoBehaviour
{
    public void Exit(GameObject _canvas)
    {
       _canvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
