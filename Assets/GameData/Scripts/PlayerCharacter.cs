using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;
    public float RotationOnY;
    private UIMANAGAER ui;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        ui = FindObjectOfType<UIMANAGAER>();
        GameObject crow = Instantiate(ui.playercrown, new Vector3(this.transform.position.x, ui.playercrown.transform.position.y, this.transform.position.z), ui.playercrown.transform.rotation);
        crow.transform.SetParent(this.transform);
        crow.SetActive(false);
    }
    void Start()
    {
        this.transform.DORotate(new Vector3(transform.eulerAngles.x, Vector3.forward.z, 0), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0, 1.1f, 0);
       

#if UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {
            float rotX = Input.GetAxis("Mouse X") * 15000 * Mathf.Deg2Rad;
            rotX = rotX * Time.deltaTime;
            transform.Rotate(new Vector3(0, rotX, 0), Space.World);
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float rotX = touchDeltaPosition.x * 15000 / 18 * Mathf.Deg2Rad;
            rotX = rotX * Time.deltaTime;
            transform.Rotate(new Vector3(0, rotX, 0), Space.World);
        }

#endif

    }


    public void Rotateme()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.localEulerAngles.y, 0) + new Vector3(0, 1, 0) * 10);
    }
    public void setrotation()
    {
        this.transform.DORotate(new Vector3(transform.eulerAngles.x, Vector3.forward.z, 0), 0.5f);
    }
}
