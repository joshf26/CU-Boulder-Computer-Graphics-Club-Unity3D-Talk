using UnityEngine;

public class Controller : MonoBehaviour {
    public int numBalls;
    public GameObject ball;

    public Transform arena;

    private void Start() {
        var biggestSize = 0.9f;
        
        for (var i = 0; i < numBalls; i++) {
            var scale = Random.Range(0.5f, biggestSize);
            biggestSize += scale/4;

            var localScale = arena.localScale;
            
            var spawnSizeX = localScale.x/2 - scale;
            var spawnSizeY = localScale.y/2 - scale;
            
            var position = new Vector3(
                Random.Range(-spawnSizeX, spawnSizeX),
                scale/2f,
                Random.Range(-spawnSizeY, spawnSizeY)
            );
            
            var newBall = Instantiate(ball, position, Quaternion.identity);
            newBall.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}