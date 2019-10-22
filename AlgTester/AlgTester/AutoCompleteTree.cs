using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTester
{
    class AutoCompleteTree
    {
        public Node m_root;

        public AutoCompleteTree()
        {
            m_root = new Node('-', false);
        }
        //Getting string to add to tree
        public void Add(string toAdd)
        {
            if (toAdd == null || toAdd == "") throw new ArgumentException();

            Add(toAdd.ToLower(), 0, ref m_root);
        }

        //Adding nodes to tree from original string
        void Add(string word, int pos, ref Node parent)
        {
            Boolean end;
            if (pos + 1 == word.Length)
            {
                end = true;
            }
            else
            {
                end = false;
            }
            Node nextParent = parent.findChild(word[pos], end);
            if(!end)
            {
                Add(word, pos + 1, ref nextParent);
            }
            
        }

        public Boolean Contains(String word)
        {
            if (word == null || word == "")
            {
                return false;
            }
            int pos = 0;
            Boolean searching = true;
            Boolean end = false;
            Node start = m_root;
            while(searching)
            {
                if (pos + 1 == word.Length)
                {
                    end = true;
                }
                else
                {
                    end = false;
                }
                start = start.findNode(word[pos], end);
                if(start==null)
                {
                    searching = false;
                }
                else
                {
                    if(end)
                    {
                        return true;
                    }
                }
                pos++;
                
            }
            return false;

        }



        public String[] suggestions(String word)
        {
            int pos = 0;
            Node enteredEnd = m_root;
            for (int i = 0; i < word.Length; i++)
            {
                enteredEnd = enteredEnd.findNode(word[i], false);
            }
            List<String> suggestions = travelNode(enteredEnd, new List<string>());
            string suggest = string.Join("", suggestions);
            String[] sg = suggest.Split('*');
            for (int i = 0; i < sg.Length; i++)
            {
                sg[i] = word + sg[i];
            }
            
            return sg;

        }

        private List<String> travelNode(Node startNode, List<String> suggestions)
        {
            if (!startNode.m_wordEnd)
            {
                foreach (Node node in startNode.children)
                {
                    suggestions.Add(Char.ToString(node.m_char));
                    travelNode(node,suggestions);
                }
            }
            else
            {
                suggestions.Add("*");
                return suggestions;
            }
            return suggestions;
        }
    }
}
