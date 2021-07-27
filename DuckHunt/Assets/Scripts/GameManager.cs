using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
#region Fields
{
    [SerializeField]
    private Timer
        _timerTurn,
        _timerHarvest,
        _timerFood;

    [SerializeField]
    private Text
    _text;

    [SerializeField]
    private ButtonTimer
        _timerPeasent,
        _timerWarrior;

    [SerializeField]
    private float
        _timePeasent,
        _timeWarrior,
        _timeTurn,
        _timeHarvest,
        _timeFood;

    [SerializeField]
    private Display _display;

    [SerializeField]
    private int
        _startFood,
        _startPeasent,
        _startWarrior;


    private int
        _countWarrior,
        _countPeasent,
        _countFood,
        _countEnemy,
        _countTurn;


    [SerializeField]
    private int
        _turnBeforeBarbarianCome,
        _costWarrior,
        _costPeasent,
        _foodEatPerWarrior,
        _foodProducePerPeasent,
        _barbarianPerRound,
        _winPeasent,
        _winWarrior,
        _winFood;


    [SerializeField] 
    UnityEvent<Dictionary<string, int>> 
        _displayChange,
        _displayRule;

    [SerializeField] 
    UnityEvent<int,float> 
        _panelChangeWarrior,
        _panelChangePeasent,
        _panelChangeEnemy;

    [SerializeField]
    private Screen _screen;


    private Dictionary<string, int> _fields,_rules;


    #endregion

    private void SetDisplay()
    {
        _countWarrior = _startWarrior;
        _countPeasent = _startPeasent;
        _countFood = _startFood;


        _fields = new Dictionary<string, int>
        {
            {"Peasent" , _countPeasent },
            {"Warrior" , _countWarrior },
            {"Food" , _countFood },
            {"Enemy" , _countEnemy },
            {"Turn" , _countTurn }
        };

        _rules = new Dictionary<string, int>
        {
            {"Peasent" , _winPeasent },
            {"Warrior" , _winWarrior },
            {"Food" , _winFood },
        };



        _displayChange.Invoke(_fields);
        _displayRule.Invoke(_rules);
        _panelChangeWarrior.Invoke(_fields["Warrior"], 99f);
        _panelChangePeasent.Invoke(_fields["Peasent"], 99f);
        _panelChangeEnemy.Invoke(_fields["Enemy"], 142f);

    }

    private void SetTime()
    {
        _timerFood.SetTime(_timeFood);
        _timerHarvest.SetTime(_timeHarvest);
        _timerTurn.SetTime(_timeTurn);
        _timerWarrior.SetTime(_timeWarrior);
        _timerPeasent.SetTime(_timePeasent);

    }

    public void HirePeasent()
    {
        if (CheckBuy(_fields["Food"], _costPeasent))
        {
            _fields["Food"] -= _costPeasent;
            _timerPeasent.SetCurrentTime(_timePeasent);
            _fields["Peasent"]++;
            _displayChange.Invoke(_fields);
            _panelChangePeasent.Invoke(_fields["Peasent"],99f);

        }

    }

    public void HireWarrior()
    {
        if (CheckBuy(_fields["Food"], _costWarrior))
        {
            _fields["Food"] -= _costWarrior;
            _timerWarrior.SetCurrentTime(_timeWarrior);
            _fields["Warrior"]++;
            _displayChange.Invoke(_fields);
            _panelChangeWarrior.Invoke(_fields["Warrior"],99f);

        }
    }

    public void TurnEating()
    {
        _fields["Food"] -= _fields["Warrior"] * _foodEatPerWarrior;
        _displayChange.Invoke(_fields);

    }

    public void TurnHarvesting()
    {
        _fields["Food"] += _fields["Peasent"] * _foodProducePerPeasent;
        _displayChange.Invoke(_fields);

    }

    private void CheckFoodWarrior()
    {
        if (_fields["Food"] < 0)
        {
            _fields["Warrior"] = 0;
        }

    }

    private void CheckBattle()
    {
        if (_fields["Turn"] > _turnBeforeBarbarianCome)
        {
            _panelChangeEnemy.Invoke(_fields["Enemy"],142f);
            _fields["Warrior"] -= _fields["Enemy"];
            _fields["Enemy"] += _barbarianPerRound;
        }

    }

    public void Turn()
    {
        CheckEnemyCome();
        CheckFoodWarrior();
        CheckBattle();
        CheckWinOrLose();
        _displayChange.Invoke(_fields);
        _fields["Turn"]++;


    }

    private bool CheckBuy(int i, int j)
    {
        if (i >= j)
        {
            return true;
        }
        else
            return false;
    }

    private void CheckEnemyCome()
    {
        if (_fields["Turn"] < _turnBeforeBarbarianCome)
        {
            _text.text = $"Season open in {_turnBeforeBarbarianCome - _fields["Turn"]}";
        }
        else
        {
            _text.text = $"Season open";
        }
    }

    private void CheckWinOrLose()
    {
        if(_fields["Food"]<0||_fields["Enemy"]>_fields["Warrior"])
        {
            _screen.LoseScreen();
        }
        if (_fields["Food"] > _winFood || _fields["Warrior"] > _winWarrior|| _fields["Peasent"] > _winPeasent)
        {
            _screen.WinScreen();
        }
    }

    public void SetGame()
    {
        SetTime();
        SetDisplay();
    }


}
