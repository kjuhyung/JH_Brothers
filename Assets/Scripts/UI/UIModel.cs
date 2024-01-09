
using UnityEngine;

public class UIModel : MonoBehaviour
{
    public int curStage { get; private set; }
    public int curRound { get; private set; }

    public int curScore { get; private set; }

    public int curLife { get; private set; }

    public float curTime { get; set; }

    public void InIt()
    {
        curScore = 0;
        curLife = 3;
        curTime = 90f;
    }

    public void ChangeRound(int round)
    {
        curRound = round;
    }

    public void ChangeStage(int stage)
    {
        curStage = stage;
        curRound = 1;
    }
    
    public int ChangeScore(int value)
    {
        curScore = curScore + value;

        return curScore;
    }

    public int ChangeLife(int value)
    {
        curLife = curLife - value;

        return curLife;
    }

    public void ChangeTime()
    {
        curTime -= Time.deltaTime;
    }
}
