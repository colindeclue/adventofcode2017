public class Scanner {
    public int Depth { get; }

    public int Level { get; }

    // private int _currentDepth = 0;

    public Scanner(int level, int depth) {
        this.Depth = depth;
        this.Level = level;
    }

    public int DoStep(int playerPosition) {
        if(playerPosition % this.Depth == 0) {
            return this.Level * this.Depth;
        }

        return 0;
    }
}