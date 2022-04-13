using SoccerScoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoreData.Dal
{
    public class DataManager
    {
        public Gender[] Genders { get; } = { Gender.Male, Gender.Female };

        private readonly Irepo repo;
        private readonly IList<NationalTeam> selectionTeams;
        public IList<NationalTeam> SelectionTeams
        {
            get
            {
                if (selectionTeams is null)
                    this.LoadSelectionTeams();
                return new List<NationalTeam>(SelectionTeams);
            }
        }

        private void LoadSelectionTeams()
        {
            throw new NotImplementedException();
        }

        private NationalTeam nationalTeam;

        public DataManager()
        {
            repo = RepoFactory.GetRepo();
        }
        
        
    }
}
