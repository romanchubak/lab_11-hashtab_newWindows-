using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11_hashtab_newWindows_
{
    class HashTabItem
    {
        public int Status { get; set; }
        public string FirstName { get; set; }
        public string NumAuto { get; set; }
        public string ModelAuto { get; set; }

        public HashTabItem()
        {
            Status = -1;
            FirstName = "";
            ModelAuto = "";
            NumAuto = "";
        }
        public HashTabItem(int status, string firstname, string numauto, string modeauto)
        {
            Status = status;
            FirstName = firstname;
            NumAuto = numauto;
            ModelAuto = modeauto;
        }
    }
    class HashTab
    {
        private HashTabItem[] Tab;
        private int length;
        public int Length { get { return length; } }

        public HashTab()
        {
            length = 20;
            Tab = new HashTabItem[20];
            for (int i = 0; i < Length; i++)
                Tab[i] = new HashTabItem();
        }

        public HashTab(int num)
        {
            length = num;
            Tab = new HashTabItem[num];
            for (int i = 0; i < Length; i++)
                Tab[i] = new HashTabItem();
        }

        // Hash function Modified Bernstein
        uint djb_hash(string key)
        {
            string p = key;
            uint h = 0;
            for (int i = 0; i < key.Length; i++)
                h = 33 * h ^ p[i];
            return h % (uint)length;
        }

        //add
        public void Add(string firstname, string numAuto, string modelAuto)
        {
            HashTabItem tmp = new HashTabItem(1, firstname, numAuto, modelAuto);
            uint index = djb_hash(firstname);
            bool flag = false;
            while (Tab[index].Status == 1 && !flag)
            {
                index++;
                if (index == Length) index = 0;
                if (index == djb_hash(firstname)) flag = true;
            }
            if (!flag)
                Tab[index] = tmp;
        }

        //del
        public void Del(string firstname)
        {
            if (Search(firstname) < length)
                Tab[Search(firstname)].Status = 0;
        }

        //print hashtab
        public string PrintHashTab()
        {
            string rez = "";
            for (int i = 0; i < Tab.Length; i++)
            {
                if (Tab[i].Status == 1)
                    rez += Tab[i].FirstName + "\t" + Tab[i].ModelAuto + "\t" + Tab[i].NumAuto + "\n";
            }
            return rez;
        }
        public string[] PrintHashTab(int num)
        {
            string[] rez = new string[3];
            rez[1] = ""; rez[0] = ""; rez[2] = ""; 
            for (int i = 0; i < Tab.Length; i++)
            {
                if (Tab[i].Status == 1)
                {
                    rez[0] += Tab[i].FirstName + "\n";
                    rez[1] += Tab[i].ModelAuto + "\n";
                    rez[2] += Tab[i].NumAuto + "\n";
                }   
            }
            return rez;
        }

        //search
        public uint Search(string firstname)
        {
            uint index = djb_hash(firstname);
            bool flag = false;
            while ( flag == false)
            {
                if (Tab[index].Status == -1) return (uint)length;
                else if (Tab[index].Status == 0) index++;
                else if (Tab[index].Status == 1 && Tab[index].FirstName == firstname) return index;
                else index++;
                if (index == length) index = 0;
                if (index == djb_hash(firstname)) flag = true;
            }
            return (uint)length;         
        }

    }
}
