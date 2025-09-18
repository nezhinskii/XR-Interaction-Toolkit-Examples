using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    private bool hasPlayed = false;
    private XRGrabInteractable grabInteractable;
    private float sceneStartTime;
    private float delayAfterStart = 1.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Time.time - sceneStartTime < delayAfterStart)
        {
            return;
        }

        if (audioSource != null && audioSource.clip != null && !hasPlayed)
        {
            bool isGrabbed = grabInteractable != null && grabInteractable.isSelected;
            Vector3 cubePosition = transform.position;
            Vector3 collisionPoint = collision.contacts[0].point;
            if (!isGrabbed && collisionPoint.y < cubePosition.y && collision.relativeVelocity.magnitude > 0.2f)
            {
                audioSource.PlayOneShot(audioSource.clip);
                hasPlayed = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        hasPlayed = false;
    }
}