using DG.Tweening;
using UnityEngine;

public class DOTweenController : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 _targetLoaction = Vector3.zero;

    [SerializeField] private Vector3 _targetRotation = Vector3.zero;

    [Range(1.0f, 10.0f), SerializeField] 
    private float _moveDuration;
    
    [Range(1.0f, 10.0f), SerializeField] 
    private float _rotationDuration;

    [SerializeField] 
    private Ease _ease = Ease.Linear;

    [SerializeField] 
    private DoTweenType _doTweenType = DoTweenType.MovementOneWay;
    
    private enum DoTweenType
    {
        MovementOneWay,
        MovementTwoWays,
        MovementOneWayColorChange,
        MovementLoop,
        RotateOneWay,
        RotateLoop
    }

    private void Start()
    {
        if (_doTweenType == DoTweenType.MovementOneWay)
        {
            if (_targetLoaction == Vector3.zero)
                _targetLoaction = transform.position;
            transform.DOMove(_targetLoaction, _moveDuration).SetEase(_ease);
        }
        else if (_doTweenType == DoTweenType.MovementTwoWays)
        {
            if (_targetLoaction == Vector3.zero)
                _targetLoaction = transform.position;
            transform.DOMove(_targetLoaction, _moveDuration).SetEase(_ease).SetLoops(2);
        }
        else if (_doTweenType == DoTweenType.MovementLoop)
        {
            if (_targetLoaction == Vector3.zero)
                _targetLoaction = transform.position;
            Vector3 originalLocation = transform.position;
            transform.DOMove(_targetLoaction, _moveDuration).SetEase(_ease).SetLoops(-1, LoopType.Yoyo);
        }

        else if (_doTweenType == DoTweenType.MovementOneWayColorChange)
        {
            if (_targetLoaction == Vector3.zero)
                _targetLoaction = transform.position;
            DOTween.Sequence()
                .Append(transform.DOMove(_targetLoaction, _moveDuration).SetEase(_ease));
        }   
        
        else if (_doTweenType == DoTweenType.RotateOneWay)
        {
            if (_targetRotation == Vector3.zero)
                _targetRotation = transform.rotation.eulerAngles;
            transform.DORotate(_targetRotation, _rotationDuration).SetEase(_ease);
        }
        
        else if (_doTweenType == DoTweenType.RotateLoop)
        {
            if (_targetRotation == Vector3.zero)
                _targetRotation = transform.rotation.eulerAngles;
            transform.DORotate(_targetRotation, _rotationDuration)
                .SetEase(_ease)
                .SetLoops(-1)
                .SetRelative();
        }
    }
    
}
