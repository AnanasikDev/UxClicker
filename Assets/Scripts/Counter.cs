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
    [SerializeField] private ParticleSystem ParticleSystem50;
    [SerializeField] private ParticleSystem ParticleSystem100;
    [SerializeField] private ParticleSystem ParticleSystem250;
    [SerializeField] private ParticleSystem ParticleSystem500;
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
        _ButtonAnimator.SetTrigger("Click");
        _TextAnimator.Rebind();

        if (Clicks % 1000 == 0)
        {
            Debug.Log("S");
            ParticleSystem1000.Play();
            PlayPresentsEffect();
            _TextAnimator.SetTrigger("Click1000");
        }
        else if (Clicks % 500 == 0)
        {
            ParticleSystem500.Play();
            _TextAnimator.SetTrigger("Click500");
        }
        else if (Clicks % 250 == 0)
        {
            ParticleSystem250.Play();
            _TextAnimator.SetTrigger("Click250");
        }
        else if (Clicks % 100 == 0)
        {
            ParticleSystem100.Play();
            PlayPresentsEffect();
            _TextAnimator.SetTrigger("Click100");
        }

        if (Clicks % 50 == 0)
            ParticleSystem50.Play();
        if (Clicks % 25 == 0)
            ParticleSystem25.Play();
        if (Clicks % 10 == 0)
            ParticleSystem10.Play();

        else
        {
            var particleSystem = Instantiate(ParticleSystem);
            particleSystem.Play();
            Destroy(particleSystem.gameObject, 6);
            _TextAnimator.SetTrigger("Click" + Random.Range(1, 2 + 1));
        }
        
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
