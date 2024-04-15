/**
 * Declares a Class of the domain
 * The Class must contain some attributes
 * The program will create some instances with different attributes
 * The program will print on the screen the information for all instances
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum TileType
{
    Wall,
    Floor,
}


enum Object
{
    None,
    Tree,
    Rock,
}


class Tile
{
    public Tile(int x, int y, TileType type, Object obj)
    {
        this.x = x;
        this.y = y;
        this.type = type;
        this.obj = obj;
    }

    public void Print()
    {
        Console.WriteLine("Tile: x = {0}, y = {1}, type = {2}, obj = {3}", x, y, type, obj);
    }

    int x, y;
    TileType type;
    Object obj;
}


namespace MapGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Tile tile1 = new Tile(0, 0, TileType.Wall, Object.None);
            Tile tile2 = new Tile(1, 0, TileType.Floor, Object.Tree);
            Tile tile3 = new Tile(2, 0, TileType.Floor, Object.Rock);

            tile1.Print();
            tile2.Print();
            tile3.Print();

            Console.ReadKey();
        }
    }
}
