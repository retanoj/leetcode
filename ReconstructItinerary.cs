using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace leetcode
{
    class ReconstructItinerary
    {
        Dictionary<string, Dictionary<string, int>> ticketsDict = new Dictionary<string, Dictionary<String, int>>();

        public bool dfs(Dictionary<string, Dictionary<string,int>> dict, int resultLen, string nodeName, List<string> result)
        {
            if (result.Count == resultLen) { return true; }
            if (dict.ContainsKey(nodeName))
            {
                foreach (string k in dict[nodeName].Keys)
                {
                    if (ticketsDict[nodeName][k] != 0)
                    {
                        ticketsDict[nodeName][k] -= 1;
                        result.Add(k);
                        if (dfs(dict, resultLen, k, result)) { return true; }
                        ticketsDict[nodeName][k] += 1;
                        result.RemoveAt(result.Count - 1);
                    }
                }
            }
            return false;
        }

        public IList<string> FindItinerary(string[,] tickets)
        {
            List<string> result = new List<string>();
            
            for (int t = 0; t < tickets.GetLongLength(0); t++)
            {

                if (ticketsDict.ContainsKey(tickets[t,0]))
                {
                    if (ticketsDict[tickets[t, 0]].ContainsKey(tickets[t, 1])) { ticketsDict[tickets[t, 0]][tickets[t, 1]] += 1; }  //有可能出现多张同样的票
                    else { ticketsDict[tickets[t, 0]].Add(tickets[t, 1], 1); }
                }
                else
                {
                    ticketsDict.Add(tickets[t, 0], new Dictionary<string, int>());
                    ticketsDict[tickets[t, 0]].Add(tickets[t, 1], 1);
                }

            }

            //inner dict sort
            Dictionary<string, Dictionary<string, int>> sortTicketsDict = new Dictionary<string, Dictionary<string, int>>();
            foreach (string key in ticketsDict.Keys)
            {
                Dictionary<string, int> t = new Dictionary<string, int>();
                t = (from p in ticketsDict[key] orderby p.Key select p).ToDictionary(pair => pair.Key, pair => pair.Value);
                sortTicketsDict.Add(key, t);
            }
            result.Add("JFK");
            dfs(sortTicketsDict, (int)tickets.GetLongLength(0) + 1, "JFK", result);
            
            return result;
        }
    }
}
