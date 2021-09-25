using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
    Rigidbody2D character;

    void Start() {
        character = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            jump();
        }
        if (Input.GetButton("Horizontal")) {
            move();
        }
    }

    void move() {
        float moveSpeed = 10f;

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(transform.position.x) < 7.7)
            character.transform.Translate(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    void jump() {
        float jumpSpeed = 750f;
        if (transform.position.y < -2.1)
            character.AddForce(Vector2.up * jumpSpeed);
    }
}
