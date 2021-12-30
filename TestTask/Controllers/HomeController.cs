using System.Collections.Generic;
using System.Web.Mvc;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private  IItemsRepository _itemRepo;
        private  IManageItems _manageItems;
        private  IRandomValueGenerate _randomValGenerator;

        public HomeController(IItemsRepository itemRepo, IManageItems manageItems, IRandomValueGenerate randomValGenerator)
        {
            _itemRepo = itemRepo;
            _manageItems = manageItems;
            _randomValGenerator = randomValGenerator;
        }

        public ActionResult Index()
        {;
            var items = _itemRepo.LoadItems(); // load all items from file
            return View(items);
        }
        
        public ActionResult ShowPairs()
        {
            if(TempData["allPlayedMatches"] != null) // some matches have already been played
            {
                var items = _itemRepo.LoadItems(); // loading all items from file               
                var alreadyPlayedMatches = (List<SingleItemOpponents>) TempData["allPlayedMatches"]; // matches that already have been played
                var newPair = GeneratePair.GenerateNewPair(items, alreadyPlayedMatches); // generating a new pair based on played matches
               
                if (newPair.FirstOpponent == null || newPair.SecondOpponent == null) // no more match combinations avalible
                    TempData["allCombosPlayed"] = "All matches have been played!"; // message to show to the users

                return View(newPair);
            }
            else // first random match
            {
                var items = _itemRepo.LoadItems(); // getting all items
                var randomeValues = _randomValGenerator.GenerateValues(1, items.Count);
                var initialRandomPair = GeneratePair.GenerateInitialRandomPair(items, randomeValues);
               
                return View(initialRandomPair);
            }   
        }

        public ActionResult ManageItemsDetails(ShowPairsViewModel pair)
        {
            List<SingleItemOpponents> opponentDetails = new List<SingleItemOpponents>();
            var items = _itemRepo.LoadItems(); // loading items from file

            if (TempData["test"]!= null) // some matches have already been played
            {
                var playedMatches = (List<SingleItemOpponents>)TempData["test"]; // gets all matches that have been played
               opponentDetails = _manageItems.AssignAlreadyPlayedAgainstOpponenstToItems(opponentDetails, playedMatches); // managing items
            }

            SingleItemOpponents firstOpponent = new SingleItemOpponents();
            SingleItemOpponents secondOpoonent = new SingleItemOpponents();

            firstOpponent.SingleItem = pair.FirstOpponent; // first entered opponent
            secondOpoonent.SingleItem = pair.SecondOpponent; // second entered opponent

            // correcting the score value of the better team
            if (pair.FirstOpponentScore > pair.SecondOpponentScore) // if the first opponents score is greater
            {
                firstOpponent.SingleItem.Score += 1;
                items.Find(x => x.Name == firstOpponent.SingleItem.Name).Score += 1; // correcting the score for saving to the file later
            }
            else if (pair.SecondOpponentScore > pair.FirstOpponentScore) // if the second opponents score is greater
            {
                secondOpoonent.SingleItem.Score += 1;
                items.Find(x => x.Name == secondOpoonent.SingleItem.Name).Score += 1; // correcting score for saving to the file
            }

            firstOpponent.PlayedAgainst.Add(secondOpoonent.SingleItem); // adds opponent to playedAgainst list
            secondOpoonent.PlayedAgainst.Add(firstOpponent.SingleItem); // adds opponent to playedAgainst list

            opponentDetails = _manageItems.AssignNewPlayedOpponentToItem(firstOpponent, secondOpoonent, opponentDetails); // managing list of all teams which played a match
            //opponentDetails = opponentDetails.OrderByDescending(x => x.SingleItem.Score).ToList(); // sorting depending on the score

            items = _manageItems.SortItemsDescending(items); // sorting depending on the score
            items = _manageItems.CorrectItemPosition(items);  
            _itemRepo.StoreItems(items); // storing item changes

            TempData["allPlayedMatches"] = opponentDetails;
            return RedirectToAction("ShowPairs");
        }

       
    }
}