using UnityEngine;
using UnityEngine.AI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private string _layerIndex = "Wounded";
    [SerializeField] private Character _character;
    [SerializeField] private float _blendSpeed = 3f;
    private float _deadZone = 0.05f;
    private readonly int IsRunningKeyAnimator = Animator.StringToHash("IsRun");
    private readonly float OnLayerWounded = 1f;
    private readonly float OffLayerWounded = 0f;
    private float _weight;

    public void Initialize(Character character)
    {
        _character = character;
    }

    private void Update()
    {
        UpdateMovementAnimation();
        UpdateHealthAnimation();
    }
    private void SetLayerWeight(float weight)
    {
        int layerIndex = _animator.GetLayerIndex(_layerIndex);

        if (layerIndex != -1)
            _animator.SetLayerWeight(layerIndex, weight);
    }
    private void UpdateMovementAnimation()
    {
        if (_agent.velocity.magnitude > _deadZone)
            StartRunning();
        else 
            StopRunning();
    }
    
    private void UpdateHealthAnimation()
    {
        bool isWounded = _character.Health.IsWounded;

        float targetWeight = isWounded ? OnLayerWounded : OffLayerWounded;
        _weight = Mathf.MoveTowards(_weight, targetWeight, _blendSpeed * Time.deltaTime);


        SetLayerWeight(_weight);
    }
    
    private void StartRunning() => _animator.SetBool(IsRunningKeyAnimator, true);
    private void StopRunning() => _animator.SetBool(IsRunningKeyAnimator, false);
}
        
        

