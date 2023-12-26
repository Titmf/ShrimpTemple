using System.Collections;
using UnityEngine;

using Random = UnityEngine.Random;

public class SticksMovement : MonoBehaviour
{
    [SerializeField] private Transform _transformShrimp;
    [SerializeField] private float _distance;
    [SerializeField] private float _tickDuration;
    [SerializeField] private float _tickShrinknessMoveDuration;
    [SerializeField] private float _defaultMoveDuration;
    [SerializeField] private float _moveDuration;

    private readonly Vector3[] _allSides = new[] { Vector3.right, Vector3.up, Vector3.down, Vector3.left };

    private const int DodgedCountMultiplier = 1;
    private Vector3 _side;
    
    public delegate void DodgeCountDelegate(int amount);
    public event DodgeCountDelegate ThenDodged;

    public void StartGame()
    {
        _moveDuration = _defaultMoveDuration;
        SetStickNewPosition();
        StartCoroutine(StickTick());
    }
    
    public void StopGame()
    {
        StopAllCoroutines();
    }

    IEnumerator StickTick()
    {
        while (true)
        {
            BeforeMoveStick();

            _moveDuration -= _tickShrinknessMoveDuration;
            
            yield return new WaitForSeconds(_tickDuration);
        } 
    }
    
    IEnumerator MoveStick(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;
        while (timeElapsed < _moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition * _distance, timeElapsed / _moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        ThenDodged?.Invoke(DodgedCountMultiplier);
    }

    private void BeforeMoveStick()
    {
        _side = _getRandomSide();
        SetStickNewPosition();
        StartCoroutine(MoveStick(-_side));
    }

    private void SetStickNewPosition()
    {
        _moveStickToRandomSide(_side);
        _rotateStickToShrimp();
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
        transform.position = _transformShrimp.position + moveTo * _distance;
    }

    private void _rotateStickToShrimp()
    {
        Vector2 direction = _transformShrimp.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.Rotate(0,0,-90);
    }
}