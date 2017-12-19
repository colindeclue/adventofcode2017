public static class DirectionExtensions {
    public static Direction[] GetTurns(this Direction direction) {
        if(direction == Direction.Up || direction == Direction.Down) {
            return new [] { Direction.Left, Direction.Right };
        }

        return new [] { Direction.Up, Direction.Down };
    }
}