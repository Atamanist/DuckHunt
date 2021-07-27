using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Screen : MonoBehaviour
{
    [SerializeField]
    private GameObject 
        _screenMain,
        _screenGame,
        _screenGameOver,
        _screenGameWin;
    [SerializeField] 
    private Text _score;

    private void Start()
    {
        StartScreen();
    }

    public void GameScreen()
    {

        _screenGame.SetActive(true);
        _screenMain.SetActive(false);
        _screenGameOver.SetActive(false);
        _screenGameWin.SetActive(false);

    }

    public void LoseScreen()
    {
        _screenGame.SetActive(false);
        _screenMain.SetActive(false);
        _screenGameOver.SetActive(true);
        _screenGameWin.SetActive(false);

    }

    public void WinScreen()
    {
        _screenGame.SetActive(false);
        _screenMain.SetActive(false);
        _screenGameOver.SetActive(false);
        _screenGameWin.SetActive(true);

    }

    public void StartScreen()
    {
        _screenGame.SetActive(false);
        _screenMain.SetActive(true);
        _screenGameOver.SetActive(false);
        _screenGameWin.SetActive(false);
    }
}
