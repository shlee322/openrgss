using OpenTK.Input;
using System;
namespace OpenRGSS.Runtime.RGSS
{
    public class Input
    {
        public enum Keys
        {
            DOWN = 0,
            LEFT = 1,
            RIGHT = 2,
            UP = 3,
            A = 4,
            B = 5,
            C = 6,
            X = 7,
            Y = 8,
            Z = 9,
            L = 10,
            R = 11, 
            SHIFT = 12,
            CTRL = 13,
            ALT = 14,
            F5 = 15,
            F6 = 16,
            F7 = 17,
            F8 = 18,
            F9 = 19 
        }

        public class Key {}
        public class DOWN : Key { public static Keys getKey() { return Keys.DOWN; } }
        public class LEFT : Key { public static Keys getKey() { return Keys.LEFT; } }
        public class RIGHT : Key { public static Keys getKey() { return Keys.RIGHT; } }
        public class UP : Key { public static Keys getKey() { return Keys.UP; } }
        public class A : Key { public static Keys getKey() { return Keys.A; } }
        public class B : Key { public static Keys getKey() { return Keys.B; } }
        public class C : Key { public static Keys getKey() { return Keys.C; } }
        public class X : Key { public static Keys getKey() { return Keys.X; } }
        public class Y : Key { public static Keys getKey() { return Keys.Y; } }
        public class Z : Key { public static Keys getKey() { return Keys.Z; } }
        public class L : Key { public static Keys getKey() { return Keys.L; } }
        public class R : Key { public static Keys getKey() { return Keys.R; } }
        public class SHIFT : Key { public static Keys getKey() { return Keys.SHIFT; } }
        public class CTRL : Key { public static Keys getKey() { return Keys.CTRL; } }
        public class ALT : Key { public static Keys getKey() { return Keys.ALT; } }
        public class F5 : Key { public static Keys getKey() { return Keys.F5; } }
        public class F6 : Key { public static Keys getKey() { return Keys.F6; } }
        public class F7 : Key { public static Keys getKey() { return Keys.F7; } }
        public class F8 : Key { public static Keys getKey() { return Keys.F8; } }
        public class F9 : Key { public static Keys getKey() { return Keys.F9; } }

        private static int[] keyData = new int[20];
        private static KeyboardState state;

        private static int GetKeyIndex(Keys key)
        {
            return (int)key;
        }

        private static void UpdateKey(OpenTK.Input.Key oKey, Keys key)
        {
            if (state.IsKeyDown(oKey))
            {
                keyData[GetKeyIndex(key)]++;
            }
            if (state.IsKeyUp(oKey))
            {
                keyData[GetKeyIndex(key)] = -1;
            }
        }

        private static int GetKeyData(Keys key)
        {
            return keyData[GetKeyIndex(key)];
        }

        public static void update()
        {
            state = OpenTK.Input.Keyboard.GetState();
            UpdateKey(OpenTK.Input.Key.Down, Keys.DOWN);
            UpdateKey(OpenTK.Input.Key.Left, Keys.LEFT);
            UpdateKey(OpenTK.Input.Key.Right, Keys.RIGHT);
            UpdateKey(OpenTK.Input.Key.Up, Keys.UP);
            UpdateKey(OpenTK.Input.Key.ShiftLeft, Keys.A);
            //UpdateKey(OpenTK.Input.Key.ShiftRight, Keys.A);
            //UpdateKey(OpenTK.Input.Key.Z, Keys.A);
            UpdateKey(OpenTK.Input.Key.Escape, Keys.B);
            //UpdateKey(OpenTK.Input.Key.Number0, Keys.B);
            //UpdateKey(OpenTK.Input.Key.X, Keys.B);
            UpdateKey(OpenTK.Input.Key.Space, Keys.C);
            //UpdateKey(OpenTK.Input.Key.Enter, Keys.C);
            //UpdateKey(OpenTK.Input.Key.C, Keys.C);
            UpdateKey(OpenTK.Input.Key.A, Keys.X);
            UpdateKey(OpenTK.Input.Key.S, Keys.Y);
            UpdateKey(OpenTK.Input.Key.D, Keys.Z);
            UpdateKey(OpenTK.Input.Key.Q, Keys.L);
            UpdateKey(OpenTK.Input.Key.W, Keys.R);
            UpdateKey(OpenTK.Input.Key.ShiftLeft, Keys.SHIFT);
            //UpdateKey(OpenTK.Input.Key.ShiftRight, Keys.SHIFT);
            UpdateKey(OpenTK.Input.Key.ControlLeft, Keys.CTRL);
            //UpdateKey(OpenTK.Input.Key.ControlRight, Keys.CTRL);
            UpdateKey(OpenTK.Input.Key.AltLeft, Keys.ALT);
            //UpdateKey(OpenTK.Input.Key.AltRight, Keys.ALT);
            UpdateKey(OpenTK.Input.Key.F5, Keys.F5);
            UpdateKey(OpenTK.Input.Key.F6, Keys.F6);
            UpdateKey(OpenTK.Input.Key.F7, Keys.F7);
            UpdateKey(OpenTK.Input.Key.F8, Keys.F8);
            UpdateKey(OpenTK.Input.Key.F9, Keys.F9);
        }

        public static bool pressQM(Keys num)
        {
            return GetKeyData(num) > -1;
        }

        public static bool triggerQM(Keys num)
        {
            return GetKeyData(num) == 0;
        }

        public static bool repeatQM(Keys num)
        {
            int data = GetKeyData(num);
            return data == 0 || (data > 10 && data % 4 == 0); 
        }

        public static int dir4()
        {
            if (pressQM(Keys.DOWN)) return 2;
            if (pressQM(Keys.LEFT)) return 4;
            if (pressQM(Keys.RIGHT)) return 6;
            if (pressQM(Keys.UP)) return 8;
            return 0;
        }

        public static int dir8()
        {
            System.Console.WriteLine("Input.dir8()");
            return 0;
        }
    }
}
