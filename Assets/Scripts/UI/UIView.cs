using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _curRoundTxt;

    [SerializeField] private TextMeshProUGUI _scoreTxt;

    [SerializeField] private TextMeshProUGUI _lifeTxt;

    [SerializeField] private TextMeshProUGUI _leftTimeTxt;

    [SerializeField] private GameObject _gameOverUI;

    private void Awake()
    {
        _gameOverUI.SetActive(false);
    }

    public void UpdateRound(int stage, int round)
    {
        _curRoundTxt.text = stage.ToString() + " - " + round.ToString();
    }

    public void UpdateScore(int score)
    {
        _scoreTxt.text = score.ToString();
    }

    public void UpdateLife(int life)
    {
        _lifeTxt.text = life.ToString();
    }

    public void UpdateTime(float time)
    {
        _leftTimeTxt.text = string.Format("{0:D2}",(int)time);
        
        if (time < 20)
        {
            _leftTimeTxt.color = Color.red;
        }
    }

    public void GameOverUI()
    {
        _gameOverUI.SetActive(true);
    }
}
