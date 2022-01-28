using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public int Clicks = 0;
    [SerializeField] private TextMeshProUGUI ClickTextMeshPro;
    private Animator _TextAnimator;
    private Animator _ButtonAnimator;
    [SerializeField] private ParticleSystem ParticleSystem;

    private void Start()
    {
        _ButtonAnimator = GetComponent<Animator>();
        _TextAnimator = ClickTextMeshPro.GetComponent<Animator>();
        GetScore();
    }
    public void AddScore()
    {
        Clicks++;
        ClickTextMeshPro.text = Clicks.ToString();
        _ButtonAnimator.Rebind();
        _ButtonAnimator.SetBool("Click", true);
        _TextAnimator.Rebind();
        _TextAnimator.SetBool("Click" + Random.Range(1, 2+1), true);
        ParticleSystem.Play();
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
