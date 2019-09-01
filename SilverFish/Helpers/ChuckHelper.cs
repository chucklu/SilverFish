﻿using System.Collections.Generic;
using System.Linq;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class ChuckHelper
    {
        public static bool EvenShamanChecked { get; set; }

        public static bool IsEvenShaman { get; set; }

        public static void Reset()
        {
            EvenShamanChecked = false;
            IsEvenShaman = false;
        }

        public static void EvenShamanCheck(Dictionary<CardDB.cardIDEnum, int> dictionary)
        {
            if (EvenShamanChecked)
            {
                return;
            }

            if (dictionary.Keys.Contains(CardDB.cardIDEnum.GIL_692))
            {
                bool isEvenShaman = true;
                foreach (var item in dictionary.Keys)
                {
                    var card = CardDB.Instance.getCardDataFromID(item);
                    if (card.cost % 2 != 0)
                    {
                        isEvenShaman = false;
                        break;
                    }
                }

                if (isEvenShaman)
                {
                    IsEvenShaman = true;
                }
            }

            EvenShamanChecked = true;
        }

        public static int GetOwnHeroPowerCost()
        {
            if (EvenShamanChecked && IsEvenShaman)
            {
                return 1;
            }

            return 2;
        }
    }
}