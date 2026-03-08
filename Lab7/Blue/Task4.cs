namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            private int _matchCount;

            public string Name => _name;
            
            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_matchCount];
                    for (int i = 0; i < _matchCount; i++)
                        copy[i] = _scores[i];
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < _matchCount; i++)
                        sum += _scores[i];
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[100];
                _matchCount = 0;
            }

            public void PlayMatch(int result)
            {
                _scores[_matchCount] = result;
                _matchCount++;
            }

            public void Print()
            {
                Console.Write($"{Name} {TotalScore} ");
                for (int i = 0; i < _matchCount; i++)
                    Console.Write($"{_scores[i]} ");
                Console.WriteLine();
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _teamCount;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamCount = 0;
            }

            public void Add(Team team)
            {
                if (_teamCount < 12)
                {
                    _teams[_teamCount] = team;
                    _teamCount++;
                }
            }

            public void Add(Team[] teams)
            {
                for (int i = 0; i < teams.Length && _teamCount < 12; i++)
                {
                    _teams[_teamCount] = teams[i];
                    _teamCount++;
                }
            }

            public void Sort()
            {
                for (int i = 0; i < _teamCount - 1; i++)
                {
                    for (int j = 0; j < _teamCount - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                
                group1.Sort();
                group2.Sort();
                
                Team[] teams1 = group1.Teams;
                Team[] teams2 = group2.Teams;
                
                int count1 = 0;
                int count2 = 0;
    
                for (int i = 0; i < teams1.Length; i++)
                {
                    if (teams1[i].Name != null) count1++;
                }
    
                for (int i = 0; i < teams2.Length; i++)
                {
                    if (teams2[i].Name != null) count2++;
                }
                
                int teamsFromEach = size / 2;
                
                Team[] candidates = new Team[size];
                int candidateCount = 0;
                
                for (int i = 0; i < teamsFromEach && i < count1; i++)
                {
                    candidates[candidateCount] = teams1[i];
                    candidateCount++;
                }
                
                for (int i = 0; i < teamsFromEach && i < count2; i++)
                {
                    candidates[candidateCount] = teams2[i];
                    candidateCount++;
                }
                
                for (int i = 0; i < candidateCount - 1; i++)
                {
                    for (int j = i + 1; j < candidateCount; j++)
                    {
                        if (candidates[i].TotalScore < candidates[j].TotalScore)
                        {
                            (candidates[i], candidates[j]) = (candidates[j], candidates[i]);
                        }
                    }
                }
                
                for (int i = 0; i < candidateCount; i++)
                {
                    result.Add(candidates[i]);
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine(Name);
                for (int i = 0; i < _teamCount; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }
}
