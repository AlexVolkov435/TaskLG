using UnityEngine;

public class ThirdTypePitfall : MonoBehaviour
{
    [SerializeField] Transform _rotationCentre;

    private float _rotationSpeedPitfall = 3f;

    private bool _isCollision = false;

    private void FixedUpdate()
    {
        if (_isCollision == true)
        {
            _rotationCentre.RotateAround(_rotationCentre.transform.position, transform.up, _rotationSpeedPitfall);
        }
        else {; }
    }

    private void OnCollisionEnter()
    {
        _isCollision = true;
    }
}
