using System.Collections;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [Header("Настройки сигнализации")]
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _volumeChangeRate = 0.5f;

    private float _targetVolume;

    private void Start()
    {
        if (_alarmSound is null)
        {
            enabled = false;
            return;
        }

        _maxVolume = Mathf.Clamp(_maxVolume, _minVolume, _maxVolume);

        _alarmSound.volume = _minVolume;
    }

    private IEnumerator ChangeVolumeRoutine(float targetVolume)
    {
        while (Mathf.Approximately(_alarmSound.volume, targetVolume) == false)
        {
            _alarmSound.volume = Mathf.MoveTowards(
                _alarmSound.volume,
                targetVolume,
                Time.deltaTime * _volumeChangeRate
            );

            yield return null;
        }

        _alarmSound.volume = targetVolume;

        if (Mathf.Approximately(targetVolume, _minVolume))
            _alarmSound.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            StopAllCoroutines();

            if (_alarmSound.isPlaying == false)
                _alarmSound.Play();
        }

        StartCoroutine(ChangeVolumeRoutine(_maxVolume));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            StopAllCoroutines();

            StartCoroutine(ChangeVolumeRoutine(_minVolume));
        }
    }
}