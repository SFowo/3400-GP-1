using UnityEngine;

public class RobotWalkSimulation : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource stompAudio;

    [Header("Bounce Settings")]
    public float bounceAmplitude = 2.0f;
    public AnimationCurve bounceCurve = new(
        new Keyframe(0f, -1f),
        new Keyframe(0.5f, 1f),
        new Keyframe(1f, -1f)
    );
    
    [Header("Forward Movement Settings")]
    public float forwardSpeed = 5.0f;
    public Vector3 forwardDirection = Vector3.back;

    private Vector3 initialPosition;
    private float audioLength;
    private float distanceTraveled = 0f;
    private bool isActive = true; 

    void Start()
    {
        if (!stompAudio || stompAudio.clip == null)
        {   
            Debug.LogError("Please assign an AudioSource with a valid audio clip.");
            return;
        }

        initialPosition = transform.position;
        audioLength = stompAudio.clip.length;

        stompAudio.Play();
    }

    void Update()
    {
        if (!isActive) return; 

        distanceTraveled += forwardSpeed * Time.deltaTime;

        if (stompAudio.isPlaying)
        {
            float t = stompAudio.time;
            float normalizedTime = (t % audioLength) / audioLength;

            if (float.IsNaN(normalizedTime) || float.IsInfinity(normalizedTime))
            {
                Debug.LogError("Invalid normalized time detected!");
                return;
            }

            float bounceOffset = bounceAmplitude * bounceCurve.Evaluate(normalizedTime);

            Vector3 horizontalOffset = forwardDirection.normalized * distanceTraveled;
            Vector3 newPos = initialPosition + horizontalOffset;
            newPos.y = initialPosition.y + bounceOffset;

            transform.position = newPos;
        }
    }

    public void StopSimulation()
    {
        isActive = false;
        if (stompAudio.isPlaying)
        {
            stompAudio.Stop();
        }
    }
}