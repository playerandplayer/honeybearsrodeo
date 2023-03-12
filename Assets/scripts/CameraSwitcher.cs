using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // an array of all the cameras in the scene
    private int currentCameraIndex; // the index of the current camera being used

    void Start()
    {
        currentCameraIndex = 0; // start with the first camera in the array
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // Check for input to switch cameras
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Increment the camera index and activate the next camera
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0; // loop back to the first camera
            }
            ActivateCamera(currentCameraIndex);
        }
    }

    // Activates the specified camera and deactivates all others
    void ActivateCamera(int cameraIndex)
    {
        // Deactivate all cameras
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        // Activate the specified camera
        cameras[cameraIndex].gameObject.SetActive(true);
    }

    // Called by buttons to switch to the next camera in the array
    public void NextCamera()
    {
        currentCameraIndex++;
        if (currentCameraIndex >= cameras.Length)
        {
            currentCameraIndex = 0;
        }
        ActivateCamera(currentCameraIndex);
    }

    // Called by buttons to switch to the previous camera in the array
    public void PreviousCamera()
    {
        currentCameraIndex--;
        if (currentCameraIndex < 0)
        {
            currentCameraIndex = cameras.Length - 1;
        }
        ActivateCamera(currentCameraIndex);
    }
}
