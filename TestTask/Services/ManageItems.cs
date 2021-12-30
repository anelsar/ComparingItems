using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.Services
{
    public class ManageItems : IManageItems
    {

        // adding new opponent to a list of opponents an item has played against 
        // this is needed for generating a new pair based on matches that already have been played
        // this function is used for assigning all matches between opponents
        // we keep track of the matches that have been played with this function
        public List<SingleItemOpponents> AssignAlreadyPlayedAgainstOpponenstToItems(List<SingleItemOpponents> itemDetails, List<SingleItemOpponents> matchesPlayed)
        {
            for (int i = 0; i < matchesPlayed.Count; i++) // assigns all opponenst to an item against an item has played a match
            {
                if (itemDetails.Exists(x => x.SingleItem.Name == matchesPlayed[i].SingleItem.Name))
                {
                    itemDetails.Find(s => s.SingleItem.Name == matchesPlayed[i].SingleItem.Name).PlayedAgainst.Add(matchesPlayed[i].PlayedAgainst[0]);
                }
                else
                {
                    itemDetails.Add(matchesPlayed[i]);
                }
            }

            return itemDetails;
        }

        // adding new opponent to list of opponents an item has played against 
        // this is needed for generating a new pair based on already played matches
        // this function is used for assigning A NEW MATCH to an item
        public List<SingleItemOpponents> AssignNewPlayedOpponentToItem(SingleItemOpponents firstOpponent, SingleItemOpponents secondOpponent, List<SingleItemOpponents> opponentDetails)
        {
            if (opponentDetails.Count == 0)
            {
                opponentDetails.Add(firstOpponent);
                opponentDetails.Add(secondOpponent);
            }
            else
            {
                if (opponentDetails.Exists(x => x.SingleItem.Name == firstOpponent.SingleItem.Name))
                {
                    opponentDetails.Find(x => x.SingleItem.Name == firstOpponent.SingleItem.Name).PlayedAgainst.Add(firstOpponent.PlayedAgainst[0]);
                    opponentDetails.Find(x => x.SingleItem.Name == firstOpponent.SingleItem.Name).SingleItem.Score += firstOpponent.SingleItem.Score;
                }
                else
                {
                    opponentDetails.Add(firstOpponent);
                }
                if (opponentDetails.Exists(x => x.SingleItem.Name == secondOpponent.SingleItem.Name))
                {
                    opponentDetails.Find(x => x.SingleItem.Name == secondOpponent.SingleItem.Name).PlayedAgainst.Add(secondOpponent.PlayedAgainst[0]);
                    opponentDetails.Find(x => x.SingleItem.Name == secondOpponent.SingleItem.Name).SingleItem.Score += secondOpponent.SingleItem.Score;
                }
                else
                {
                    opponentDetails.Add(secondOpponent);
                }
            }

            return opponentDetails;
        }
        public List<Item> SortItemsDescending(List<Item> items)
        {
            return items.OrderByDescending(x => x.Score).ToList();
        }


        public List<Item> CorrectItemPosition(List<Item> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Position = i + 1; // correcting the items position based on the score
            }

            return items;
        }
      
    }
}