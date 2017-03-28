using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public struct LineItem
    {
        public int Position;
        public string Description;
    }

    public class Document
    {
        public Document(string s, string c, int r, string l)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentException("Es muss ein Lieferant angegeben werden!", nameof(s));
            if (string.IsNullOrWhiteSpace(c)) throw new ArgumentException("Es muss ein Kunde angegeben werden!", nameof(c));
            if (r < 0) throw new ArgumentException("Die Referenz muss eine positive Zahl sein!", nameof(r));

            ItemAmount = 0;
            Supplier = s;
            Customer = c;
            OrderReference = r;
            AddItem(l);
        }

        string Supplier { get; set; }
        string Customer { get; set; }
        int OrderReference { get; set; }

        LineItem[] LIN = new LineItem[100];

        int ItemAmount;

        public void AddItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            ItemAmount++;
            LIN[ItemAmount].Position = ItemAmount;
            LIN[ItemAmount].Description = name;
        }

        public void RemoveItem(int Position)
        {
            if (Position > ItemAmount)
            {
                Console.WriteLine("Position nicht gefunden!");
                return;
            }
            else if (Position < 1)
            {
                Console.WriteLine("Position darf nicht unter 1 sein!");
                return;
            }
            else
            {
                if(Position != ItemAmount)
                {
                    for(int i = Position; i < ItemAmount; i++)
                    {
                        LIN[i].Position = LIN[i + 1].Position - 1;
                        LIN[i].Description = LIN[i + 1].Description;
                    }
                    ItemAmount--;
                }
                else
                {
                    ItemAmount--;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Supplier: {0}, Customer: {1}, OrderReference: {2}",Supplier,Customer,OrderReference);
            Console.WriteLine("Lineitems:");
            for(int i = 1; i <= ItemAmount;i++)
            {
                Console.WriteLine("Pos: {0}, Description: {1}", LIN[i].Position, LIN[i].Description);
            }
            Console.WriteLine();
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            Document Obj = new Document("Bauhaus", "Elektroladen Münz", 2311,null);
            Obj.Print();

            Obj.AddItem("Kübel blau 5L");
            Obj.AddItem("Elektrokabel 5m");

            Obj.Print();

            Obj.RemoveItem(1);
            Obj.AddItem("Schraubenset Alpha-Tools");
            Obj.Print();
        }
    }
}
