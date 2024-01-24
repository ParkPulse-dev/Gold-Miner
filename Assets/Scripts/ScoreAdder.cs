using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] int pointsToAdd;


    private NumberField scoreField;  // Removed the serialized field

    void Start()
    {
        // Try to find the NumberField component in the scene
        scoreField = FindObjectOfType<NumberField>();

        // Check if the NumberField component is found
        if (scoreField == null)
        {
            Debug.LogError("NumberField not found in the scene!");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the score field is not null before updating the score
        if (scoreField != null)
        {
            // Check the tag of the collided object and update the score accordingly
            if (other.tag == "Stone")
            {
                // Reduce score by 5 for colliding with a Stone
                scoreField.AddNumber(-5);
            }
            else if (other.tag == "TreasureBox")
            {
                // Increase score by 25 for colliding with a TreasureBox
                scoreField.AddNumber(25);
            }
            else if (other.tag == "Emerald")
            {
                // Increase score by 50 for colliding with an Emerald
                scoreField.AddNumber(50);
            }
            else if (other.tag == "Gold")
            {
                // Increase score by 10 for colliding with Gold
                scoreField.AddNumber(10);
            }
            else if (other.tag == "Gold Sack")
            {
                // Increase score by 15 for colliding with a Gold Sack
                scoreField.AddNumber(15);
            }
        }
    }
    public void SetScoreField(NumberField newTextField)
    {
        this.scoreField = newTextField;
    }
}
