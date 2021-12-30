using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.Services
{
    public static class GeneratePair
    {
        // generating the first pair
        public static ShowPairsViewModel GenerateInitialRandomPair(List<Item> items, List<int> randomValues)
        {
            var firstOpponent = items.Find(x => x.Position == randomValues.First());
            var secondOpponent = items.Find(x => x.Position == randomValues.Last());
            ShowPairsViewModel pair = new ShowPairsViewModel
            {
                FirstOpponent = firstOpponent,
                SecondOpponent = secondOpponent
            };
            return pair;
        }

        // generating every other pair except the first one
        public static ShowPairsViewModel GenerateNewPair(List<Item> items, List<SingleItemOpponents> alreadyPlayedMatches)
        {
            Item opponent1 = null;
            Item opponent2 = null;

            for (int i = 0; i < items.Count; i++)
            {
                if (alreadyPlayedMatches.Exists(x => x.SingleItem.Name == items[i].Name))
                {
                    var z = alreadyPlayedMatches.Find(x => x.SingleItem.Name == items[i].Name);
                    if (z.PlayedAgainst.Count < items.Count - 1)
                    {
                        opponent1 = items[i];
                        break;
                    }
                }
                else
                {
                    opponent1 = items[i];
                    break;
                }
            }

            

            if(opponent1 != null) // ovo znaci da imamo jos raspolozivih parova
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (alreadyPlayedMatches.Exists(x => x.SingleItem.Name == items[i].Name)) // gledam ako je item[i] vec igrao matcheve
                    {
                        var z = alreadyPlayedMatches.Find(x => x.SingleItem.Name == items[i].Name); // uzimam taj item
                        if (z.PlayedAgainst.Count < items.Count - 1 && z.SingleItem.Name != opponent1.Name && (z.PlayedAgainst.Exists(y => y.Name == opponent1.Name) == false)) // ako ima manje odigranih meceva od brojItema-1 
                        {                                                                                 // i ako se razlikuje od prvog izabranog opponenta
                            opponent2 = items[i];
                            break;
                        }
                    }

                    else if (items[i].Name != opponent1.Name) // ako item nikako nije igrao matcheve i ako se razlikuje od prvog odabranog protivnika
                    {
                        opponent2 = items[i];
                        break;
                    }
                }
            }

            ShowPairsViewModel pair = new ShowPairsViewModel
            {
                FirstOpponent = opponent1,
                SecondOpponent = opponent2
            };

            return pair;
        }
    }
}