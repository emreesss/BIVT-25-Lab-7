namespace Lab7.Blue
{
    public class Task2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;
            private int _jumpCounter;

            public string Name => _name;
            public string Surname => _surname;
            
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
                _jumpCounter = 0;
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return new int[0, 0];

                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;

                    int sum = 0;
                    foreach (int mark in _marks)
                    {
                        sum += mark;
                    }

                    return sum;
                }
            }
            

            public void Jump(int[] result)
            {
                if (result == null || result.Length != 5 || _jumpCounter >= 2) return;

                for (int i = 0; i < 5; i++)
                {
                    _marks[_jumpCounter, i] = result[i];
                }

                _jumpCounter++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
    
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.Write($"{Name} {Surname} {TotalScore} ");

                if (_marks != null)
                {
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            Console.Write($"{_marks[i, j]} ");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
