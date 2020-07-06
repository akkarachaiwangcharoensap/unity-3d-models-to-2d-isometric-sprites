using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTankTopBehaviour : MonoBehaviour
{
    /**
     * <summary>
     * Current rotation degree value
     * </summary>
     */
    private int degree = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.RandomRotateEveryThreeSeconds());
    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
     * <summary>
     * Randomly rotate the sprite
     * </summary>
     *
     * <returns>
     * IEnumerator
     * </returns>
     */
    private IEnumerator RandomRotateEveryThreeSeconds ()
    {
        while (true)
        {
            int randomDegree = Random.Range(1, 360);

            Debug.Log("Rotate to: " + randomDegree);
            StartCoroutine(this.RenderAnimation(randomDegree));
            yield return new WaitForSeconds(3f);
        }
    }

    /**
     * <summary>
     * Render animations to a given degree
     * </summary>
     *
     * <returns>
     * IEnumerator
     * </returns>
     */
    private IEnumerator RenderAnimation(int degree)
    {
        while (this.degree != degree)
        {
            // Rotate
            this.Rotate(degree);

            string spriteName = "Sprites/Simple Tank/Top/" + this.Digits(this.degree);

            Sprite newSprite = Resources.Load<Sprite>(spriteName);
            SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
            sprite.sprite = newSprite;

            yield return null;
        }
    }

    /**
     * <summary>
     * Rotate
     * </summary>
     *
     * <param name="degree"></param>
     * 
     * <returns>
     * void
     * </returns>
     */
    private void Rotate(int degree)
    {
        // Determine should we rotate forward or backward
        if (this.RotateForward(degree))
        {
            this.degree++;
        }
        else
        {
            this.degree--;
        }
    }

    /**
     * <summary>
     * Determine if the game object should rotate forward or backward based on
     * the given degree
     * </summary>
     *
     * <param name="degree"></param>
     * 
     * <returns>
     * bool
     * </returns>
     */
    private bool RotateForward(int degree)
    {
        return degree - this.degree > 0;
    }

    /**
     * <summary>
     * Generate digits based on the given degree
     * </summary>
     *
     * <param name="degree"></param>
     * 
     * <returns>
     * string
     * </returns>
     */
    private string Digits(int degree)
    {
        string digits = "";
        string degreeString = degree.ToString();

        int current = degreeString.Length;
        int max = 4;
        while (current < max)
        {
            digits += "0";
            current++;
        }

        return digits + degreeString;
    }
}
