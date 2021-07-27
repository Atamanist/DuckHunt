using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private float _time;
    private float _timeCurrent;
    private Image _image;
    [SerializeField] private UnityEvent _tick;
    private AudioSource _tickSound;


    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _tickSound = GetComponent<AudioSource>();
        _timeCurrent = _time;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    public void SetTime(float i)
    {
        _time = i;
    }

    private void Turn()
    {
        _timeCurrent -= Time.deltaTime;

        if (_timeCurrent <= 0)
        {
            _tick.Invoke();
            _timeCurrent = _time;
            _tickSound.Play();
        }
        _image.fillAmount = _timeCurrent / _time;

    }
}
