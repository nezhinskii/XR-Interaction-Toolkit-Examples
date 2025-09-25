using Unity.XR.CoreUtils;
using UnityEngine;

public class AnimationScale : MonoBehaviour
{
    private Animator animator;
    private bool isAnimating = false;
    private BoxCollider boxCollider;
    private Vector3 baseScale;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        baseScale = transform.localScale;
    }

    void Update()
    {
        if (boxCollider != null)
        {
            Vector3 currentScale = transform.localScale;
            boxCollider.size = currentScale.Divide(baseScale);
        }
    }

    public void PlayAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            animator.SetTrigger("Play");
            Invoke("ResetAnimation", 1.5f);
        }
    }

    void ResetAnimation()
    {
        isAnimating = false;
    }
}