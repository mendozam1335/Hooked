/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Static class to hold the score and pass between scenes
 * GameObjects associated: None
 * Files Associated: Player Stats
 * Source:
 *--------------------------------*/
public static class ScoreData
{
    public static float score;

    public static void ResetScore()
    {
        score = 0f;
    }

    public static void UpdateScore(float value)
    {
        score += value;
    }
}
