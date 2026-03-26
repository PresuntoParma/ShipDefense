using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    [SerializeField] private Text textScore;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        textScore.text = score.ToString();
    }
}
