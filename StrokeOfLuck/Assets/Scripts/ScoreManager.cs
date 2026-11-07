using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

    private void Awake()
    {
        score = 0f;
    }

    public float GetScore()
    {
        return score;
    }
}
