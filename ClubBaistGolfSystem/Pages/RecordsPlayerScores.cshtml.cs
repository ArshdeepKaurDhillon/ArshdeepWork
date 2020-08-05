using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClubBaistGolfSystem.Domain;
using System.ComponentModel.DataAnnotations;
namespace ClubBaistGolfSystem.Pages
{
    public class RecordsPlayerScoresModel : PageModel
    {       
        [BindProperty]
        [Required]
        public string Course { get; set; }
        [BindProperty]
        [Required]
        public string MemberNumber { get; set; }
        [BindProperty]
        [Required]
        public decimal Rating { get; set; }
        [BindProperty]
        [Required]
        public int Slope { get; set; }
        [BindProperty]
        [Required]
        public string Date { get; set; }
        [BindProperty]
        public int Score { get; set; }
        [BindProperty]
        public int Hole1 { get; set; }
        [BindProperty]
        public int Hole2 { get; set; }
        [BindProperty]
        public int Hole3 { get; set; }
        [BindProperty]
        public int Hole4 { get; set; }
        [BindProperty]
        public int Hole5 { get; set; }
        [BindProperty]
        public int Hole6 { get; set; }
        [BindProperty]
        public int Hole7 { get; set; }
        [BindProperty]
        public int Hole8 { get; set; }
        [BindProperty]
        public int Hole9 { get; set; }
        [BindProperty]
        public int Hole10 { get; set; }
        [BindProperty]
        public int Hole11 { get; set; }
        [BindProperty]
        public int Hole12 { get; set; }
        [BindProperty]
        public int Hole13 { get; set; }
        [BindProperty]
        public int Hole14 { get; set; }
        [BindProperty]
        public int Hole15 { get; set; }
        [BindProperty]
        public int Hole16 { get; set; }
        [BindProperty]
        public int Hole17 { get; set; }
        [BindProperty]
        public int Hole18 { get; set; }
        [BindProperty]
        public double HandicapDifferential { get; set; }

        public string Message { get; set; }
       
        public void OnGet()
        {
      
        }
        public void OnPost()
        {
            PlayerScore NewPlayerScore = new PlayerScore();
            NewPlayerScore.MemberNumber = MemberNumber;
            NewPlayerScore.Course = Course;
            NewPlayerScore.Date = Date;
            NewPlayerScore.Rating = Rating;
            NewPlayerScore.Slope = Slope;
            NewPlayerScore.Hole1 = Hole1;
            NewPlayerScore.Hole2 = Hole2;
            NewPlayerScore.Hole3 = Hole3;
            NewPlayerScore.Hole4 = Hole4;
            NewPlayerScore.Hole5 = Hole5;
            NewPlayerScore.Hole6 = Hole6;
            NewPlayerScore.Hole7 = Hole7;
            NewPlayerScore.Hole8 = Hole8;
            NewPlayerScore.Hole9 = Hole9;
            NewPlayerScore.Hole10 = Hole10;
            NewPlayerScore.Hole11 = Hole11;
            NewPlayerScore.Hole12 = Hole12;
            NewPlayerScore.Hole13 = Hole13;
            NewPlayerScore.Hole14 = Hole14;
            NewPlayerScore.Hole15 = Hole15;
            NewPlayerScore.Hole16 = Hole16;
            NewPlayerScore.Hole17 = Hole17;
            NewPlayerScore.Hole18 = Hole18;
            NewPlayerScore.Score = Hole1 + Hole2 + Hole3 + Hole4 + Hole5 + Hole6 + Hole7 + Hole8 + Hole9 + Hole10 + Hole11 +
                                   Hole12 + Hole13 + Hole14 + Hole15 + Hole16 + Hole17 + Hole18;

            decimal HandicapDifferential = ((NewPlayerScore.Score - NewPlayerScore.Rating) * 113 / NewPlayerScore.Slope);

            decimal round = Math.Round(HandicapDifferential);

            NewPlayerScore.HandicapDifferential = round;

            CBGS RequestDirector = new CBGS();
            bool Confirmation;

            if (ModelState.IsValid)
            { 
            Confirmation = RequestDirector.InsertPlayerScore(NewPlayerScore);

            if (Confirmation)
            {
                Message = "Score is:  " + NewPlayerScore.Score + ";HandicapDiffrential is:  " + NewPlayerScore.HandicapDifferential;
            }
            
            else                
                 Message = "Player Score Not Recorded";            
            }
        }
    }
}
