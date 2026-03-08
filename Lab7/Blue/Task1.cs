using System;

namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            private string name;
            private string surname;
            private int votes;

            public Response(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.votes = 0;
            }

            public string Name => name;
            public string Surname => surname;
            public int Votes => votes;

            public int CountVotes(Response[] responses)
            {
                int totalMatches = 0;
                
                for (int i = 0; i < responses.Length; i++)
                {
                    if (name == responses[i].name && surname == responses[i].surname)
                    {
                        totalMatches++;
                    }
                }
    
                int count = totalMatches;  
                
                for (int i = 0; i < responses.Length; i++)
                {
                    if (name == responses[i].name && surname == responses[i].surname)
                    {
                        responses[i].votes = count;  
                    }
                }
    
                votes = count;  
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}: {Votes} голосов");
            }
        }
    }
}
