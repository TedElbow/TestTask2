using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PresentDetector : MonoBehaviour
{
    private float _currentRange;
    bool _moveStarted = false;
    [SerializeField] private Text _presentsCount;
    [SerializeField] private GameObject _endScreen;

    private void Update()
    {
        if (_moveStarted)
        {
            if (this.GetComponent<Rigidbody>().velocity.z == 0)
            {
                _currentRange = this.transform.position.z;
                WhatPresent();
                _moveStarted = false;
            }
        }
    }
    private void WhatPresent()
    {
        int n = (int)_currentRange;
        int a = n / 9;
        if(a % 2 == 0)
        {
            int cubes = a + 2;
            _presentsCount.text = cubes.ToString();
            _endScreen.SetActive(true);
        }
        else
        {
            _presentsCount.text = ("ничего");
            _endScreen.SetActive(true);
        }
    }
    public void Jump() // скорость дается только после окончания анимации
    {
        _moveStarted = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
