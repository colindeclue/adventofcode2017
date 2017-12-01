public static class Day01 {
    public static int Part1(string input) {
        return DoDay1(input, true);
    }

    public static int Part2(string input) {
        return DoDay1(input, false);
    }

    private static int DoDay1(string input, bool part1) {
        var step = part1 ? 1 : input.Length / 2;
        int sum = 0;
        for(int i = 0; i < input.Length; i++) {
            if(input[i] == input[(i + step) % input.Length]) {
                sum += int.Parse(input[i].ToString());
            }
        }

        return sum;
    }
}