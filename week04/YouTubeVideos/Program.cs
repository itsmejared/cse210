using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Cocina Peruana con Pollo", "El Cholo Mena", 400);
        video1.AddComment(new Comment("Luis", "Amazing recipe!"));
        video1.AddComment(new Comment("Mike", "Super clear explanation."));
        video1.AddComment(new Comment("Andrés", "Amazing Flavor. Looks good."));
        videos.Add(video1);

        Video video2 = new Video("10 Money Hacks", "MoneySaver", 600);
        video2.AddComment(new Comment("Carlos", "This helped me make more money."));
        video2.AddComment(new Comment("Pedro", "Great tips!"));
        video2.AddComment(new Comment("Vanessa", "Very helpful."));
        videos.Add(video2);

        Video video3 = new Video("Learn how to ride a bike", "Dad for you", 900);
        video3.AddComment(new Comment("Luis", "I finally get it."));
        video3.AddComment(new Comment("Marta", "Thank you so much!"));
        video3.AddComment(new Comment("Ana", "Very easy to follow.")); 
        videos.Add(video3);

        foreach (Video v in videos)
        {
            v.DisplayInfo();
            Console.WriteLine();
        }
    }
}
