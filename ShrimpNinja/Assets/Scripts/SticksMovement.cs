using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public class SticksMovement : MonoBehaviour
{
    [SerializeField] private Transform _transformShrimp;
    [SerializeField] private float _distanse;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _tickDuration;
    
    private readonly Vector3[] _allSides = new[] { Vector3.right, Vector3.up, Vector3.down, Vector3.left };

    private int _dodgedCount;
    
    public delegate void DodgeCountDelegate(int amount);
    public event DodgeCountDelegate OnCountChange;
    
    private void Start()
    {
        StartCoroutine(StickTick());
    }

    IEnumerator StickTick()
    {
        while (true)
        {
            StickMove();

            yield return new WaitForSeconds(_tickDuration);
        }
    }
    
    private void StickMove()
    {
        Vector3 side = _getRandomSide();
        _moveStickToRandomSide(side);
        _rotateStickToShrimp();
        StartCoroutine(MoveStick(-side));
    }
    
    IEnumerator MoveStick(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;
        while (timeElapsed < _moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition * _distanse, timeElapsed / _moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        _dodgedCount++;
        OnCountChange?.Invoke(_dodgedCount);
    }

    private int RandomSide()
    {
        int randomNumber = Random.Range(0, 3);
        return randomNumber;
    }

    private Vector3 _getRandomSide()
    {
        return _allSides[RandomSide()];
    }

    private void _moveStickToRandomSide(Vector3 moveTo)
    {
        transform.position = _transformShrimp.position + moveTo * _distanse;
    }

    private void _rotateStickToShrimp()
    {
        Vector2 direction = _transformShrimp.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.Rotate(0,0,-90);
    }
}