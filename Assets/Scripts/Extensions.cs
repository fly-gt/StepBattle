public static class Extensions {

    public static int ZeroLerp(this int value) {
        if (value < 0) {
            value = 0;
        }

        return value;
    }

    public static int MaxLerp(this int value, int max) {
        if (value > max) {
            value = max;
        }

        return value;
    }
}
