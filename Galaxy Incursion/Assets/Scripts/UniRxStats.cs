using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class UniRxStats : MonoBehaviour
{
    public static UniRxStats uniRxStats;

    public Text _hpText;
    public Text _levelText;
    public Text _scoreText;
    public Text _ammunitionText;
    public int score;
    public int level;
    private int _ammunition = 0;

    private CompositeDisposable _disposables = new CompositeDisposable();   

    public void GetAmmunition()
    {
        
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _ammunition++;
            _ammunitionText.text = "You got: "+ _ammunition + "bullets";
            if (_ammunition == 1000)
            {
                _disposables.Clear();
                StartCoroutine(AmmunitionCarutine());
            }
        }).AddTo(_disposables);
      
    }

    private IEnumerator AmmunitionCarutine()
    {
       float countDown = 2.5f;
        for (int i = 0; i < 2500; i++)
        {
            while (countDown >= 0)
            {
                _ammunitionText.text = "Ammunition is Full!!!";
                countDown -= Time.smoothDeltaTime;
                yield return null;
            }
            _ammunitionText.enabled = false;
        }
    }

    public void AddScore(int point)
    {
        score += point;
        _scoreText.text = score.ToString();

        if (score > 100 * level)
        {
            level++;
            _levelText.text = level.ToString();
            score = 0;
            
        }    
    }

    public void Save()
    {
        SaveLoadManager.SavePlayer(this);        
    }

    public void Load()
    {
        int[] loadedStats = SaveLoadManager.LoadPlayer();

        level = loadedStats[0];
        score = loadedStats[1];
        _levelText.text = level.ToString();
        _scoreText.text = score.ToString();
        Stats.Score = score;
    }

    public void UpdateHp(int hp)
    {
        _hpText.text = $"HP: {hp}";
    }
}
