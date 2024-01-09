using UnityEngine;

public class UIController : CustomSingleTon<UIController>
{
    private UIModel _UIModel;

    [SerializeField] private UIView _UIView;

    private void Awake()
    {
        _UIModel = new UIModel();
        _UIModel.InIt();

        _UIView.UpdateRound(_UIModel.curStage, _UIModel.curRound);
        _UIView.UpdateScore(_UIModel.curScore);
        _UIView.UpdateLife(_UIModel.curLife);       
    }

    private void Update()
    {
        _UIModel.ChangeTime();
        _UIView.UpdateTime(_UIModel.curTime);

        if( _UIModel.curTime <= 0)
        {
            RoundOver();
        }         
    }

    public void ChangeRound(int round)
    {
        _UIModel.ChangeRound(round);
        _UIView.UpdateRound(_UIModel.curStage, _UIModel.curRound);
    }

    public void ChangeStage(int stage)
    {
        _UIModel.ChangeStage(stage);
        _UIView.UpdateRound(_UIModel.curStage, _UIModel.curRound);
    }

    public void AddScore(int value)
    {
        _UIView.UpdateScore(_UIModel.ChangeScore(value));                
    }

    public void ReduceLife(int value)
    {
        _UIModel.ChangeLife(value);
        _UIView.UpdateLife(_UIModel.curLife);
    }

    private void RoundOver()
    {
        ReduceLife(1);
        _UIModel.curTime = 70f;
    }

    public void GameOver()
    {
        _UIView.GameOverUI();
    }

}
