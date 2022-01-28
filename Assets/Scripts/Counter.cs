using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public int Clicks = 0;
    [SerializeField] private TextMeshProUGUI ClickTextMeshPro;
    private Animator _Animator;

    private void Start()
    {
        _Animator = GetComponent<Animator>();
        GetScore();
    }
    public void AddScore()
    {
        Clicks++;
        ClickTextMeshPro.text = Clicks.ToString();
        _Animator.Rebind();
        _Animator.SetBool("Click", true);
        SaveScore();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", Clicks);
    }
    public void GetScore()
    {
        Clicks = PlayerPrefs.GetInt("score", Clicks);
        ClickTextMeshPro.text = Clicks.ToString();
    }
}
