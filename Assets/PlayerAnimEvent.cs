using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    private Learn learn;
    void Start()
    {
        learn = GetComponentInParent<Learn>();
    }

    private void AnimationTrigger()
    {
        learn.AttackOver();
    }
}
