using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScore_WPF_edition.Models.ViewModels
{
    public class MatchListItemViewModel
    {
        private const string IMG_DIR = "Content/CountryImages/";
        private const string EXTENTION = ".jpg";

        public string FifaCode { get; set; }
        public string CountryImagePath { get => IMG_DIR + FifaCode + EXTENTION; }
    }
}
