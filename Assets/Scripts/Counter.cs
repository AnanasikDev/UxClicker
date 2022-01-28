using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public int Clicks = 0;
    [SerializeField] private TextMeshProUGUI ClickTextMeshPro;
    private Animator _TextAnimator;
    private Animator _ButtonAnimator;
    [SerializeField] private ParticleSystem ParticleSystem;
    [SerializeField] private ParticleSystem ParticleSystem10;
    [SerializeField] private ParticleSystem ParticleSystem25;
    [SerializeField] private ParticleSystem ParticleSystem100;
    [SerializeField] private ParticleSystem ParticleSystem1000;
    [SerializeField] private ParticleSystem[] PresentParticleSystems;

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

        if (Clicks % 10 == 0)
            ParticleSystem10.Play();
        if (Clicks % 25 == 0)
            ParticleSystem25.Play();
        if (Clicks % 100 == 0)
        {
            ParticleSystem100.Play();
            PlayPresentsEffect();
            _TextAnimator.SetBool("Click100" + Random.Range(1, 2 + 1), true);
        }
        if (Clicks % 1000 == 0)
        {
            ParticleSystem1000.Play();
            PlayPresentsEffect();
            _TextAnimator.SetBool("Click1000" + Random.Range(1, 2 + 1), true);
        }
        else ParticleSystem.Play();
        SaveScore();
    }
    private void PlayPresentsEffect()
    {
        foreach (ParticleSystem particleSystem in PresentParticleSystems)
            particleSystem.Play();
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
