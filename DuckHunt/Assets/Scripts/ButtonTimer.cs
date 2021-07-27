using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTimer : MonoBehaviour
{
    private float _time;
    private float _timeCurrent;
    private Image _image;
    private AudioSource _tickSound;
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _tickSound = GetComponent<AudioSource>();
        _timeCurrent = -_time;
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

    public void SetCurrentTime(float i)
    {
        _timeCurrent = i;
    }


    private void Turn()
    {

        if (_timeCurrent > 0)
        {
            _timeCurrent -= Time.deltaTime;
            _image.fillAmount = _timeCurrent / _time;

            _button.interactable = false;
        }
        else if(_timeCurrent > -1)
        {
            _button.interactable = true;
            _image.fillAmount = 1;
            _timeCurrent = -2;
            _tickSound.Play();
        }

    }


}
