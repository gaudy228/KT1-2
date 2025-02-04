using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private Image bar;
    [SerializeField] private float time;
    private void Start()
    {
        DOTween.To(OnUpdate, 0, 1, time).SetEase(Ease.Linear);
    }

    private void OnUpdate(float deltaTime)
    {
        textTimer.text = deltaTime.ToString();
        bar.fillAmount = deltaTime;
    }
}
