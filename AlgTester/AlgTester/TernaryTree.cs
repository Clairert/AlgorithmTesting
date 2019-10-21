using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTester
{
    class TernaryTree
    {

        //private Node m_root = null;

        //void Add(string s, int pos, ref Node node, string preservedCase)
        //{
        //    if (node == null) { node = new Node(s[pos], false); }

        //    if (s[pos]!=node.m_char) { Add(s, pos, ref node.m_right, preservedCase); }
        //    else
        //    {
        //        if (pos + 1 == s.Length)
        //        {
        //            node.m_wordEnd = true;
        //            node.m_cased = preservedCase;
        //        }
        //        else { Add(s, pos + 1, ref node.m_center, preservedCase); }
        //    }
        //}

        //public void Add(string toAdd)
        //{
        //    if (toAdd == null || toAdd == "") throw new ArgumentException();

        //    Add(toAdd.ToLower(), 0, ref m_root, toAdd);
        //}

        //public bool Contains(string s)
        //{
        //    if (s == null || s == "") throw new ArgumentException();

        //    int pos = 0;
        //    Node node = m_root;
        //    while (node != null)
        //    {
        //        int cmp = s[pos] - node.m_char;
        //        if (s[pos] < node.m_char) { node = node.m_left; }
        //        else if (s[pos] > node.m_char) { node = node.m_right; }
        //        else
        //        {
        //            if (++pos == s.Length) return node.m_wordEnd;
        //            node = node.m_center;
        //        }
        //    }

        //    return false;
        //}



        //public ArrayList AutoComplete(String toMatch)
        //{

        //    if (toMatch == null || toMatch == "") throw new ArgumentException();

        //    toMatch = toMatch.ToLower();
        //    ArrayList _suggestionValues = new ArrayList();
        //    ArrayList _suggestionPoints = new ArrayList();

        //    int pos = 0;
        //    Node node = m_root;
        //    while (node != null)
        //    {
        //        // get the
        //        int cmp = toMatch[pos] - node.m_char;

        //        if (toMatch[pos] != node.m_char)
        //        {
        //            // mo match,
        //            if (cmp < 0)
        //                node = node.m_left;
        //            else
        //                node = node.m_right;
        //        }
        //        else
        //        {
        //            if (++pos == toMatch.Length)
        //            {
        //                if (node.m_wordEnd == true)
        //                {
        //                    // suggestions.Add(s); gives you the lowercased
        //                    _suggestionValues.Add(node.m_cased);
        //                }
        //                FindSuggestions(toMatch, _suggestionValues, _suggestionPoints, node.m_center);

        //                return (_suggestionValues);
        //            }

        //            node = node.m_center;
        //        }
        //    }

        //    return (_suggestionValues);
        //}


        //void FindSuggestions(string s, ArrayList suggestions, ArrayList suggestionPoints, Node node)
        //{
        //    if (node == null)
        //    {
        //        return;
        //    }

        //    // eg: “an” is as string,

        //    if (node.m_wordEnd == true)
        //    {
        //        // suggestions.Add(s + node.m_char); // gives you the lower cased
        //        suggestions.Add(node.m_cased);
        //    }

        //    FindSuggestions(s, suggestions, suggestionPoints, node.m_left); // A
        //    FindSuggestions(s + node.m_char, suggestions, suggestionPoints, node.m_center);
        //    FindSuggestions(s, suggestions, suggestionPoints, node.m_right); // when out results in “qq palais-sur-vienne”

        //    // results: when A and B removed, then no results returned.
        //}












    }
    
}
