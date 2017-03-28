using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Task4
{
    public struct LineItem
    {
        public int Position;
        public string Description;
    }

    public interface Document
    {
        string Supplier { get; set; }
        string Customer { get; set; }
        void AddItem(string name);
        void RemoveItem(int Position);
        void Print();
    }

    [TestFixture]
    public class Order : Document
    {
        public Order(string s, string c, string l)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentException("Es muss ein Lieferant angegeben werden!", nameof(s));
            if (string.IsNullOrWhiteSpace(c)) throw new ArgumentException("Es muss ein Kunde angegeben werden!", nameof(c));

            ItemAmount = 0;
            Supplier = s;
            Customer = c;
            AddItem(l);
        }

        public string Supplier { get; set; }
        public string Customer { get; set; }

        LineItem[] LIN = new LineItem[100];

        int ItemAmount;

        [Test]
        public void AddItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            ItemAmount++;

            LIN[ItemAmount].Position = ItemAmount;
            LIN[ItemAmount].Description = name;
            Assert.IsTrue(LIN[ItemAmount].Position == ItemAmount);
            Assert.IsTrue(LIN[ItemAmount].Description == name);
        }

        [Test]
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
                if (Position != ItemAmount)
                {
                    for (int i = Position; i < ItemAmount; i++)
                    {
                        LIN[i].Position = LIN[i + 1].Position - 1;
                        LIN[i].Description = LIN[i + 1].Description;
                        Assert.IsTrue(LIN[i].Position == LIN[i + 1].Position - 1);
                        Assert.IsTrue(LIN[i].Description == LIN[i + 1].Description);
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
            Console.WriteLine("Supplier: {0}, Customer: {1}", Supplier, Customer);
            Console.WriteLine("Lineitems:");
            for (int i = 1; i <= ItemAmount; i++)
            {
                Console.WriteLine("Pos: {0}, Description: {1}", LIN[i].Position, LIN[i].Description);
            }
            Console.WriteLine();
        }
    }

    [TestFixture]
    public class OrderConfirmation : Document
    {
        public OrderConfirmation(string s, string c, int r, string l)
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

        public string Supplier { get; set; }
        public string Customer { get; set; }
        public int OrderReference { get; set; }

        LineItem[] LIN = new LineItem[100];

        int ItemAmount;

        [Test]
        public void AddItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            ItemAmount++;

            LIN[ItemAmount].Position = ItemAmount;
            LIN[ItemAmount].Description = name;
            Assert.IsTrue(LIN[ItemAmount].Position == ItemAmount);
            Assert.IsTrue(LIN[ItemAmount].Description == name);
        }

        [Test]
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
                if (Position != ItemAmount)
                {
                    for (int i = Position; i < ItemAmount; i++)
                    {
                        LIN[i].Position = LIN[i + 1].Position - 1;
                        LIN[i].Description = LIN[i + 1].Description;
                        Assert.IsTrue(LIN[i].Position == LIN[i + 1].Position - 1);
                        Assert.IsTrue(LIN[i].Description == LIN[i + 1].Description);
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
            Console.WriteLine("Supplier: {0}, Customer: {1}, Order reference: {2}", Supplier, Customer, OrderReference);
            Console.WriteLine("Lineitems:");
            for (int i = 1; i <= ItemAmount; i++)
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
            var Documents = new Document[]
            {
                new Order("Bahaus","Elektroladen Wagner","Kabel 3m"),
                new Order("Bahaus","Elektroladen Wagner","Kabel 10m"),
                new OrderConfirmation("Zgonc","Quester",4711,"Estrich 40kg"),
                new OrderConfirmation("Zgonc","Quester",4712,"Zement 30kg"),
                new Order("Hornbach","Gärtnerei Huber","10x Schaufel")
            };

            foreach (var x in Documents)
            {
                x.Print();
            }

            string s = JsonConvert.SerializeObject(Documents);

            System.IO.StreamWriter file = new System.IO.StreamWriter("myfile.txt");
            file.WriteLine(s);
            file.Close();

            string content = System.IO.File.ReadAllText(@"myfile.txt");
            Console.WriteLine(content);           
        }
    }
}
