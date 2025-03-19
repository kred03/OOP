﻿namespace ConsolePaint.Models
{
    public abstract class Shape
    {
        public char BorderChar { get; set; }
        public string Name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public char FillCharacter { get; set; } 

        public static Shape? FromText(string type, string data)
        {
            return type switch
            {
                "Circle" => Circle.FromText(data),
                "Rectangle" => Rectangle.FromText(data),
                "Triangle" => Triangle.FromText(data),
                _ => null
            };
        }

        
        public abstract void DrawOnCanvas(char[,] canvas, char fillChar); 

        public abstract string ToText();
        
        public void Move(int newX, int newY)
        {
            x = newX;
            y = newY;
        }
        
        public void FloodFill(char[,] canvas, int x, int y, char fillChar)
        {
            int height = canvas.GetLength(0);
            int width = canvas.GetLength(1);

            if (x < 0 || x >= width || y < 0 || y >= height || canvas[y, x] != ' ')
                return;

            canvas[y, x] = fillChar;

            FloodFill(canvas, x + 1, y, fillChar);
            FloodFill(canvas, x - 1, y, fillChar);
            FloodFill(canvas, x, y + 1, fillChar);
            FloodFill(canvas, x, y - 1, fillChar);
        }
        
        public virtual bool IsInside(int testX, int testY)
        {
            return false;
        }
        
     
    }
}