using UnityEngine;

public class ControllingAspectRatio : MonoBehaviour
{
    private float _targetAspect;
    private float _screenWidth;
    private float _screenHeight;
    private Camera _camera;

    private void Start () 
    {
        _targetAspect = 16.0f / 9.0f;

        float windowAspect = (float)Screen.width / (float)Screen.height;
        _screenWidth = (float)Screen.width;
        _screenHeight = (float)Screen.height;
        float scaleHeight = windowAspect / _targetAspect;

        _camera = GetComponent<Camera>();

        UpdateCameraRect(scaleHeight);
    }


    private void Update()
    {
        float newScreenWidth = (float)Screen.width;
        float newScreenHeight = (float)Screen.height;
        float newWindowAspect = (float)Screen.width / (float)Screen.height;

        if(_screenWidth != newScreenWidth || _screenHeight != newScreenHeight)
        {
            
            float newScaleHeight = newWindowAspect / _targetAspect;

            UpdateCameraRect(newScaleHeight);

            _screenWidth = newScreenWidth;
            _screenHeight = newScreenHeight;
        }
    }

    private void UpdateCameraRect(float scaleHeight)
    {
        if (scaleHeight < 1.0f)
            {  
                Rect rect = _camera.rect;

                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
                
                _camera.rect = rect;
            }
            else
            {
                float scaleWidth = 1.0f / scaleHeight;

                Rect rect = _camera.rect;

                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;

                _camera.rect = rect;
            }
    }
}
