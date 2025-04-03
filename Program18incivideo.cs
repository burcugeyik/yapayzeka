using System;

namespace veriyapılarıvize18.video
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste cydaListe = new Liste();
            int sayi, indis;

            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1: Console.Write("sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.basaEkle(sayi);
                        cydaListe.yazdir();
                        break;

                    case 2:
                        Console.Write("sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.sonaEkle(sayi);
                        cydaListe.yazdir();
                        break;

                    case 3:
                        Console.Write("indis : "); indis = int.Parse(Console.ReadLine());
                        Console.Write("sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.arayaEkle(indis, sayi);
                        cydaListe.yazdir();
                        break;

                    case 4: cydaListe.bastanSil();
                        cydaListe.yazdir();
                        break;
                        
                    case 5: cydaListe.sondanSil();
                        cydaListe.yazdir();
                        break;

                    case 6:
                        Console.Write("indis : "); indis = int.Parse(Console.ReadLine());
                        cydaListe.aradanSil(indis);
                        cydaListe.yazdir();
                        break;

                    case 7: cydaListe.terstenYazdir(); break;
                    case 0: break;


                    default:
                        Console.WriteLine("hatalı seçim yaptınız");
                        break;
                }

                secim = menu();
                Console.Clear();

            }

            Console.WriteLine("program kapatıldı ");





            Console.ReadKey();

        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n\n1-basa ekle ");
            Console.WriteLine("2-sona ekle ");
            Console.WriteLine("3-araya ekle ");
            Console.WriteLine("4-bastan sil ");
            Console.WriteLine("5-sondan sil ");
            Console.WriteLine("6-aradan sil ");
            Console.WriteLine("7-tersten yazdır ");
            Console.WriteLine("0-programı kapat  ");
            Console.WriteLine("seçiminiz :  ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }

    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data )
        {
            this.data = data;
            this.next = null;
            this.prev = null;
                
        }
    }
    class Liste
    {
        Node head;
        Node tail;

        public Liste()
        {
            this.head = null;
            this.tail = null;
        }

        public void basaEkle( int data )
        {
            Node eleman = new Node(data);
            
            if( head== null )
            {
                //eleman.next = eleman; 4 satır yerine bu iki satırda yazılabilir
                //eleman.prev = eleman;

                head = tail = eleman;

                tail.next = head;
                tail.prev = head;
                head.next = tail;
                head.prev = tail;
                Console.WriteLine("liste yapısı oluşturuldu, ilk eleman eklendi");

            }
            else
            {
                eleman.next = head;
                head.prev = eleman;

                head = eleman;

                head.prev = tail;
                tail.next = head;
                Console.WriteLine("başa eleman eklendi");
            }
        }


        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                //eleman.next = eleman; 4 satır yerine bu iki satırda yazılabilir
                //eleman.prev = eleman;

                head = tail = eleman;

                tail.next = head;
                tail.prev = head;
                head.next = tail;
                tail.prev = tail;
                Console.WriteLine("liste yapısı oluşturuldu, ilk eleman eklendi");

            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;

                tail = eleman;

                tail.next = head;
                head.prev = tail;
                
                Console.WriteLine("sona eleman eklendi");
            }
        }


        public void arayaEkle(int indis, int data)
        {
            Node eleman = new Node(data);

            if (head == null && indis ==0 )
            {
                //eleman.next = eleman; 4 satır yerine bu iki satırda yazılabilir
                //eleman.prev = eleman;

                head = tail = eleman;

                tail.next = head;
                tail.prev = head;
                head.next = tail;
                tail.prev = tail;
                Console.WriteLine("liste yapısı oluşturuldu, ilk eleman eklendi");

            }
            else if (head != null && indis == 0)
            {
                basaEkle(data);
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;

                while (temp!=tail)
                {

                    if( i== indis )
                    {
                        temp2.next = eleman;
                        eleman.prev = temp2;


                        eleman.next = temp;
                        temp.prev = eleman;
                        Console.WriteLine("araya eleman eklendi");
                        i++;
                        break;
                    }


                    temp2 = temp;
                    temp = temp.next;
                    i++;

                }
                if (i == indis)
                {
                    temp2.next = eleman;
                    eleman.prev = temp2;


                    eleman.next = temp;
                    temp.prev = eleman;
                    Console.WriteLine("araya eleman eklendi");
                   

                }

            }
        }




        public void yazdir()
        {
            if(head == null)
                Console.Write("liste boş");

            else
            {
                Node temp = head;
                Console.Write("baş  -> ");

                while(temp != tail )
                {
                    Console.Write(temp.data + " -> ");
                    temp = temp.next;
                }
                Console.Write(temp.data + " son.");

            }
        }

        public void terstenYazdir()
        {
            if (head == null)
                Console.Write("liste boş");

            else
            {
                Node temp = tail;
                Console.Write("Son  -> ");
                while (temp != head)
                {
                    Console.Write(temp.data + " -> ");
                    temp = temp.prev;
                }
                Console.Write(temp.data + " baş.");

            }
        }

        public void bastanSil()
        {
            if( head==null )
            {
                Console.WriteLine("liste boş");
            }
            else if ( head.next==head)
            {
                head = tail = null;
                Console.WriteLine("eleman silindi, listede eleman kalmadı ");
            }
            else
            {
                head = head.next;
                head.prev = tail;
                tail.next = head;
                Console.WriteLine("baştan eleman silindi");
            }


        }

        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head)
            {
                head = tail = null;
                Console.WriteLine("eleman silindi, listede eleman kalmadı ");
            }
            else
            {
                
                tail = tail.prev;
                tail.next = head;
                head.prev = tail;

                Console.WriteLine("sondan eleman silindi");
            }


        }
        public void aradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("liste boş");
            }
            else if (head.next == head && indis ==0 ) //bir eleman vardır
            {
                head = tail = null;
                Console.WriteLine("eleman silindi, listede eleman kalmadı ");
            }
            else if (head.next != head && indis == 0) //listede birden fazla eleman var ancak kullanıcı ilk elemanı silmek istiyor
            {
                bastanSil();
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0; //seçtiğimiz düğüm i indise eşit olduğu zaman silinecek değer o dur, onu da temp tutuyor
                while (temp!=tail) //son düğüme kadar git
                {
                    if( i== indis ) //silinecek değer bulundu
                    {
                        temp2.next = temp.next; //silinecek düğümün next ini bir sonraki değere bağlayarak aradan next bağlantısını kopardık
                        temp.next.prev = temp2; //bir sonraki düğümün previni bir ileri gidip geri gelerek farklı bir düğüme bağladık ve aradaki düğümü boşa çıkardık
                        Console.WriteLine("aradan eleman silindi");
                        i++;  //son düğümüde silmek isteyebiliriz
                        break;
                    }

                    temp2 = temp; //temp bir sonraki düğüme geçmeden önce temp2 tenpi tutsun
                    temp = temp.next;
                    i++;

                }
                if (i == indis)   //son düğümü silmek istiyoruz demek 
                {
                    sondanSil();

                    //tail = tail.prev;
                    //tail.next = head;
                    //head.prev = tail;

                    //Console.WriteLine("sondan eleman silindi");


                }
            }
        }

    }

}
