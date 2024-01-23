using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] int pointsToAdd;


    private NumberField scoreField;  // Removed the serialized field

    void Start() {
        // Try to find the NumberField component in the scene
        scoreField = FindObjectOfType<NumberField>();

        // Check if the NumberField component is found
        if (scoreField == null) {
            Debug.LogError("NumberField not found in the scene!");
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Collision with: " + other.name);
        Debug.Log("Object tag: " + other.tag);

        if (other.tag == "Stone" && scoreField!=null) {
            scoreField.AddNumber(-5);
        }
        else if (other.tag == "TreasureBox" && scoreField!=null) {
            scoreField.AddNumber(25);
        }
        else if (other.tag == "Emerald" && scoreField!=null) {
            scoreField.AddNumber(50);
        }
        else if (other.tag == "Gold" && scoreField!=null) {
            scoreField.AddNumber(10);
        }
        else if (other.tag == "Gold Sack" && scoreField!=null) {
            scoreField.AddNumber(15);
        }
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }
    
}
