using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HRClimbingTheLeaderboard {
    class Program {
        static void Main(string[] args) {

            int[] scores = { 50, 100, 50, 40, 40, 20, 10 };
            int[] alice = { 5, 25, 50, 120 };

            List<int> leaderboard = new List<int>();
            List<int> placementarr = new List<int>();

            foreach(var score in scores) {
                if(!leaderboard.Contains(score)) {
                    leaderboard.Add(score);
                }               
            }

            leaderboard.Sort();
            var lowest = leaderboard.Min(); // combine both arrays, then use IndexOf for the alice values and return those/export to a new array. Also try hashset
            var highest = leaderboard.Max();

            foreach(var ascore in alice) {

                if(ascore > highest) { placementarr.Add(1); continue; }
                if(ascore < lowest)  { placementarr.Add(leaderboard.Count + 1); continue; }

                var rank = 0;

                foreach (var lbscore in leaderboard) {

                    var placement = leaderboard.Count() - rank + 1;
                    var equalplacement = leaderboard.Count() - rank;

                    if(ascore == lbscore) {
                        placementarr.Add(equalplacement);
                        break;
                    }
                    if(ascore > lbscore) {
                        rank++;
                        continue;
                    } else {
                        placementarr.Add(placement);
                        break;
                    }
                }
            }
            ;
            foreach(var p in placementarr.ToArray()) {
                Console.WriteLine(p);
            }
        }
    }
}
