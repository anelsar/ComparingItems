using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Services
{
    public interface IManageItems
    {
        List<SingleItemOpponents> AssignAlreadyPlayedAgainstOpponenstToItems(List<SingleItemOpponents> itemDetails, List<SingleItemOpponents> matchesPlayed);
        List<SingleItemOpponents> AssignNewPlayedOpponentToItem(SingleItemOpponents firstOpponent, SingleItemOpponents secondOpponent, List<SingleItemOpponents> opponentDetails);
        List<Item> CorrectItemPosition(List<Item> items);
        List<Item> SortItemsDescending(List<Item> items);
    }
}