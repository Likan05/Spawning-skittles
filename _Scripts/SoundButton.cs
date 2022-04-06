using UnityEngine;
using UnityEngine.Events;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private UnityEvent _pressed;

    private Transform _transform;
    private float _cordinateY;

    private void Start()
    {
        _transform = gameObject.transform;
        _cordinateY = _transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        float howLongY = 0.5f;
        if (other.TryGetComponent<Bot>(out Bot bot))
        {
            _pressed?.Invoke();            
            _transform.position = new Vector3(_transform.position.x, (howLongY - _transform.position.y), _transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Bot>(out Bot bot))
        {
            _transform.position = new Vector3(_transform.position.x, _cordinateY, _transform.position.z);
        }
    }
}
