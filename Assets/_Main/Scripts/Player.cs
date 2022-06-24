using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce;
    float positionDelta;
    Rigidbody2D rb;
    bool upLimit;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //If user touch anywhere
        // bool input =  Input.touchCount > 0 || Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        // if(!input) return;

        // if(Input.touches[0].phase == TouchPhase.Began){
            
        // }

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    GameObject _other;
    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Triggerrrr");

        if(other.CompareTag("Ring")){
            GameManager.Instance.GameOver();
        }

        else if (other.CompareTag("Collectable")){
            GameManager.Instance.ScoreIncrease();
            _other = other.transform.parent.gameObject;
            Invoke(nameof(HideGameObject), 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameManager.Instance.GameOver();
    }

    void HideGameObject(){
        _other.gameObject.SetActive(false);
    }
}
