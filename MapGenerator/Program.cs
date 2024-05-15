/**
 * Declares a Class of the domain
 * The Class must contain some attributes
 * The program will create some instances with different attributes
 * The program will print on the screen the information for all instances
 **/


/**
 * 1- All user input/output must be in the Program class, incorrect input should be handled.
 * 2- All attributes must be manipulated through Properties.
 * 3- Properties should implement control on the values provided to « get » and implement a
 * default mechanism in case of incorrect value.
 * 4- All the code must be in a unique program.cs file (in order to simplify mail content)
 * 5- The Program code must be in a non static method « Work » called from « Main »
 * In the Program.Work method :
 * 6- Ask the user how many instances are required
 * 7- Create these instances automatically, filling propeties automatically or by querying the user
 * and store them in an Array (no collections, List, Set, Map whatsoever)
 * 8- Print the content of the array
 * 9- Sort the instances in the array following one criteria of your choice
 * 10- Print the content of the sorted array
 **/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


enum TileType
{
    Wall = 1,
    Floor,
}


enum Object
{
    None = 0,
    Tree,
    Rock,
}


class Vector2i : IComparable<Vector2i>
{
    public Vector2i(int x_, int y_)
    {
        x = x_;
        y = y_;
    }

    override public String ToString()
    {
        return "x = " + x + ", y = " + y;
    }

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public void move(Vector2i v)
    {
        x += v.X;
        y += v.Y;
    }

    // comparator
    public int CompareTo(Vector2i v)
    {
        if (x < v.X)
        {
            return -1;
        }
        else if (x > v.X)
        {
            return 1;
        }
        else
        {
            if (y < v.Y)
            {
                return -1;
            }
            else if (y > v.Y)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    int x, y;
}


class Tile : IComparable<Tile>
{
    public Tile(int x, int y, TileType type, Object obj)
    {
        this.position = new Vector2i(x, y);
        this.type = type;
        this.obj = obj;
    }

    override public String ToString()
    {
        return "position = " + position.ToString() + ", type = " + type + ", obj = " + obj;
    }

    public Vector2i Position
    {
        get { return position; }
    }

    public void Move(Vector2i v)
    {
        position.move(v);
    }

    // comparator
    public int CompareTo(Tile t)
    {
        return position.CompareTo(t.Position);
    }

    Vector2i position;
    TileType type;
    Object obj;
}


namespace MapGenerator
{
    class Program
    {
        void Work()
        {
            int n = 0;
            String n_str = "";
            Console.WriteLine("How many tiles do you want to create?");
            while (n_str.All(char.IsDigit) == false || n_str == "")
            {
                Console.Write("\tn = ");
                n_str = Console.ReadLine();
            }
            n = int.Parse(n_str);
            n = n < 0 ? 0 : n;
            // array of tiles
            Tile[] tiles = new Tile[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Tile {0}:", i);
                Vector2i position;
                int x, y;
                String x_str = "", y_str = "";
                while (x_str.All(char.IsDigit) == false || x_str == "")
                {
                    Console.Write("\tx = ");
                    x_str = Console.ReadLine();
                }
                x = int.Parse(x_str);
                while (y_str.All(char.IsDigit) == false || y_str == "")
                {
                    Console.Write("\ty = ");
                    y_str = Console.ReadLine();
                }
                y = int.Parse(y_str);
                TileType type = (TileType)(-1); // invalid value
                while (type != TileType.Wall && type != TileType.Floor)
                {
                    String type_str = "";
                    while (type_str.All(char.IsDigit) == false || type_str == "")
                    {
                        Console.Write("\ttype (1 = Wall, 2 = Floor) = ");
                        type_str = Console.ReadLine();
                    }
                    type = (TileType)int.Parse(type_str);
                }
                Object obj = (Object)(-1); // invalid value
                while (obj != Object.None && obj != Object.Tree && obj != Object.Rock)
                {
                    String obj_str = "";
                    while (obj_str.All(char.IsDigit) == false || obj_str == "")
                    {
                        Console.Write("\tobj (0 = None, 1 = Tree, 2 = Rock) = ");
                        obj_str = Console.ReadLine();
                    }
                    obj = (Object)int.Parse(obj_str);
                }
                Tile tile = new Tile(x, y, type, obj);
                tiles[i] = tile;
            }
            Console.WriteLine("Content of the array:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\t" + tiles[i]);
            }
            // sort the array
            Array.Sort(tiles);
            // print the content of the sorted array
            Console.WriteLine("Content of the sorted array:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\t" + tiles[i]);
            }
            Console.Read();
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.Work();
        }
    }
}
