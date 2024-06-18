using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [Header("Flip Rotation Stats")]
    [SerializeField] private float _flipYRotationTime = 0.5f;
    private Coroutine _turnCoroutine;
    private Controls _player;
    private bool _isFacingRight;

    private void Awake() {
        _player = _playerTransform.gameObject.GetComponent<Controls>();
        _isFacingRight = _player.rightF;
    }

    private void Update() {
        transform.position = _player.transform.position;
    }

    public void CallTurn(){
        _turnCoroutine = StartCoroutine(FlipYLerp());
    }

    private IEnumerator FlipYLerp(){
        float startRoation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation();
        float yRotation = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < _flipYRotationTime){
            elapsedTime += Time.deltaTime;

            yRotation = Mathf.Lerp(startRoation, endRotationAmount, (elapsedTime / _flipYRotationTime));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

            yield return null;
        }
    }

    private float DetermineEndRotation(){
        _isFacingRight = !_isFacingRight;

        if(_isFacingRight){
            return 100f;
        }
        else{
            return 0f;
        }
    }
}