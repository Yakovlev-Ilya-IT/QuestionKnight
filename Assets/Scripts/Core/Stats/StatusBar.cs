using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    [SerializeField] private Image _fill;
    [SerializeField] private float _updateSpeed;
    private const int FullFilling = 1;

    public void Init()
    {
        _fill.fillAmount = FullFilling;
    }

    public void SetFilling(float valueAsPercantage)
    {
        StartCoroutine(ChangeToValue(valueAsPercantage));
    }

    private IEnumerator ChangeToValue(float valueAsPercantage)
    {
        float previousValue = _fill.fillAmount;
        float elapsed = 0f;

        while(elapsed < _updateSpeed)
        {
            elapsed += Time.deltaTime;
            _fill.fillAmount = Mathf.Lerp(previousValue, valueAsPercantage, elapsed/ _updateSpeed);
            yield return null;
        }

        _fill.fillAmount = valueAsPercantage;
    }
}
