using UnityEngine;
using System.Collections;


public class RayShooter : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f)));
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    { 
       
        _fireball = Instantiate(fireballPrefab) as GameObject;
        _fireball.transform.position = transform.TransformPoint(pos);
        _fireball.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(1); 
        Destroy(_fireball); 
    }
}