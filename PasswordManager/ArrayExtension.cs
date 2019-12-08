using System;

namespace Password_Manager {
    public static class ArrayExtension {
        public static T[] Shuffle<T>(this T[] array, Random r) {
            for (int i = array.Length; i > 0; i--) {
                int j = r.Next(i);
                T k = array[j];
                array[j] = array[i - 1];
                array[i - 1] = k;
            }
            return array;
        }
    }
}
