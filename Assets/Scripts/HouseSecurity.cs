using UnityEngine;

public class HouseSecurity : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private void Start()
    {
        if (_alarmSystem is null)
            enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _alarmSystem.TurnOn();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            _alarmSystem.TurnOff();
        }
    }
}