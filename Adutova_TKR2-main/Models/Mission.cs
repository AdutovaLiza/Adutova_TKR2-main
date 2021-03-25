using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adutova_TKR2.Models
{
    public class Mission
    {
        static int MaxId = 0;
        public int Id { get; private set; }
        public string MissionTask { get; private set; } //содержание
        public bool IsComplete { get; private set; }
        public List<int> EmployersId { get; private set; }

        public Mission(string mission)
        {
            MaxId++;
            Id = MaxId;
            MissionTask = mission;
            IsComplete = false;
            EmployersId = new List<int>();
        }
        public void Done()
        {
            IsComplete = !IsComplete;
        }

        public void SetEmployer(int id)
        {
            EmployersId.Add(id);
        }

        public void ChangeTask(string mission)
        {
           MissionTask = mission;
        }

    }
}
