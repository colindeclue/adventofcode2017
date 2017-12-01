public static class Day01 {

    public static int Part1(string input) {
        var step = 1;
        int sum = 0;
        for(int i = 0; i < input.Length; i++) {
            if(input[i] == input[(i + step) % input.Length]) {
                sum += int.Parse(input[i].ToString());
            }
        }

        return sum;
    }

    public static int Part2(string input) {
        var step = input.Length / 2;
        int sum = 0;
        for(int i = 0; i < input.Length / 2; i++) {
            if(input[i] == input[(i + step) % input.Length]) {
                sum += 2 * int.Parse(input[i].ToString());
            }
        }

        return sum;
    }
}